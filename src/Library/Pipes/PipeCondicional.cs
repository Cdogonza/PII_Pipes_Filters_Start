
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System;
namespace CompAndDel.Pipes
{
    public class PipeCondicional  : IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;
       
        FilterNegative negativ = new FilterNegative();
        FilterGreyscale greyscale = new FilterGreyscale();


        public PipeCondicional(bool withface, IPipe nextPipe)
        {
            if( withface)
            {
                this.filtro = negativ;
                this.nextPipe = nextPipe;
                Console.WriteLine("negative");
            }else
            {
                this.filtro = greyscale;
                this.nextPipe = nextPipe;
                Console.WriteLine("gryscale");
            }

        }
        
      public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            return this.nextPipe.Send(picture);
        }  

    }
    
}