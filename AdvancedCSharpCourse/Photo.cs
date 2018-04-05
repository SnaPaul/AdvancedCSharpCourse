using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpCourse
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            Console.WriteLine("Photo loaded.");

            return new Photo();
        }

        public void Save()
        {
            Console.WriteLine("Photo saved.");
        }
    }
}
