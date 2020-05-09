using MySql.Data.MySqlClient;
using PersonaApi2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace PersonaApi2.DAL
{
    public class PersonaDAO
    {
        private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["hola"].ToString();


        public static List<object> ConsultarTodos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                return conexion.Query<object>("stp_maestro_getall2", commandType : CommandType.StoredProcedure).ToList();
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

                return conexion.Query<object>("stp_maesto_buscar", parametros,commandType: CommandType.StoredProcedure).ToList();
            }
        }
        
        public static Maestro Insertar(Maestro Maestro)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("p_id_maestro", dbType: DbType.Int32, direction:ParameterDirection.Output);
                parametros.Add("p_id_persona", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parametros.Add("p_nombre", Maestro.Persona.Nombre);
                parametros.Add("p_apellidos", Maestro.Persona.Apellidos);
                parametros.Add("p_fecha_nacimiento", Maestro.Persona.FechaNacimiento);
                parametros.Add("p_sexo", Maestro.Persona.Sexo);
                parametros.Add("p_folio", Maestro.Folio);
                parametros.Add("p_asignatura", Maestro.Asignatura);
                parametros.Add("p_salario", Maestro.Salario);


                conexion.Execute("stp_mestro_insertar", parametros,commandType: CommandType.StoredProcedure);

                return Maestro;
                 
                
               
            }
        }

        public static int Actualizar(Maestro Maestro)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                /*Es una lista de parametros*/
                var parametros = new DynamicParameters();
                parametros.Add("p_id_a_actualizar", Maestro.IdPersona);
                parametros.Add("p_nombre", Maestro.Persona.Nombre);
                parametros.Add("p_apellidos", Maestro.Persona.Apellidos);
                parametros.Add("p_fecha_nacimiento", Maestro.Persona.FechaNacimiento);
                parametros.Add("p_sexo", Maestro.Persona.Sexo);
                parametros.Add("p_folio", Maestro.Folio);
                parametros.Add("p_asignatura", Maestro.Asignatura);
                parametros.Add("p_salario", Maestro.Salario);
                conexion.Execute("stp_mestro_actualizar", parametros, commandType: CommandType.StoredProcedure);

                
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
                    parametros.Add("id_a_eliminar", Id);

                    conexion.Execute("stp_maestro_eliminar", parametros, commandType: CommandType.StoredProcedure);
                    return 1;
                }
                catch (Exception)
                {

                    return 0;
                }
               

                
            }
        }
    }
}