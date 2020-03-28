using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Behavior.Model
{
 
    public class Paciente
    {
        
        public int Id { set; get; }
        public string Nombre { set; get; }
        public int Cedula { set; get; }
        public string Profesion { set; get; }
        public string Trabajo { set; get; }
    }
}
