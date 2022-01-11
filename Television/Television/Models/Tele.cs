using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Television.Models
{
    class Tele
    {
        public int SettingsChannel { get; set; }
        public int SettingsVolume { get; set; }
        public int SettingsSource { get; set; }

        public void FillTele(int settingsChannel, int settingsVolume, int settingsSource)
        {
            this.SettingsChannel = settingsChannel;
            this.SettingsVolume = settingsVolume;
            this.SettingsSource = settingsSource;
        }
    }
}
