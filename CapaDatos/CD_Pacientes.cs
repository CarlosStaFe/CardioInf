using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Pacientes : Conexion
    {
        //***** METODO PARA LISTAR LOS PACIENTES *****
        public List<CE_Pacientes> ListaPacte(string texto)
        {
            List<CE_Pacientes> lista = new List<CE_Pacientes>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        if (texto == "")
                        {
                            command.CommandText = "SELECT * FROM Pacientes ORDER BY ApelNombres";
                        }
                        else
                        {
                            command.CommandText = "SELECT * FROM Pacientes WHERE ApelNombres LIKE '%" + texto + "%' ORDER BY ApelNombres";
                        }

                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Pacientes()
                                {
                                    id_Pacte = Convert.ToInt32(dr["id_Pacte"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    Sexo = dr["Sexo"].ToString(),
                                    TipoDoc = dr["TipoDoc"].ToString(),
                                    NumeroDoc = Convert.ToInt32(dr["NumeroDoc"]),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    CodPostal = Convert.ToInt32(dr["CodPostal"].ToString()),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    PlanOS = dr["PlanOS"].ToString(),
                                    Afiliado = dr["Afiliado"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Pacientes>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN PACIENTES *****
        public int Registrar(CE_Pacientes obj, out string mensaje)
        {
            int idPaciente = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarPaciente", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("_PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("_Afiliado", obj.Afiliado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idPaciente = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idPaciente = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idPaciente;
        }

        //***** METODO PARA EDITAR UN PACIENTE *****
        public bool Editar(CE_Pacientes obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarPaciente", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Pacte", obj.id_Pacte);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("_CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("_PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("_Afiliado", obj.Afiliado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }

        //***** BUSQUEDA DEL PACIENTE PARA LA ECOGRAFÍA *****
        public List<CE_Pacientes> BuscarPacte(string pacte)
        {
            List<CE_Pacientes> lista = new List<CE_Pacientes>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@pacte", pacte);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM pacientes WHERE id_Pacte = @pacte";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Pacientes()
                                {
                                    id_Pacte = Convert.ToInt32(dr["id_Pacte"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    Sexo = dr["Sexo"].ToString(),
                                    TipoDoc = dr["TipoDoc"].ToString(),
                                    NumeroDoc = Convert.ToInt32(dr["NumeroDoc"]),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    CodPostal = Convert.ToInt32(dr["CodPostal"].ToString()),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    PlanOS = dr["PlanOS"].ToString(),
                                    Afiliado = dr["Afiliado"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Pacientes>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA ELIMINAR UN PACIENTE *****
        public bool Eliminar(CE_Pacientes obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarPaciente", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Pacte", obj.id_Pacte);
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
