using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_HistoriasOld:Conexion
    {
        //***** METODO PARA LISTAR LAS HISTORIAS VIEJAS *****
        public List<CE_HistoriasOld> ListaHistorias()
        {
            List<CE_HistoriasOld> lista = new List<CE_HistoriasOld>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        //command.Parameters.AddWithValue("@id", idpcte);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM HistoriasOld ORDER BY ApelNombres ASC, Fecha";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_HistoriasOld()
                                {
                                    id_His = Convert.ToInt32(dr["id_His"]),
                                    idPaciente = Convert.ToInt32(dr["idPaciente"]),
                                    Documento = Convert.ToInt32(dr["Documento"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    Medico = dr["Medico"].ToString(),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Comentario = dr["Comentario"].ToString(),
                                    Adjunto = dr["Adjunto"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_HistoriasOld>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA ELIMINAR LA HISTORIA VIEJA *****
        public bool Eliminar(CE_HistoriasOld obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarHistoriaOld", connection))
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
