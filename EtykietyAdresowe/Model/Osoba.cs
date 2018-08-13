using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtykietyAdresowe.Model
{
    public class Osoba
    {
        public int Nip;
        public int Pesel;
        public string Imie;
        public string Nazwisko;
        public string Adres;
        public string Miasto;
        public Osoba(int nip, int pesel)
        {
                    Nip = nip;
                    Pesel = pesel;
        }
    }
}
