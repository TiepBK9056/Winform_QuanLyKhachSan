using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSanNhom9
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string bin { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public int transferSupported { get; set; }
        public int lookupSupported { get; set; }
        public string short_name { get; set; }
        public int support { get; set; }
        public int isTransfer { get; set; }
        public string swift_code { get; set; }

        public string custom_name
        {
            get
            {
                return $"({bin})({shortName})";
            }
        }
    }

    public class PayQr
    {
        public string code { get; set; }
        public string desc { get; set; }
        public List<Datum> data { get; set; }
    }
}
