using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_PlanesOS:Conexion
    {
        //***** METODO PARA LISTAR LOS PANES DE OBRAS SOCIALES *****
        public List<CE_PlanesOS> ListaPlanes()
        {
            List<CE_PlanesOS> lista = new List<CE_PlanesOS>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM PlanesOS ORDER BY OSPlan";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_PlanesOS()
                                {
                                    id_Plan = Convert.ToInt32(dr["id_Plan"]),
                                    OSPlan = dr["OSPlan"].ToString(),
                                    NombrePlan = dr["NombrePlan"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_PlanesOS>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN PLAN DE OS *****
        public int Registrar(CE_PlanesOS obj, out string Mensaje)
        {
            int idValor = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarPlanOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_OSPlan", obj.OSPlan);
                        command.Parameters.AddWithValue("_NombrePlan", obj.NombrePlan);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idValor = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idValor = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idValor;
        }

        //***** METODO PARA EDITAR UN PLAN DE OS *****
        public bool Editar(CE_PlanesOS obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarPlanOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Plan", obj.id_Plan);
                        command.Parameters.AddWithValue("_OSPlan", obj.OSPlan);
                        command.Parameters.AddWithValue("_NombrePlan", obj.NombrePlan);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        Mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }

        //***** METODO PARA BUSCAR PLANES DE UNA OBRA SOCIAL *****
        public List<CE_PlanesOS> ListaPlan(string nombreOS, out string mensaje)
        {
            List<CE_PlanesOS> lista = new List<CE_PlanesOS>();

            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@nombreOS", nombreOS);
                        command.CommandText = "SELECT * FROM PlanesOS WHERE OSPlan = @nombreOS AND Estado = 'ACTIVO' ";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_PlanesOS()
                                {
                                    NombrePlan = dr["NombrePlan"].ToString(),
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_PlanesOS>();
                    }
                    return lista;
                }
            }
        }


    }
}
