using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

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
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spListaCodPos";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

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
                using (var command = new MySqlCommand("spRegistrarCodPos", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_fk_Local", obj.fk_Local);
                        command.Parameters.AddWithValue("_fk_Depto", obj.fk_Depto);
                        command.Parameters.AddWithValue("_fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("_Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCodPos = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
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
                using (var command = new MySqlCommand("spEditarCodPos", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_CodPos", obj.id_CodPos);
                        command.Parameters.AddWithValue("_fk_Local", obj.fk_Local);
                        command.Parameters.AddWithValue("_fk_Depto", obj.fk_Depto);
                        command.Parameters.AddWithValue("_fk_Prov", obj.fk_Prov);
                        command.Parameters.AddWithValue("_Localidad", obj.Localidad);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
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

        //***** METODO PARA BUSCAR LA LOCALIDAD COMPLETA *****
        public string BuscaCodPos(int local)
        {
            string localidad = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Parameters.AddWithValue("@local", local);
                    command.Connection = connection;
                    command.CommandText = "SELECT CodigosPostales.CodigoPostal,Localidades.Localidad,Departamentos.Departamento,Provincias.Provincia FROM CodigosPostales " +
                                          "INNER JOIN Localidades   ON id_Local = CodigosPostales.fk_Local " +
                                          "INNER JOIN Departamentos ON id_Depto = CodigosPostales.fk_Depto " +
                                          "INNER JOIN Provincias    ON id_Prov  = CodigosPostales.fk_Prov " +
                                          "WHERE id_CodPos = @local";
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr = command.ExecuteReader();

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
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM CodigosPostales WHERE CodigoPostal = @codigo";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

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
