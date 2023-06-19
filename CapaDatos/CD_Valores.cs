using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Valores:Conexion
    {
        //***** METODO PARA LISTAR LOS VALORES *****
        public List<CE_Valores> ListaValores()
        {
            List<CE_Valores> lista = new List<CE_Valores>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Valores ORDER BY Estudio";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Valores()
                                {
                                    id_Valor = Convert.ToInt32(dr["id_Valor"]),
                                    Estudio = dr["Estudio"].ToString(),
                                    Valor = dr["Valor"].ToString(),
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
                        lista = new List<CE_Valores>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN VALOR *****
        public int Registrar(CE_Valores obj, out string Mensaje)
        {
            int idValor = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarValor", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Estudio", obj.Estudio);
                        command.Parameters.AddWithValue("Valor", obj.Valor);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
                        command.Parameters.AddWithValue("Obs", obj.Obs);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idValor = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idValor = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idValor;
        }

        //***** METODO PARA EDITAR UN VALOR *****
        public bool Editar(CE_Valores obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarValor", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Valor", obj.id_Valor);
                        command.Parameters.AddWithValue("Estudio", obj.Estudio);
                        command.Parameters.AddWithValue("Valor", obj.Valor);
                        command.Parameters.AddWithValue("Estado", obj.Estado);
                        command.Parameters.AddWithValue("FecEstado", obj.FecEstado);
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
