using Captor.Factory;
using Captor.Response;

namespace Captor.Service
{
    public class CaptorBuilder
    {
        private CaptorFactory captorService = new CaptorFactory();
        private CaptorBuilder()
        {

        }

        public static CaptorBuilder Init()
        {
            return new CaptorBuilder();
        }

        public CaptorResponse Build()
        {
            return captorService.CreateCaptor();
        }

        public CaptorBuilder UseCustomNumbers(int firstNumberStartRange, int firstNumberEndRange, int secondNumberStartRange, int secondNumberEndRange)
        {
            captorService.UseCustomNumbers(firstNumberStartRange, firstNumberEndRange, secondNumberStartRange, secondNumberEndRange);
            return this;
        }
        public CaptorBuilder UseCustomSize(int height, int width)
        {
            captorService.UseCustomSize(height, width);
            return this;
        }
        public CaptorBuilder AddHardness(int hardness)
        {
            captorService.AddHardness(hardness);
            return this;
        }

        public CaptorBuilder AddBackgroundColor(string hex)
        {
            captorService.AddBackgroundColor(hex);
            return this;
        }

        public CaptorBuilder AddCustomFont(string fontPath)
        {
            captorService.AddCustomFont(fontPath);
            return this;
        }

        public CaptorBuilder UseNegativeSign(bool useNegativeSign)
        {
            captorService.UseNegativeSign(useNegativeSign);
            return this;
        }

        public CaptorBuilder UseBasicRotation(bool useBasicRotation)
        {
            captorService.UseBasicRotation(useBasicRotation);
            return this;
        }

    }
}
