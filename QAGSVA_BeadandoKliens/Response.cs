using System.Collections.Generic;

namespace QAGSVA_BeadandoKliens
{
    internal class Response
    {
        public int error { get; set; }
        public string message { get; set; }
        public List<User> Users { get; set; }
    }
}
