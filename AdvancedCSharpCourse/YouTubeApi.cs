using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpCourse
{
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                //Access YouTube web service
                //Read the data
                //Create a list of Video objects
                throw new Exception("Oops some low level YouTube error.");
            }
            catch (Exception ex)
            {
                throw new YouTubeException("Could not fetch the Videos from YouTube.", ex);
            }

            return new List<Video>();
        }

    }
}
