using Behavior.Interfas;
using Behavior.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Behavior.Manager
{
    public class PacienteManager
    {

        IPacienteRepositorio _pacienteRepositorio;
        public PacienteManager(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }


        public PacienteOutput GetPaciente(int idPaciente) 
        {
            try
            {

                var paciente = _pacienteRepositorio.GetPaciente(idPaciente);
                if (paciente != null) 
                {
                    var pacienteOutput = new PacienteOutput()
                    {
                        Cedula = paciente.Cedula,
                        Id = paciente.Id,
                        Nombre = paciente.Nombre,
                        Profesion = paciente.Profesion,
                        Trabajo = paciente.Trabajo,
                    };
                    return pacienteOutput;
                }
              
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PacienteOutput> FindPaciente(PacienteInput paciente)
        {
            try
            {
                var pacienteInp = new Paciente()
                {
                    Id = paciente.Id,
                    Cedula = paciente.Cedula,
                    Nombre = paciente.Nombre,
                    Profesion = paciente.Profesion,
                    Trabajo = paciente.Trabajo,
                };

                var listPacienteO = _pacienteRepositorio.FindPaciente(pacienteInp);

                List<PacienteOutput> pacienteOutputs = new List<PacienteOutput>();

                foreach (var pacienteO in listPacienteO) 
                {
                    pacienteOutputs.Add(new PacienteOutput()
                    {
                        Cedula = pacienteO.Cedula,
                        Id = pacienteO.Id,
                        Nombre = pacienteO.Nombre,
                        Profesion = pacienteO.Profesion,
                        Trabajo = pacienteO.Trabajo,
                    });
                }
              
                return pacienteOutputs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PacienteOutput> GetPacientes()
        {
            try
            {

                var pacientes = _pacienteRepositorio.GetPacientes();
                var listPacientes = new List<PacienteOutput>();

                foreach (var paciente in pacientes) {
                  
                    listPacientes.Add(new PacienteOutput()
                    {
                        Cedula = paciente.Cedula,
                        Id = paciente.Id,
                        Nombre = paciente.Nombre,
                        Profesion = paciente.Profesion,
                        Trabajo = paciente.Trabajo,
                    });
                };

                return listPacientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(PacienteInput paciente)
        {
            try
            {
                var pacienteOutput = new Paciente()
                {
                    Id = paciente.Id,
                    Cedula = paciente.Cedula,
                    Nombre = paciente.Nombre,
                    Profesion = paciente.Profesion,
                    Trabajo = paciente.Trabajo,
                };

                 _pacienteRepositorio.Update(pacienteOutput);
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(PacienteInput paciente)
        {
            try
            {
                var pacienteOutput = new Paciente()
                {
                    Cedula = paciente.Cedula,
                    Nombre = paciente.Nombre,
                    Profesion = paciente.Profesion,
                    Trabajo = paciente.Trabajo,
                };

                _pacienteRepositorio.Insert(pacienteOutput);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(int IdPaciente)
        {
            try
            {
                _pacienteRepositorio.Delet(IdPaciente);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
