using System;
using System.Collections.Generic;
using System.Text;

namespace Remote.Models
{
    public class RemoteControl
    {
        public int Channel { get; set; }
        public int Volume { get; set; }
        public int Source { get; set; }

        public void FillRemote(int channel, int volume, int source)
        {
            Channel = channel;
            Volume = volume;
            Source = source;
        }

    }
}
