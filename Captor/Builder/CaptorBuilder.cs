using Captor.Factory;
using Captor.Response;

namespace Captor.Service
{
    public class TextorBuilder
    {
        private TextorFactory textorFactory = new TextorFactory();
        private TextorBuilder()
        {

        }

        public static TextorBuilder Init()
        {
            return new TextorBuilder();
        }

        public CaptorResponse Build()
        {
            return textorFactory.CreateTextor();
        }


        public TextorBuilder UseCustomSize(int height, int width)
        {
            textorFactory.UseCustomSize(height, width);
            return this;
        }
        public TextorBuilder AddHardness(int hardness)
        {
            textorFactory.AddHardness(hardness);
            return this;
        }

        public TextorBuilder AddBackgroundColor(string hex)
        {
            textorFactory.AddBackgroundColor(hex);
            return this;
        }

        public TextorBuilder AddCustomFont(string fontPath)
        {
            textorFactory.AddCustomFont(fontPath);
            return this;
        }

        public TextorBuilder UseBasicRotation(bool useBasicRotation)
        {
            textorFactory.UseBasicRotation(useBasicRotation);
            return this;
        }

    }
}
