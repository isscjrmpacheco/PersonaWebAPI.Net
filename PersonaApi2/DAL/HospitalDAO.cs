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
    public class HospitalDAO
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["hola"].ToString();
        public static Hospital Insertar(Hospital hospital)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("nombre", hospital.Nombre);
                parametros.Add("horario", hospital.Horario);
                parametros.Add("ubicacion", hospital.Ubicacion);
                parametros.Add("telefono", hospital.Telefono);
                parametros.Add("direccion", hospital.Direccion);
                parametros.Add("logo", hospital.Logo);


                conexion.Execute("stp_insert_hospital", parametros, commandType: CommandType.StoredProcedure);

               
                return hospital;



            }
        }
        public static int Actualizar(Hospital hospital)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("id_actualizar", hospital.Id);
                parametros.Add("nombre", hospital.Nombre);
                parametros.Add("horario", hospital.Horario);
                parametros.Add("ubicacion", hospital.Ubicacion);
                parametros.Add("telefono", hospital.Telefono);
                parametros.Add("direccion", hospital.Direccion);
                parametros.Add("logo", hospital.Logo);
                conexion.Execute("stp_actualizar_hospital", parametros, commandType: CommandType.StoredProcedure);


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

                    conexion.Execute("stp_eliminar_hospital", parametros, commandType: CommandType.StoredProcedure);
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

                return conexion.Query<object>("stp_buscar_hospital_por_nombre", parametros, commandType: CommandType.StoredProcedure).ToList();
            }
        }


        public static List<object> ConsultarTodos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                return conexion.Query<object>("stp_consultar_todo_hospital", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}