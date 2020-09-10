using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class MyModel
    {
       

            public int Id { get; set; }
            public string odDatuma { get; set; }
            public string doDatuma { get; set; }
            public string naseljenoMesto { get; set; }
            public int cenaOd { get; set; }
            public int cenaDo { get; set; }
            public int sobaOd { get; set; }
            public int sobaDo { get; set; }
            public int osoba { get; set; }
            public string tip { get; set; }
            public bool status { get; set; }
            public string[] sadrzaj { get; set; }
            public string sort { get; set; }
        
    }
}