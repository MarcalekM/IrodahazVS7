using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irodahaz240112;

namespace Irodahaz240112
{
    internal class Iroda
    {
        public string _kod;
        public string _kezdDatum;
        public List<int> _letszamok;

        public Iroda(string sor)
        {
            var v = sor.Split(' ').ToList();
            _kod = v[0];
            _kezdDatum = v[1];
            _letszamok = new List<int>();
            for (int i = 2; i < v.Count; i++)
            {
                _letszamok.Add(int.Parse(v[i]));
            }

        }
        public override string ToString()
        {
            string text = string.Empty;
            text += _kod + "\t";
            if (_kod.Length < 8) text += "\t";
            text += _kezdDatum + "\t";
            for (int i = 0; i < _letszamok.Count; i++)
            {
                text += _letszamok[i].ToString() + "\t";
            }
            return text;
        }
    }

}
