using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpCourse
{
    class PhotoPrecessor
    {
        //public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, Action<Photo> filterHandler)
        {
       
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();

        }
    }

}
