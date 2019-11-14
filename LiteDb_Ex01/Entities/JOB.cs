using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDb_Ex01.Entities
{
    class JOB
    {
        public int Id { get; set; }
        public string islem_adi { get; set; }
        public string islem_icerik { get; set; }
        public string islem_saat { get; set; }
        public bool durum { get; set; }
      
    }
}
