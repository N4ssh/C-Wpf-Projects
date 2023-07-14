using System.IO;
using System.Media;

namespace Quiz_App
{
    internal class Music : SoundPlayer
    {
        public Music(Stream stream) : base(stream)
        {
        }
    }
}