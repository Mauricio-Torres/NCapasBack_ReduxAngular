using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Behavior.Model
{
    public class PacienteInput
    {
        public int Id { set; get; }
        public string Nombre { set; get; }
        public int Cedula { set; get; }
        public string Profesion { set; get; }
        public string Trabajo { set; get; }
    }
}
