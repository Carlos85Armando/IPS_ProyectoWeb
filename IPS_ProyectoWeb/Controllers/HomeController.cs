using IPS_Entity.Entity;
using IPS_Logic.Logic;
using IPS_ProyectoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PersonaLogic personaLogic = new PersonaLogic();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string nombre="")
        {
            List<PersonaEntity> listPersonaEntities = new List<PersonaEntity>();
            if (string.IsNullOrEmpty(nombre))
            {
                listPersonaEntities = personaLogic.ObtenerTosasLasPersonas();
            }
            else
            {
                listPersonaEntities = personaLogic.ObtenerTosasLasPersonas().Where(x => x.Apellidos.ToUpper().Contains(nombre.ToUpper())).ToList();
            }

            return View(listPersonaEntities);
        }

        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonaEntity personaEntity)
        {

            var persona = personaLogic.AdiccionarPersona(personaEntity);
            ViewBag.Mensaje = persona.Mensaje;
            ViewBag.Type = persona.Type;
            return View(personaEntity);
        }

        public IActionResult Edit(string cedula)
        {

            var persona = personaLogic.TraerUnaPersonaPorElID(cedula);
            ViewBag.Mensaje = persona.Mensaje;
            ViewBag.Type = persona.Type;
            return View(persona);
        }

        [HttpPost]
        public IActionResult Edit(PersonaEntity personaEntity)
        {

            var persona = personaLogic.UpDatePersona(personaEntity);
            ViewBag.Mensaje = persona.Mensaje;
            ViewBag.Type = persona.Type;
            return View(personaEntity);
        }

        public IActionResult Delete(string cedula)
        {

            var persona = personaLogic.EliminarPersonaPorCedula(cedula);
            ViewBag.Mensaje = persona.Mensaje;
            ViewBag.Type = persona.Type;
            return View(persona);
        }

    }
}
