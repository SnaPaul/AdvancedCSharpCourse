using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AdvancedCSharpCourse
{
    public class VideoEncoder
    {
        //1. Define delegate
        //2. Define event based on that delegate
        //2. Raise/publish the event
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        //public event VideoEncodedEventHandler VideoEncoded;

        //or use the EventHandler from .NET to avoid creating an own delegate
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding..." + video.Title);

            Thread.Sleep(1000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if(VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs(){ Video = video});
            }
        }
    }
}
