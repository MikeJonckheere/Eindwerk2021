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
