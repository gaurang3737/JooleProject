using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service.Models
{
    public class Product
    {
        public int Pid { get; set; }
        public int Mid { get; set; }
        public int Subcatid { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
    }


}
