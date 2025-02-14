﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsMenage.Models
{
    internal class Item
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Typ { get; set; }
        public int Rok { get; set; }
        public Item(string tytul, string autor, string typ, int rok)
        {
            Tytul = tytul;
            Autor = autor;
            Typ = typ;
            Rok = rok;
        }
        public Item() { }
    }
}
