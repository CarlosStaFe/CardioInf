using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Historias:Conexion
    {
        //***** METODO PARA LISTAR LAS HISTORIAS *****
        public List<CE_Historias> ListaHistorias(int idpcte)
        {
            List<CE_Historias> lista = new List<CE_Historias>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", idpcte);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Historias WHERE idPcte = @id ORDER BY Fecha ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Historias()
                                {
                                    id_His = Convert.ToInt32(dr["id_His"]),
                                    idPcte = Convert.ToInt32(dr["idPcte"]),
                                    NroDoc = Convert.ToInt32(dr["NroDoc"]),
                                    NombreCompleto = dr["NombreCompleto"].ToString(),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Medico = dr["Medico"].ToString(),
                                    Comentario = dr["Comentario"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_Historias>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA HISTORIA *****
        public int Registrar(CE_Historias obj, out string Mensaje)
        {
            int idHisto = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarHistoria", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_idPcte", obj.idPcte);
                        command.Parameters.AddWithValue("_NroDoc", obj.NroDoc);
                        command.Parameters.AddWithValue("_NombreCompleto", obj.NombreCompleto);
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Medico", obj.Medico);
                        command.Parameters.AddWithValue("_Comentario", obj.Comentario);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idHisto = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idHisto = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idHisto;
        }

        //***** METODO PARA ELIMINAR LA HISTORIA *****
        public bool Eliminar(CE_Historias obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarHistoria", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_His", obj.id_His);
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
