using Dapper;
using MySql.Data.MySqlClient;
using PersonaApi2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonaApi2.DAL
{
    public class DoctorDAO
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["hola"].ToString();
        public static Doctor Insertar(Doctor doctor)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("nombre", doctor.Nombre);
                parametros.Add("materno",doctor.Materno);
                parametros.Add("paterno", doctor.Paterno);
                parametros.Add("especialidad", doctor.Especialidad);
                parametros.Add("idhospital", doctor.Hospital.Id);


                conexion.Execute("stp_insertar_doctor", parametros, commandType: CommandType.StoredProcedure);

                //Maestro.IdPersona = parametros.Get<int>("p_id_maestro");
                // doctor.Persona.Id = parametros.Get<int>("p_id_persona");
                return doctor;



            }
        }
        public static int Actualizar(Doctor doctor)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("id_actualizar", doctor.Id);
                parametros.Add("nombre", doctor.Nombre);
                parametros.Add("materno", doctor.Materno);
                parametros.Add("paterno", doctor.Paterno);
                parametros.Add("especialidad", doctor.Especialidad);
                parametros.Add("idhospital", doctor.Hospital.Id);
                conexion.Execute("stp_actualizar_doctor", parametros, commandType: CommandType.StoredProcedure);


                return 1;
            }
        }


        public static int Eliminar(int Id)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    /*Es una lista de parametros*/
                    var parametros = new DynamicParameters();
                    parametros.Add("id_eliminar", Id);

                    conexion.Execute("stp_eliminar_doctor", parametros, commandType: CommandType.StoredProcedure);
                    return 1;
                }
                catch (Exception)
                {

                    return 0;
                }



            }
        }

        public static List<object> ConsultarPorNombre(string busqueda)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                //Cuando es De entrada 
                parametros.Add("busqueda", busqueda);

                return conexion.Query<object>("stp_buscar_doctor_por_nombre", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
        }


        public static List<object> ConsultarTodos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                return conexion.Query<object>("stp_consultar_todo_doctor", commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}