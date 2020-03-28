using Behavior.Model;
using System.Collections.Generic;

namespace Behavior.Interfas
{
    public interface IPacienteRepositorio
    {
        List<Paciente> GetPacientes();
        Paciente GetPaciente(int idPaciente);
        List<Paciente> FindPaciente(Paciente obj);
        void Update(Paciente paciente);
        void Insert(Paciente paciente);
        void Delet(int idPaciente);
    }
}
