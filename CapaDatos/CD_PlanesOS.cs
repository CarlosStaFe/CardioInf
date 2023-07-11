using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
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
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM PlanesOS ORDER BY OSPlan";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

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
                                    FecEstado = Convert.ToDateTime(dr["FecEstado"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
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
                using (var command = new SqlCommand("SP_RegistrarPlanOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("OSPlan", obj.OSPlan);
                        command.Parameters.AddWithValue("NombrePlan", obj.NombrePlan);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idValor = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
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
                using (var command = new SqlCommand("SP_EditarPlanOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Plan", obj.id_Plan);
                        command.Parameters.AddWithValue("OSPlan", obj.OSPlan);
                        command.Parameters.AddWithValue("NombrePlan", obj.NombrePlan);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
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
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@nombreOS", nombreOS);
                        command.CommandText = "SELECT * FROM PlanesOS WHERE OSPlan = @nombreOS AND Estado = 'ACTIVO' ";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

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
