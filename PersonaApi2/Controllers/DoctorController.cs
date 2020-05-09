using PersonaApi2.DAL;
using PersonaApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PersonaApi2.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("ronaal/final/doctor")]
    public class DoctorController : ApiController
    {
        [HttpPost]
        [Route("insert")]
        public HttpResponseMessage Insertar([FromBody] Doctor doctor)
        {
            try
            {
                var personaCreada = DoctorDAO.Insertar(doctor);
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
        public HttpResponseMessage Actualizar([FromBody] Doctor doctor)
        {
            try
            {
                var personaCreada = DoctorDAO.Actualizar(doctor);
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


        [HttpGet]
        [Route("getAll")]
        public HttpResponseMessage ObternerTodos()
        {
            try
            {
                var personas = DoctorDAO.ConsultarTodos();
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
                var personas = DoctorDAO.ConsultarPorNombre(nombre);
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
                var personas = DoctorDAO.Eliminar(id);
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
    }
}