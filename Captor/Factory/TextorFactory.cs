using Captor.Enum;
using Captor.Response;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Text;

namespace Captor.Factory
{
    public class TextorFactory
    {
        private int Width { get; set; } = 100;
        private int Height { get; set; } = 40;
        private int Hardness { get; set; } = 10;
        private string BackgroundColorHex { get; set; } = "FFFFFF";
        private string FontPath { get; set; }
        private bool BasicRotation { get; set; } = false;

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
        internal void UseBasicRotation(bool basicRotation)
        {
            this.BasicRotation = basicRotation;
        }
        internal void UseCustomSize(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }


        internal CaptorResponse CreateTextor()
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
                    font = family.CreateFont(11, FontStyle.Regular);
                }
                else
                {
                    byte[] bytes = Convert.FromBase64String("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");

                    return new CaptorResponse
                    {
                        Image = bytes,
                        Result = 4210
                    };
                }


                TextOptions options = new TextOptions(font)
                {
                    Origin = new PointF(Width / 2, Height / 2),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WordBreaking = WordBreaking.BreakAll
                };
                var singleNum = random.Next(TextNumber.single.Count);
                var doubleNum = random.Next(TextNumber.doubel.Count);
                var trippleNum = random.Next(TextNumber.tripple.Count);


                var singleText = TextNumber.single[singleNum];
                var doubleText = TextNumber.doubel[doubleNum];
                var trippleText = TextNumber.tripple[trippleNum];

                var resultNumber = (singleNum + 1) + ((doubleNum + 1) * 100) + ((trippleNum + 1) * 1000);

                var format = trippleText + " و " + doubleText + " و " + singleText;
                string text = String.Format(format, trippleText, doubleText, singleText);

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

                if (BasicRotation)
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
                        Result = resultNumber
                    };
                }


            }
        }
    }
}
