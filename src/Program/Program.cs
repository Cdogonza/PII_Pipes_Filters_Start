using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;
namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            string photo = @"C:\Users\User\OneDrive - Universidad Católica del Uruguay\PROG II\EJERCICIOS\Pipe_Filter\PII_CognitiveAPI\src\Program\beer.jpg";
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(photo);
            PipeNull tube = new PipeNull(picture);
            FilterNegative negativ = new FilterNegative();
            FilterFace face = new FilterFace();
            FilterGreyscale greyscale = new FilterGreyscale();
            PipeSerial serial1 = new PipeSerial(negativ,tube);          
            PipeSerial serial2 = new PipeSerial(greyscale,serial1);
            serial1.Send(picture);
            serial2.Send(picture);
            tube.Load_Image_From_Data_Base();
            tube.Share_in_Tweter(); // publica en twiter
            PipeCondicional pipeconditional = new PipeCondicional(face.Filterface(photo),tube); // utiliza el pipecondicional y si el Filter face le devuelve tru aplica el filtro negativo, sino el gryscale
            pipeconditional.Send(picture);
            tube.Load_Image_From_Data_Base(); //muestro la imagen guardada en la lista y la almaceno para pode verla
            


            
            
               
        }
    }
}
