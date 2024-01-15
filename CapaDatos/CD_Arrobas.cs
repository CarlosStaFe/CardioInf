using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Arrobas : Conexion
    {
        //***** METODO PARA LISTAR LAS ARROBAS *****
        public List<CE_Arrobas> ListaArrobas()
        {
            List<CE_Arrobas> lista = new List<CE_Arrobas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Arrobas ORDER BY Detalle";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Arrobas()
                                {
                                    id_Arroba = Convert.ToInt32(dr["id_Arroba"]),
                                    Detalle = dr["Detalle"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Arrobas>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA ARROBA *****
        public int Registrar(CE_Arrobas obj, out string Mensaje)
        {
            int idUsuario = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarArroba", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idUsuario = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idUsuario = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idUsuario;
        }

        //***** METODO PARA EDITAR UNA ARROBA *****
        public bool Editar(CE_Arrobas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarArroba", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Arroba", obj.id_Arroba);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
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

    }
}