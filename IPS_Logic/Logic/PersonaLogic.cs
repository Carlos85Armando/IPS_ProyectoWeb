using IPS_Entity.Entity;
using IPS_Logic.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS_Logic.Logic
{
    public class PersonaLogic
    {
        ProyectoIPSDataBaseContext proyectoIPSDataBaseContext = new ProyectoIPSDataBaseContext();
        public List<PersonaEntity> ObtenerTosasLasPersonas()
        {
            List<PersonaEntity> ListPersonEntites = new List<PersonaEntity>();
            var ListPersonaDataBase = proyectoIPSDataBaseContext.Personas.ToList();
            foreach(var personaDataBase in ListPersonaDataBase)
            {
                PersonaEntity personaEntity = new PersonaEntity();
                personaEntity.Id = personaDataBase.Id;
                personaEntity.Nombre = personaDataBase.Nombre;
                personaEntity.Apellidos = personaDataBase.Apellidos;
                personaEntity.Cedula = personaDataBase.Cedula;
                personaEntity.Contraseña = personaDataBase.Contraseña;

                ListPersonEntites.Add(personaEntity);

            }
            return ListPersonEntites;
        }
        public PersonaEntity AdiccionarPersona(PersonaEntity personaEntity)
        {
            try
            {

            
            if(ObtenerTosasLasPersonas().Where(x => x.Cedula == personaEntity.Cedula).Any())
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Mensaje = "Ya existe un usuario con la cedula " + personaEntity.Cedula;
                persona.Type = "danger";
                return persona;

            }
                


            proyectoIPSDataBaseContext.Personas.Add(ConvertirPersonaEntityAPersonaDateBase(personaEntity));
            proyectoIPSDataBaseContext.SaveChanges();
            personaEntity.Mensaje = personaEntity.Cedula + " se guado con exito";
            personaEntity.Type = "success";
                return personaEntity;
            }
            catch(Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Mensaje = "Ya existe un usuarion con esa cedula";
                persona.Type = "danger";
                return persona;

            }
        }

       

        public PersonaEntity TraerUnaPersonaPorElID (string cedula)
        {
           var personaEntity= ObtenerTosasLasPersonas().Where(x => x.Cedula == cedula).FirstOrDefault();
            if (personaEntity==null)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Mensaje = "No existe una persona con esta cedula";
                persona.Type = "danger";
                return persona;

            }
            return personaEntity;
        }

        public PersonaEntity UpDatePersona(PersonaEntity personaEntity)
        {
            try
            {
                var personaDataBase = proyectoIPSDataBaseContext.Personas.Where(x => x.Cedula == personaEntity.Cedula).FirstOrDefault();

                if (personaDataBase==null)
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.Mensaje = "No existe una persona con cedula " + personaEntity.Cedula;
                    persona.Type = "danger";
                    return persona;

                }
                personaDataBase.Cedula = personaEntity.Cedula;
                personaDataBase.Id = personaEntity.Id;
                personaDataBase.Nombre = personaEntity.Nombre;
                personaDataBase.Apellidos = personaEntity.Apellidos;
                personaDataBase.Contraseña = personaEntity.Contraseña;

                proyectoIPSDataBaseContext.Personas.Update(personaDataBase);
                proyectoIPSDataBaseContext.SaveChanges();
                personaEntity.Mensaje = personaEntity.Cedula + " Los datos fueron actualizados correctamente";
                personaEntity.Type = "success";
                return personaEntity;
            }
            catch (Exception ex)
            {
                PersonaEntity persona = new PersonaEntity();
                persona.Mensaje = "No existe un usuarion con esa cedula";
                persona.Type = "danger";
                return persona;

            }


        }
        public Persona ConvertirPersonaEntityAPersonaDateBase(PersonaEntity personaEntity)
        {
            Persona persona = new Persona();

            persona.Id = personaEntity.Id;
            persona.Nombre = personaEntity.Nombre;
            persona.Apellidos = personaEntity.Apellidos;
            persona.Cedula = personaEntity.Cedula;
            persona.Contraseña = personaEntity.Contraseña;
            return persona;
        }

        public PersonaEntity EliminarPersonaPorCedula(string cedula)
        {
              var personaDataBase = proyectoIPSDataBaseContext.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();

                if (personaDataBase == null)
                {
                    PersonaEntity persona = new PersonaEntity();
                persona.Mensaje = "No existe una persona con cedula ";
                    persona.Type = "danger";
                return persona;

            }
            return new PersonaEntity();
        }



    }
}
