using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Planificacion:Conexion
    {
        //***** METODO PARA LISTAR LA PLANIFICACION *****
        public List<CE_Planificacion> ListaPlan(string fechaplan)
        {
            List<CE_Planificacion> lista = new List<CE_Planificacion>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", fechaplan);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Planificacion WHERE Fecha = @fecha";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Planificacion()
                                {
                                    id_Plan = Convert.ToInt32(dr["id_Plan"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Medico = dr["Medico"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    DesdeHr = dr["DesdeHr"].ToString(),
                                    DesdeMin = dr["DesdeMin"].ToString(),
                                    HastaHr = dr["HastaHr"].ToString(),
                                    HastaMin = dr["HastaMin"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Planificacion>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA PLANIFICACION *****
        public int Registrar(CE_Planificacion obj, out string Mensaje)
        {
            int idUsuario = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarPlan", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Fecha", obj.Fecha);
                        command.Parameters.AddWithValue("_Medico", obj.Medico);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_DesdeHr", obj.DesdeHr);
                        command.Parameters.AddWithValue("_DesdeMin", obj.DesdeMin);
                        command.Parameters.AddWithValue("_HastaHr", obj.HastaHr);
                        command.Parameters.AddWithValue("_HastaMin", obj.HastaMin);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
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

        //***** METODO PARA EDITAR UNA PLANIFICACION *****
        public bool Editar(CE_Planificacion obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarPlan", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Plan", obj.id_Plan);
                        command.Parameters.AddWithValue("_Medico", obj.Medico);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_DesdeHr", obj.DesdeHr);
                        command.Parameters.AddWithValue("_DesdeMin", obj.DesdeMin);
                        command.Parameters.AddWithValue("_HastaHr", obj.HastaHr);
                        command.Parameters.AddWithValue("_HastaMin", obj.HastaMin);
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

        //***** METODO PARA ELIMINAR UNA PLANIFICACION *****
        public bool Eliminar(CE_Planificacion obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarPlan", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Plan", obj.id_Plan);
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

        //***** BUSQUEDA DE LA PLANIFICACION *****
        public List<CE_Planificacion> BuscarPlan(string idPlan)
        {
            List<CE_Planificacion> lista = new List<CE_Planificacion>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@id", idPlan);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM planificacion WHERE id_Plan = @id";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Planificacion()
                                {
                                    id_Plan = Convert.ToInt32(dr["id_Plan"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Medico = dr["Medico"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    DesdeHr = dr["DesdeHr"].ToString(),
                                    DesdeMin = dr["DesdeMin"].ToString(),
                                    HastaHr = dr["HastaHr"].ToString(),
                                    HastaMin = dr["HastaMin"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Planificacion>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LEER EL PLAN PARA ESA FECHA *****
        public List<CE_Planificacion> LeePlan(string fechaplan)
        {
            List<CE_Planificacion> lista = new List<CE_Planificacion>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", fechaplan);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Planificacion WHERE Fecha = @fecha";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Planificacion()
                                {
                                    id_Plan = Convert.ToInt32(dr["id_Plan"]),
                                    Fecha = Convert.ToDateTime(dr["Fecha"]),
                                    Medico = dr["Medico"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    DesdeHr = dr["DesdeHr"].ToString(),
                                    DesdeMin = dr["DesdeMin"].ToString(),
                                    HastaHr = dr["HastaHr"].ToString(),
                                    HastaMin = dr["HastaMin"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Planificacion>();
                    }
                }
            }
            return lista;
        }

    }
}
