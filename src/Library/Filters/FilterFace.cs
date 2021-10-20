using CognitiveCoreUCU;
using System.IO;
using System.Runtime;
using System;
namespace CompAndDel.Filters
{
    public class FilterFace 
    {
        public bool WithFace = false;
        

    public bool Filterface(string image)
    {
        CognitiveFace Face_Rec = new CognitiveFace(false);
        Face_Rec.Recognize(image);
        if (Face_Rec.FaceFound)
            {
                Console.WriteLine("Face Found!");
                WithFace = true;
                 
            }
            else
                {
                    WithFace = false;
                    Console.WriteLine("Face no Found!");
                }      
    
        return WithFace;
    }
    
    }

}
