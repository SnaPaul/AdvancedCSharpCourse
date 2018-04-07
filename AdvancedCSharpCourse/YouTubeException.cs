using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpCourse
{
    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
            :base(message, innerException)
        {

        }
    }
}
