using System;
using System.Collections.Generic;
using System.Text;

namespace DataConect.Utils
{
    public static class Constant
    {
        public static readonly string sqlPacientes = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]";

        public static readonly string sqlPaciente = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]
                                                  where ID ={0}";

        public static readonly string sqlPacienteNombre = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]
                                                  where Nombre  like '%{0}%'";

        public static readonly string sqlPacienteCedula = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]
                                                  where CONVERT(varchar, Cedula) like '%{0}%'";

        public static readonly string sqlPacienteProfesion = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]
                                                  where Profesion  like '%{0}%'";

        public static readonly string sqlPacienteTrabajo = @"SELECT [Id]
                                                      ,[Nombre]
                                                      ,[Cedula]
                                                      ,[Profesion]
                                                      ,[Trabajo]
                                                  FROM [PruebaTecnica].[dbo].[Paciente]
                                                  where Trabajo  like '%{0}%'";
    }
}
