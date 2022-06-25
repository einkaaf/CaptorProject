using Captor.Response;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Captor.Factory
{
    public class CaptorFactory
    {
        #region Captor props
        private int Width { get; set; } = 100;
        private int Height { get; set; } = 40;
        private int Hardness { get; set; } = 10;
        private int FirstNumberStartRange { get; set; } = 10;
        private int FirstNumberEndRange { get; set; } = 99;
        private int SecondNumberStartRange { get; set; } = 0;
        private int SecondNumberEndRange { get; set; } = 9;
        private string BackgroundColorHex { get; set; } = "FFFFFF";
        private string FontPath { get; set; }
        private bool UseNegative { get; set; }
        private bool basicRotation { get; set; }
        #endregion

        #region Captor Settings
        internal void UseCustomNumbers(int firstNumberStartRange, int firstNumberEndRange, int secondNumberStartRange, int secondNumberEndRange)
        {
            this.FirstNumberStartRange = firstNumberStartRange;
            this.FirstNumberEndRange = firstNumberEndRange;

            this.SecondNumberStartRange = secondNumberStartRange;
            this.SecondNumberEndRange = secondNumberEndRange;
        }

        internal void UseCustomSize(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        internal void AddHardness(int hardness)
        {
            this.Hardness = hardness;
        }

        internal void AddBackgroundColor(string hex)
        {
            this.BackgroundColorHex = hex;
        }

        internal void AddCustomFont(string fontPath)
        {
            this.FontPath = fontPath;
        }

        internal void UseNegativeSign(bool useNegativeSign)
        {
            this.UseNegative = useNegativeSign;
        }  
        
        internal void UseBasicRotation(bool basicRotation)
        {
            this.basicRotation = basicRotation;
        }

        #endregion

        #region Captor Creator Methods
        internal CaptorResponse CreateCaptor()
        {
            Random random = new Random();

            using (Image<Rgba32> image = new(Width, Height))
            {
                FontCollection collection = new();

                FontFamily family;
                Font font;

                if (File.Exists(this.FontPath))
                {
                    family = collection.Add(FontPath);
                    font = family.CreateFont(16, FontStyle.Regular);
                }
                else
                {
                    var familyList = collection.AddSystemFonts().Families.ToList();
                    Random rnd = new Random();
                    int r = rnd.Next(familyList.Count);
                    family = familyList[r];
                    font = family.CreateFont(16, FontStyle.Regular);
                }


                TextOptions options = new TextOptions(font)
                {
                    Origin = new PointF(Width / 2, Height / 2),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WordBreaking = WordBreaking.BreakAll
                };


             
                var firstNumber = random.Next(FirstNumberStartRange, FirstNumberEndRange);
                var secondNumber = random.Next(SecondNumberStartRange, SecondNumberEndRange);

                string numberFormat = UseNegative ? "{0} - {1} = ?" : "{0} + {1} = ?";
                string text = String.Format(numberFormat, firstNumber, secondNumber);

                for (int i = 0; i < Hardness; i++)
                {
                    var points = new PointF[2];

                    int x0 = random.Next(0, image.Width * 2);
                    int y0 = random.Next(0, image.Height);

                    int x1 = random.Next(0, image.Width);
                    int y1 = random.Next(0, image.Height);

                    points[0] = new PointF(
                    x: (float)(x0),
                    y: (float)(y0));

                    points[1] = new PointF(
                   x: (float)(x1),
                   y: (float)(y1));

                    float lineWidth = 2;

                    Color randomColor = Color.FromRgba(((byte)random.Next(256)), ((byte)random.Next(256)), ((byte)random.Next(256)), ((byte)random.Next(200)));

                    image.Mutate(x => x.DrawLines(randomColor, lineWidth, points));
                }

                image.Mutate(x => x.DrawText(options, text, Color.Black));

                if (basicRotation)
                {
                    // Rotation
                    var builder = new AffineTransformBuilder();
                    var widthh = random.Next(10, Width);
                    var heightt = random.Next(10, Height);
                    var pointF = new PointF(Width, Height);
                    var rotationDegrees = random.Next(-10, 10);
                    var result = builder.PrependRotationDegrees(rotationDegrees, pointF);

                    image.Mutate(ctx => ctx.Transform(result));
                }

                try
                {
                    image.Mutate(x => x.BackgroundColor(Color.ParseHex(BackgroundColorHex)));
                }
                catch (Exception ex)
                {
                    image.Mutate(x => x.BackgroundColor(Color.ParseHex("FFFFFF")));
                }


               


                using (var ms = new MemoryStream())
                {
                    image.Save(ms, new JpegEncoder());
                    byte[] imageByte = ms.ToArray();

                    return new CaptorResponse
                    {
                        Image = imageByte,
                        Result = UseNegative ? (firstNumber - secondNumber) : (firstNumber + secondNumber)
                    };
                }


            }
        }
        #endregion
    }
}
