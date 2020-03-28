using Behavior.Interfas;
using Behavior.Model;
using DataConect.Utils;
using PruebaTecnica.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataConect.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly DataContext _context;
        public PacienteRepositorio(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<Paciente> FindPaciente(Paciente obj)
        {
            List<Paciente> paciente;

            if (!string.IsNullOrEmpty(obj.Nombre)) 
            {
                var sSQLNombre = string.Format(Constant.sqlPacienteNombre, obj.Nombre);
                var tablePacientesNombre = _context.GetEntity(sSQLNombre).AsEnumerable().AsQueryable();
                if (tablePacientesNombre != null)
                {
                    paciente = (from bp in tablePacientesNombre
                                select new Paciente()
                                {
                                    Id = bp.Field<int>("Id"),
                                    Cedula = bp.Field<int>("Cedula"),
                                    Nombre = bp.Field<string>("Nombre"),
                                    Profesion = bp.Field<string>("Profesion"),
                                    Trabajo = bp.Field<string>("Trabajo"),
                                }).ToList();
                    return paciente;
                }
            }

            if (obj.Cedula > 0)
            {
                var sSQLCedula = string.Format(Constant.sqlPacienteCedula, obj.Cedula);
                var tablePacientesCedula = _context.GetEntity(sSQLCedula).AsEnumerable().AsQueryable();
                if (tablePacientesCedula != null)
                {
                    paciente = (from bp in tablePacientesCedula
                                select new Paciente()
                                {
                                    Id = bp.Field<int>("Id"),
                                    Cedula = bp.Field<int>("Cedula"),
                                    Nombre = bp.Field<string>("Nombre"),
                                    Profesion = bp.Field<string>("Profesion"),
                                    Trabajo = bp.Field<string>("Trabajo"),
                                }).ToList();
                    return paciente;
                }
            }
            if (!string.IsNullOrEmpty(obj.Profesion))
            {
                var sSQLProfesion = string.Format(Constant.sqlPacienteProfesion, obj.Profesion);
                var tablePacientesProfesion = _context.GetEntity(sSQLProfesion).AsEnumerable().AsQueryable();
                if (tablePacientesProfesion != null)
                {
                    paciente = (from bp in tablePacientesProfesion
                                select new Paciente()
                                {
                                    Id = bp.Field<int>("Id"),
                                    Cedula = bp.Field<int>("Cedula"),
                                    Nombre = bp.Field<string>("Nombre"),
                                    Profesion = bp.Field<string>("Profesion"),
                                    Trabajo = bp.Field<string>("Trabajo"),
                                }).ToList();
                    return paciente;
                }
            }
            if (!string.IsNullOrEmpty(obj.Trabajo))
            {
                var sSQLTrabajo = string.Format(Constant.sqlPacienteTrabajo, obj.Trabajo);
                var tablePacientesTrabajo = _context.GetEntity(sSQLTrabajo).AsEnumerable().AsQueryable();
                if (tablePacientesTrabajo != null)
                {
                    paciente = (from bp in tablePacientesTrabajo
                                select new Paciente()
                                {
                                    Id = bp.Field<int>("Id"),
                                    Cedula = bp.Field<int>("Cedula"),
                                    Nombre = bp.Field<string>("Nombre"),
                                    Profesion = bp.Field<string>("Profesion"),
                                    Trabajo = bp.Field<string>("Trabajo"),
                                }).ToList();
                    return paciente;
                }
            }
            return GetPacientes();
        }
        public Paciente GetPaciente(int idPaciente)
        {
            var sSQL = string.Format(Constant.sqlPaciente, idPaciente);

            var tablePacientes = _context.GetEntity(sSQL).AsEnumerable().AsQueryable();

            var paciente = (from bp in tablePacientes
                            select new Paciente()
                          {
                              Id = bp.Field<int>("Id"),
                              Cedula = bp.Field<int>("Cedula"),
                              Nombre = bp.Field<string>("Nombre"),
                              Profesion = bp.Field<string>("Profesion"),
                              Trabajo = bp.Field<string>("Trabajo"),
                          }).FirstOrDefault();

            return paciente;
        }

        public List<Paciente> GetPacientes()
        {
            try
            {
                var tablePacientes = _context.GetEntity(Constant.sqlPacientes).AsEnumerable().AsQueryable();

                var pacientes = (from bp in tablePacientes
                                select new Paciente()
                                {
                                    Id = bp.Field<int>("Id"),
                                    Cedula = bp.Field<int>("Cedula"),
                                    Nombre = bp.Field<string>("Nombre"),
                                    Profesion = bp.Field<string>("Profesion"),
                                    Trabajo = bp.Field<string>("Trabajo"),
                                }).ToList();

                return pacientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Insert(Paciente paciente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Paciente] ([Nombre],[Cedula] ,[Profesion] ,[Trabajo])");
            sb.Append("VALUES ");
            sb.Append("(");
            sb.Append("@Nombre, ");
            sb.Append("@Cedula, ");
            sb.Append("@Profesion, ");
            sb.Append("@Trabajo");
            sb.Append(")");

            var listProperty = GenericPropertyEntity<Paciente>.PrintTModelProperty(paciente);

            _context.ExecuteQuery(listProperty, sb.ToString());
        }
        public void Update (Paciente paciente)
        {
            if (ExistePaciente(paciente.Id))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Update Paciente SET ");
                sb.Append("[Nombre]=@Nombre, ");
                sb.Append("[Cedula]=@Cedula, ");
                sb.Append("[Profesion]=@Profesion, ");
                sb.Append("[Trabajo]=@Trabajo ");
                sb.Append("WHERE Id=@Id");

                var listProperty = GenericPropertyEntity<Paciente>.PrintTModelProperty(paciente);
                _context.ExecuteQuery(listProperty, sb.ToString());
            }        
        }
        public void Delet(int idPaciente)
        {
            if (ExistePaciente(idPaciente))
            {
                var sql = string.Format("DELETE FROM [dbo].[Paciente] WHERE Id = {0}", idPaciente);
                _context.ExecuteQuery(sql);
            }
        }

        private bool ExistePaciente(int idPaciente) 
        {
            var sSQL = string.Format(Constant.sqlPaciente, idPaciente);
            var tablePacientes = _context.GetEntity(sSQL).AsEnumerable().AsQueryable().FirstOrDefault();

            return tablePacientes != null;
        }
    }
}
