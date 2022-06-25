using Captor.Response;
using Captor.Service;

CaptorResponse captorResponse = TextorBuilder.Init().UseCustomSize(50, 140).AddHardness(10).UseBasicRotation(true).Build();
string result = Convert.ToBase64String(captorResponse.Image);
Console.WriteLine("aa");
