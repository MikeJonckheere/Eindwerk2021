using Remote.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remote.Program
{
    class ProgRemote
    {
        static sqlRepository repo = new sqlRepository();

        //static string channel = "1";
        //public void keypad(string input) //input van keypad.
        //{



        //    //channel = channel + string.Join("", input.Where(o => !string.IsNullOrEmpty(o)));



        //}

        //public static void send()
        //{
        //    //var NewChannel = new Channel();
        //}

        public void ListValues()
        {
            var remote = repo.GetCurrentValues();
        
        }
    }
}
