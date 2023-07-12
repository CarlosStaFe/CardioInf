using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Agendas:Conexion
    {
        //***** METODO PARA LISTAR LAS AGENDAS *****
        public List<CE_Agendas> ListaAgendas()
        {
            List<CE_Agendas> lista = new List<CE_Agendas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Agendas ORDER BY Fecha, Profesional";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Agendas()
                                {
                                    id_Agda = Convert.ToInt32(dr["id_Agda"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Profesional = dr["Profesional"].ToString(),
                                    Turno = Convert.ToInt32(dr["Turno"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"]),
                                    NumeroEco = Convert.ToInt32(dr["NumeroEco"]),
                                    Detalle = dr["Detalle"].ToString(),
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
                        lista = new List<CE_Agendas>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA AGENDA *****
        public int Registrar(CE_Agendas obj, out string Mensaje)
        {
            int idUsuario = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Fecha", DateTime.Now);
                        command.Parameters.AddWithValue("Profesional", obj.Profesional);
                        command.Parameters.AddWithValue("Turno", obj.Turno);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("NumeroEco", obj.NumeroEco);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", DateTime.Now);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idUsuario = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
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

        //***** METODO PARA EDITAR UNA AGENDA *****
        public bool Editar(CE_Agendas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Agda", obj.id_Agda);
                        command.Parameters.AddWithValue("Fecha", DateTime.Now);
                        command.Parameters.AddWithValue("Profesional", obj.Profesional);
                        command.Parameters.AddWithValue("Turno", obj.Turno);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("NumeroEco", obj.NumeroEco);
                        command.Parameters.AddWithValue("Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", DateTime.Now);
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

        //***** METODO PARA ELIMINAR UNA AGENDA *****
        public bool Eliminar(CE_Agendas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EliminarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Agda", obj.id_Agda);
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

    }
}
