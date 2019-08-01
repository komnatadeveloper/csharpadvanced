using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    public class Video
    {
        public string Title;

    }

    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event based on that delegate
        // 3. Raise the event

        // 1
        public delegate void VideoEncoderEventHandler(object source, EventArgs args);

        // 2
        public event VideoEncoderEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            // 3
            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
        }

    }

    public class MailService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: Sending an email...");
        }
    }
    public class TextService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("TextService: Sending a text message...");
        }
    }

    public class ProgramKendi
    {
        static void Main()
        {
            var video = new Video() { Title = "Video1" };
            var videoEncoder = new VideoEncoder();  // publisher
            var mailService = new MailService();    // subscriber
            var textService = new TextService();    // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;    // subscription
            videoEncoder.VideoEncoded += textService.OnVideoEncoded;    // subscription



            videoEncoder.Encode(video);   // burada fire ediyoruz.
        }
    }



}
