using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Pipes
{
    public class PipeNull :  IPipe
    {
        public static List <IPicture> Image_Data_Base = new List<IPicture>();

        IPicture image;

        public PipeNull(IPicture picture)
        {
            Image_Data_Base.Add(picture);

        }
        public void Load_Image_From_Data_Base()
        {   
            int name = 0;
            PictureProvider p = new PictureProvider();
            foreach (IPicture pic in Image_Data_Base)
            {
                name++;
               p.SavePicture(pic,$@"C:\Users\User\OneDrive - Universidad Católica del Uruguay\PROG II\EJERCICIOS\Pipe_Filter\PII_Pipes_Filters_Start\src\Program\Filtro {name}.jpg");
            }
            

        }
        /// <summary>
        /// Recibe una imagen, la guarda en una variable image y la retorna.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public IPicture Send(IPicture picture)
        {
            this.image = picture;
            Image_Data_Base.Add(picture);
            return this.image;
        }

        public void Share_in_Tweter()
        {
            var twitter = new TwitterImage();
            int name = 0;
            foreach (IPicture pic in Image_Data_Base)
            {
                name++;
                twitter.PublishToTwitter($"Gonzalo.{name} ",$@"C:\Users\User\OneDrive - Universidad Católica del Uruguay\PROG II\EJERCICIOS\Pipe_Filter\PII_Pipes_Filters_Start\src\Program\Filtro {name}.jpg");
               
            }
        }

    }
}
