namespace Shared.Models
{
    public class Tele
    {
        public Tele()
        {
        }

        public Tele(int channel, int volume, int source)
        {
            Channel = channel;
            Volume = volume;
            Source = source;
        }

        public int Channel { get; set; }
        public int Volume { get; set; }
        public int Source { get; set; }
    }
}