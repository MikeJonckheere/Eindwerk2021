using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Television.Models
{
    class Tele
    {
        public int Channel { get; set; }
        public int Volume { get; set; }
        public int Source { get; set; }

        public void FillTele(int channel, int volume, int source)
        {
            this.Channel = channel;
            this.Volume = volume;
            this.Source = source;
        }
    }
}
