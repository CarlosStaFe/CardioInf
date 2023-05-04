using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_CodigosPostales:Conexion
    {
        //***** METODO PARA LISTAR LAS LOCALIDADES *****
        public List<CE_CodigosPostales> ListaCodPos()
        {
            List<CE_CodigosPostales> lista = new List<CE_CodigosPostales>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SP_ListaCodPos";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CodigosPostales()
                                {
                                    id_CodPos = Convert.ToInt32(dr["id_CodPos"]),
                                    fk_Local = Convert.ToInt32(dr["fk_Local"]),
                                    fk_Depto = Convert.ToInt32(dr["fk_Depto"]),
                                    fk_Prov = Convert.ToInt32(dr["fk_Prov"]),
                                    CodigoPostal = Convert.ToInt32(dr["CodigoPostal"]),
                                    Localidad = dr["Localidad"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CodigosPostales>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN CÓDIGO POSTAL *****
        public int Registrar(CE_CodigosPostales obj, out string Mensaje)
        {
            int idCodPos = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarCodPos", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("fk_Local", obj.fk_Local);
                        command.Parameters.AddWithValue("fk_Depto", obj.fk_Depto);
                        command.Parameters.AddWithValue("fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCodPos = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idCodPos = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idCodPos;
        }

        //***** METODO PARA EDITAR UNA LOCALIDAD *****
        public bool Editar(CE_CodigosPostales obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarCodPos", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_CodPos", obj.id_CodPos);
                        command.Parameters.AddWithValue("fk_Local", obj.fk_Local);
                        command.Parameters.AddWithValue("fk_Depto", obj.fk_Depto);
                        command.Parameters.AddWithValue("fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("UserRegistro", CE_UserLogin.UserRegistro);
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

        //***** METODO PARA BUSCAR LA LOCALIDAD COMPLETA *****
        public string BuscaCodPos(int local)
        {
            string localidad = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Parameters.AddWithValue("@local", local);
                    command.Connection = connection;
                    command.CommandText = "SELECT CodigosPostales.CodigoPostal,Localidades.Localidad,Departamentos.Departamento,Provincias.Provincia FROM CodigosPostales " +
                                          "INNER JOIN Localidades   ON id_Local = CodigosPostales.fk_Local " +
                                          "INNER JOIN Departamentos ON id_Depto = CodigosPostales.fk_Depto " +
                                          "INNER JOIN Provincias    ON id_Prov  = CodigosPostales.fk_Prov " +
                                          "WHERE id_CodPos = @local";
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            localidad = "(" + Convert.ToInt32(dr[0].ToString()) + ") - " + dr[1].ToString() + " - " + dr[2].ToString() + " - " + dr[3].ToString();
                        };
                    }
                }
            }
            return localidad;
        }

        //***** METODO PARA LISTAR LAS LOCALIDADES *****
        public List<CE_CodigosPostales> ListaCodigos(int codigo)
        {
            List<CE_CodigosPostales> lista = new List<CE_CodigosPostales>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM CodigosPostales WHERE CodigoPostal = @codigo";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CodigosPostales()
                                {
                                    id_CodPos = Convert.ToInt32(dr["id_CodPos"]),
                                    fk_Local = Convert.ToInt32(dr["fk_Local"]),
                                    fk_Depto = Convert.ToInt32(dr["fk_Depto"]),
                                    fk_Prov = Convert.ToInt32(dr["fk_Prov"]),
                                    CodigoPostal = Convert.ToInt32(dr["CodigoPostal"]),
                                    Localidad = dr["Localidad"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CodigosPostales>();
                    }
                }
            }
            return lista;
        }


    }
}
