using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Pacientes:Conexion
    {
        //***** METODO PARA LISTAR LOS PACIENTES *****
        public List<CE_Pacientes> ListaPacte()
        {
            List<CE_Pacientes> lista = new List<CE_Pacientes>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Pacientes ORDER BY ApelNombres";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

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
                using (var command = new SqlCommand("SP_RegistrarPaciente", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idPaciente = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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
                using (var command = new SqlCommand("SP_EditarPaciente", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Pacte", obj.id_Pacte);
                        command.Parameters.AddWithValue("ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["Resultado"].Value);
                        mensaje = command.Parameters["Mensaje"].Value.ToString();
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

    }
}
