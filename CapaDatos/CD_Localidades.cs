using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Localidades:Conexion
    {
        //***** METODO PARA LISTAR LAS LOCALIDADES *****
        public List<CE_Localidades> ListaLocalidades()
        {
            List<CE_Localidades> lista = new List<CE_Localidades>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spListaLocalidades";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Localidades()
                                {
                                    id_Local = Convert.ToInt32(dr["id_Local"]),
                                    fk_Depto = Convert.ToInt32(dr["fk_Deptos"]),
                                    fk_Prov = Convert.ToInt32(dr["fk_Prov"]),
                                    Localidad = dr["Localidad"].ToString(),
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Localidades>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA LOCALIDAD *****
        public int Registrar(CE_Localidades obj, out string Mensaje)
        {
            int idLocal = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarLocalidad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_fk_Depto", obj.fk_Depto);
                        command.Parameters.AddWithValue("_fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("_Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idLocal = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idLocal = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idLocal;
        }

        //***** METODO PARA EDITAR UNA LOCALIDAD *****
        public bool Editar(CE_Localidades obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarLocalidad", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Local", obj.id_Local);
                        command.Parameters.AddWithValue("_fk_Deptos", obj.fk_Depto);
                        command.Parameters.AddWithValue("_fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("_Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
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

        //***** METODO PARA LISTAR LAS LOCALIDADES PARA UN COMBO *****
        public List<CE_Localidades> ListaLocal()
        {
            List<CE_Localidades> lista = new List<CE_Localidades>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT DISTINCT Localidad, id_Local FROM Localidades ORDER BY Localidad ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Localidades()
                                {
                                    id_Local = Convert.ToInt32(dr["id_Local"].ToString()),
                                    Localidad = dr["Localidad"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Localidades>();
                    }
                }
            }
            return lista;
        }

    }
}
