using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAGSVA_BeadandoKliens
{
    internal class DriveResponse
    {
        public int error { get; set; }
        public string message { get; set; }
        public List<Drive> Lessons { get; set; }
    }
}
