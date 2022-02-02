namespace Shared.Models
{
    public class Tele
    {
        public Tele()
        {
        }

        public Tele(int id, int channel, int volume, int source)
        {
            Id = id;
            Channel = channel;
            Volume = volume;
            Source = source;
        }

        public int Id { get; set; }
        public int Channel { get; set; }
        public int Volume { get; set; }
        public int Source { get; set; }
    }
}