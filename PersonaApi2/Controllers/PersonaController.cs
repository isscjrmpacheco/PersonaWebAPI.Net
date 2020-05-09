using PersonaApi2.DAL;
using PersonaApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PersonaApi2.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("ronaal/examen/maestro")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage ObternerTodos()
        {
            try
            {
                var personas = PersonaDAO.ConsultarTodos();
                return Request.CreateResponse(HttpStatusCode.OK, personas);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });
            }


        }


        [HttpGet]
        [Route("searchByName/{nombre}")]
        public HttpResponseMessage BuscarPorNombre([FromUri] string nombre)
        {
            try
            {
                var personas = PersonaDAO.ConsultarPorNombre(nombre);
                if (personas != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, personas);
                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        Mensaje = $"No se encontro la persona con id {nombre}"
                    });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });
            }
        }



        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Eiminar([FromUri] int id)
        {
            try
            {
                var personas = PersonaDAO.Eliminar(id);
                if (personas == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, personas);
                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        Mensaje = $"No se encontro la persona con id {id}"
                    });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });
            }
        }



        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insertar([FromBody] Maestro persona)
        {
            try
            {
                var personaCreada = PersonaDAO.Insertar(persona);
                return Request.CreateResponse(HttpStatusCode.OK, personaCreada);
            }
            catch (Exception ex)
            {

                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Actualizar([FromBody] Maestro persona)
        {
            try
            {
                var personaCreada = PersonaDAO.Actualizar(persona);
                return Request.CreateResponse(HttpStatusCode.OK, personaCreada);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Mensaje = ex.Message
                });
            }
        }

    }
}
