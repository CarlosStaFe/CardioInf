using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Agendas:Conexion
    {
        //***** METODO PARA LISTAR LAS AGENDAS *****
        public List<CE_Agendas> ListaAgendas(string fecha)
        {
            List<CE_Agendas> lista = new List<CE_Agendas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Agendas WHERE Fecha = @fecha ORDER BY  Turno ASC, Hora ASC, Minutos ASC, Profesional";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Agendas()
                                {
                                    id_Agda = Convert.ToInt32(dr["id_Agda"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Profesional = dr["Profesional"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Hora = Convert.ToInt32(dr["Hora"]),
                                    Minutos = Convert.ToInt32(dr["Minutos"]),
                                    Turno = Convert.ToInt32(dr["Turno"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"]),
                                    Detalle = dr["Detalle"].ToString(),
                                    NumeroEco = Convert.ToInt32(dr["NumeroEco"]),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
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

        //***** METODO PARA LISTAR LAS AGENDAS DE UN PROFESIONAL *****
        public List<CE_Agendas> AgendaCorta(string prof, string fecha)
        {
            List<CE_Agendas> lista = new List<CE_Agendas>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@prof", prof);
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Agendas WHERE Profesional = @prof AND Fecha = @fecha ORDER BY  Turno ASC, Hora ASC, Minutos ASC, Profesional";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Agendas()
                                {
                                    id_Agda = Convert.ToInt32(dr["id_Agda"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Profesional = dr["Profesional"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Hora = Convert.ToInt32(dr["Hora"]),
                                    Minutos = Convert.ToInt32(dr["Minutos"]),
                                    Turno = Convert.ToInt32(dr["Turno"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"]),
                                    Detalle = dr["Detalle"].ToString(),
                                    NumeroEco = Convert.ToInt32(dr["NumeroEco"]),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
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
            int idAgenda = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Profesional", obj.Profesional);
                        command.Parameters.AddWithValue("_Hora", obj.Hora);
                        command.Parameters.AddWithValue("_Minutos", obj.Minutos);
                        command.Parameters.AddWithValue("_Turno", obj.Turno);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_NumeroEco", obj.NumeroEco);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", DateTime.Now);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idAgenda = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idAgenda = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idAgenda;
        }

        //***** METODO PARA EDITAR UNA AGENDA *****
        public bool Editar(CE_Agendas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Agda", obj.id_Agda);
                        command.Parameters.AddWithValue("_Profesional", obj.Profesional);
                        command.Parameters.AddWithValue("_Hora", obj.Hora);
                        command.Parameters.AddWithValue("_Minutos", obj.Minutos);
                        command.Parameters.AddWithValue("_Turno", obj.Turno);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", DateTime.Now);
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

        //***** METODO PARA ELIMINAR UNA AGENDA *****
        public bool Eliminar(CE_Agendas obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarAgenda", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Agda", obj.id_Agda);
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

        //***** METODO PARA GRABAR EL ESTADO DE LA AGENDA Y NUMERO *****
        public bool ActualizoAgenda(int id, string estado, int numero)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Connection = connection;
                        command.CommandText = "UPDATE Agendas SET Estado = @estado, NumeroEco = @numero WHERE id_Agda = @id";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        //***** METODO PARA GRABAR EL ESTADO DE LA AGENDA *****
        public bool ActualizoEstado(int id, string estado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@estado", estado);
                        command.Connection = connection;
                        command.CommandText = "UPDATE Agendas SET Estado = @estado WHERE id_Agda = @id";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        //***** METODO PARA ELIMINAR UNA AGENDA *****
        public bool BorrarAgda(string fecha, string medico)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.Parameters.AddWithValue("@medico", medico);
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Agendas WHERE Fecha = @fecha AND Profesional = @medico AND Estado = 'LIBRE' ";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

    }
}
