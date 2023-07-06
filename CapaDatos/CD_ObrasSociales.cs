using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_ObrasSociales:Conexion
    {
        //***** METODO PARA LISTAR LAS OBRAS SOCIALES *****
        public List<CE_ObrasSociales> ListaOS()
        {
            List<CE_ObrasSociales> lista = new List<CE_ObrasSociales>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM ObrasSociales ORDER BY Nombre";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_ObrasSociales()
                                {
                                    id_OS = Convert.ToInt32(dr["id_OS"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Cuit = dr["Cuit"].ToString(),
                                    Domicilio = dr["Domicilio"].ToString(),
                                    CodPostal = Convert.ToInt32(dr["CodPostal"]),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_ObrasSociales>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA OBRA SOCIAL *****
        public int Registrar(CE_ObrasSociales obj, out string Mensaje)
        {
            int idOS = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("Email", obj.Email);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idOS = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idOS = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idOS;
        }

        //***** METODO PARA EDITAR UNA OBRA SOCIAL *****
        public bool Editar(CE_ObrasSociales obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarOS", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("Cuit", obj.Cuit);
                        command.Parameters.AddWithValue("Domicilio", obj.Domicilio);
                        command.Parameters.AddWithValue("CodPostal", obj.CodPostal);
                        command.Parameters.AddWithValue("Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("Email", obj.Email);
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

    }
}
