using Behavior.Manager;
using Behavior.Model;
using DataConect.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteManager _context;

        public PacientesController(PacienteManager context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        [Route("/paciente")]
        public PacienteOutput GetPaciente(int idPaciente)
        {
            try
            {                
                var paciente = _context.GetPaciente(idPaciente);

                return paciente;
            }
            catch (Exception ex)
            {
                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }

            return null;
        }

        [HttpGet]
        [Route("/pacientes")]
        public List<PacienteOutput> GetPacientes()
        {
            try
            {
                var paciente = _context.GetPacientes();

                return paciente;
            }
            catch (Exception ex)
            {

                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }
            return null;
        }

        [HttpPost]
        [Route("/cambiarPaciente")]
        public void UpdatePacientes(PacienteInput paciente)
        {
            try
            {
                _context.Update(paciente);
            }
            catch (Exception ex)
            {
                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }
        }

        [HttpPost]
        [Route("/buscarPaciente")]
        public List<PacienteOutput> FindPacientes(PacienteInput paciente)
        {
            try
            {
                return _context.FindPaciente(paciente);
            }
            catch (Exception ex)
            {
                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }
            return null;

        }
        [HttpPost]
        [Route("/ingresarPaciente")]
        public void InsertPacientes(PacienteInput paciente)
        {
            try
            {
                _context.Insert(paciente);
            }
            catch (Exception ex)
            {
                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }
        }
        [HttpDelete]
        [Route("/borrarPaciente")]
        public void DeletePacientes(int idPaciente)
        {
            try
            {
                _context.Delete(idPaciente);
            }
            catch (Exception ex)
            {
                Logger.Logguer(System.Reflection.MethodBase.GetCurrentMethod().Name, "Exception ", ex.Message);
            }
        }
    }
    public class Menu
    {
        public string titulo { set; get; }
        public string icono { set; get; }
        public string path { set; get; }
    }
}
