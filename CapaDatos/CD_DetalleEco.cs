using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_DetalleEco:Conexion
    {
        //***** METODO PARA LISTAR LOS DETALLES DE ECOGRAFÍAS *****
        public List<CE_DetalleEco> ListaDetEco()
        {
            List<CE_DetalleEco> lista = new List<CE_DetalleEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM DetalleEco ORDER BY Numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_DetalleEco()
                                {
                                    id_DetEco = Convert.ToInt32(dr["id_DetEco"]),
                                    NumeroDet = Convert.ToInt32(dr["NumeroDet"].ToString()),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    //Funcion = dr["Funcion"].ToString(),
                                    //Usuario = dr["Usuario"].ToString(),
                                    //Clave = dr["Clave"].ToString(),
                                    //Activo = Convert.ToBoolean(dr["Activo"]),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_DetalleEco>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN DETALLE DE ECOGRAFIA *****
        public int Registrar(CE_DetalleEco obj, out string Mensaje)
        {
            int idDetEco = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarDetEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_NumeroDet", obj.NumeroDet);
                        command.Parameters.AddWithValue("_Diagnostico", obj.Diagnostico);
                        command.Parameters.AddWithValue("_E1", obj.E1);
                        command.Parameters.AddWithValue("_E2", obj.E2);
                        command.Parameters.AddWithValue("_E31", obj.E31);
                        command.Parameters.AddWithValue("_E32", obj.E32);
                        command.Parameters.AddWithValue("_E33", obj.E33);
                        command.Parameters.AddWithValue("_E34", obj.E34);
                        command.Parameters.AddWithValue("_E35", obj.E35);
                        command.Parameters.AddWithValue("_E36", obj.E36);
                        command.Parameters.AddWithValue("_E37", obj.E37);
                        command.Parameters.AddWithValue("_E38", obj.E38);
                        command.Parameters.AddWithValue("_E39", obj.E39);
                        command.Parameters.AddWithValue("_E310", obj.E310);
                        command.Parameters.AddWithValue("_E310p", obj.E310p);
                        command.Parameters.AddWithValue("_E311", obj.E311);
                        command.Parameters.AddWithValue("_E312", obj.E312);
                        command.Parameters.AddWithValue("_E313", obj.E313);
                        command.Parameters.AddWithValue("_E314", obj.E314);
                        command.Parameters.AddWithValue("_E315", obj.E315);
                        command.Parameters.AddWithValue("_E316", obj.E316);
                        command.Parameters.AddWithValue("_E41", obj.E41);
                        command.Parameters.AddWithValue("_E41v", obj.E41v);
                        command.Parameters.AddWithValue("_E41g", obj.E41g);
                        command.Parameters.AddWithValue("_E42", obj.E42);
                        command.Parameters.AddWithValue("_E42v", obj.E42v);
                        command.Parameters.AddWithValue("_E42g", obj.E42g);
                        command.Parameters.AddWithValue("_E43", obj.E43);
                        command.Parameters.AddWithValue("_E43v", obj.E43v);
                        command.Parameters.AddWithValue("_E43g", obj.E43g);
                        command.Parameters.AddWithValue("_E44", obj.E44);
                        command.Parameters.AddWithValue("_E44v", obj.E44v);
                        command.Parameters.AddWithValue("_E44g", obj.E44g);
                        command.Parameters.AddWithValue("_E45", obj.E45);
                        command.Parameters.AddWithValue("_E45v", obj.E45v);
                        command.Parameters.AddWithValue("_E45g", obj.E45g);
                        command.Parameters.AddWithValue("_E46", obj.E46);
                        command.Parameters.AddWithValue("_E46v", obj.E46v);
                        command.Parameters.AddWithValue("_E46g", obj.E46g);
                        command.Parameters.AddWithValue("_E47", obj.E47);
                        command.Parameters.AddWithValue("_E47v", obj.E47v);
                        command.Parameters.AddWithValue("_E47g", obj.E47g);
                        command.Parameters.AddWithValue("_E48", obj.E48);
                        command.Parameters.AddWithValue("_E48v", obj.E48v);
                        command.Parameters.AddWithValue("_E48g", obj.E48g);
                        command.Parameters.AddWithValue("_E49", obj.E49);
                        command.Parameters.AddWithValue("_E49v", obj.E49v);
                        command.Parameters.AddWithValue("_E49g", obj.E49g);
                        command.Parameters.AddWithValue("_E410", obj.E410);
                        command.Parameters.AddWithValue("_E410v", obj.E410v);
                        command.Parameters.AddWithValue("_E410g", obj.E410g);
                        command.Parameters.AddWithValue("_E5", obj.E5);
                        command.Parameters.AddWithValue("_E6", obj.E6);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idDetEco = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idDetEco = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idDetEco;
        }

        //***** METODO PARA EDITAR UN DETALLE DE ECOGRAFÍA *****
        public bool Editar(CE_DetalleEco obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarDetEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_DetEco", obj.id_DetEco);
                        command.Parameters.AddWithValue("_NumeroDet", obj.NumeroDet);
                        command.Parameters.AddWithValue("_Diagnostico", obj.Diagnostico);
                        command.Parameters.AddWithValue("_E1", obj.E1);
                        command.Parameters.AddWithValue("_E2", obj.E2);
                        command.Parameters.AddWithValue("_E31", obj.E31);
                        command.Parameters.AddWithValue("_E32", obj.E32);
                        command.Parameters.AddWithValue("_E33", obj.E33);
                        command.Parameters.AddWithValue("_E34", obj.E34);
                        command.Parameters.AddWithValue("_E35", obj.E35);
                        command.Parameters.AddWithValue("_E36", obj.E36);
                        command.Parameters.AddWithValue("_E37", obj.E37);
                        command.Parameters.AddWithValue("_E38", obj.E38);
                        command.Parameters.AddWithValue("_E39", obj.E39);
                        command.Parameters.AddWithValue("_E310", obj.E310);
                        command.Parameters.AddWithValue("_E310p", obj.E310p);
                        command.Parameters.AddWithValue("_E311", obj.E311);
                        command.Parameters.AddWithValue("_E312", obj.E312);
                        command.Parameters.AddWithValue("_E313", obj.E313);
                        command.Parameters.AddWithValue("_E314", obj.E314);
                        command.Parameters.AddWithValue("_E315", obj.E315);
                        command.Parameters.AddWithValue("_E316", obj.E316);
                        command.Parameters.AddWithValue("_E41", obj.E41);
                        command.Parameters.AddWithValue("_E41v", obj.E41v);
                        command.Parameters.AddWithValue("_E41g", obj.E41g);
                        command.Parameters.AddWithValue("_E42", obj.E42);
                        command.Parameters.AddWithValue("_E42v", obj.E42v);
                        command.Parameters.AddWithValue("_E42g", obj.E42g);
                        command.Parameters.AddWithValue("_E43", obj.E43);
                        command.Parameters.AddWithValue("_E43v", obj.E43v);
                        command.Parameters.AddWithValue("_E43g", obj.E43g);
                        command.Parameters.AddWithValue("_E44", obj.E44);
                        command.Parameters.AddWithValue("_E44v", obj.E44v);
                        command.Parameters.AddWithValue("_E44g", obj.E44g);
                        command.Parameters.AddWithValue("_E45", obj.E45);
                        command.Parameters.AddWithValue("_E45v", obj.E45v);
                        command.Parameters.AddWithValue("_E45g", obj.E45g);
                        command.Parameters.AddWithValue("_E46", obj.E46);
                        command.Parameters.AddWithValue("_E46v", obj.E46v);
                        command.Parameters.AddWithValue("_E46g", obj.E46g);
                        command.Parameters.AddWithValue("_E47", obj.E47);
                        command.Parameters.AddWithValue("_E47v", obj.E47v);
                        command.Parameters.AddWithValue("_E47g", obj.E47g);
                        command.Parameters.AddWithValue("_E48", obj.E48);
                        command.Parameters.AddWithValue("_E48v", obj.E48v);
                        command.Parameters.AddWithValue("_E48g", obj.E48g);
                        command.Parameters.AddWithValue("_E49", obj.E49);
                        command.Parameters.AddWithValue("_E49v", obj.E49v);
                        command.Parameters.AddWithValue("_E49g", obj.E49g);
                        command.Parameters.AddWithValue("_E410", obj.E410);
                        command.Parameters.AddWithValue("_E410v", obj.E410v);
                        command.Parameters.AddWithValue("_E410g", obj.E410g);
                        command.Parameters.AddWithValue("_E5", obj.E5);
                        command.Parameters.AddWithValue("_E6", obj.E6);
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

        //***** METODO PARA ELIMINAR UN DETALLE DE ECOGRAFÍA *****
        public bool Eliminar(CE_DetalleEco obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarDetEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_DetEco", obj.id_DetEco);
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

        //***** METODO PARA LISTAR LOS DETALLES DE ECOGRAFÍAS *****
        public List<CE_DetalleEco> ListaEco()
        {
            List<CE_DetalleEco> lista = new List<CE_DetalleEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spListaDetEco";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_DetalleEco()
                                {
                                    id_DetEco = Convert.ToInt32(dr["id_DetEco"]),
                                    NumeroDet = Convert.ToInt32(dr["NumeroDet"].ToString()),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_DetalleEco>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LISTAR LOS DETALLES DE ECOGRAFÍAS *****
        public List<CE_DetalleEco> LeerDetalle(string numero)
        {
            List<CE_DetalleEco> lista = new List<CE_DetalleEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM DetalleEco WHERE NumeroDet = @numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_DetalleEco()
                                {
                                    id_DetEco = Convert.ToInt32(dr["id_DetEco"]),
                                    NumeroDet = Convert.ToInt32(dr["NumeroDet"].ToString()),
                                    Diagnostico = dr["Diagnostico"].ToString(),
                                    E1 = dr["E1"].ToString(),
                                    E2 = dr["E2"].ToString(),
                                    E31 = dr["E31"].ToString(),
                                    E32 = dr["E32"].ToString(),
                                    E33 = dr["E33"].ToString(),
                                    E34 = dr["E34"].ToString(),
                                    E35 = dr["E35"].ToString(),
                                    E36 = dr["E36"].ToString(),
                                    E37 = dr["E37"].ToString(),
                                    E38 = Convert.ToDecimal(dr["E38"].ToString()),
                                    E39 = Convert.ToDecimal(dr["E39"].ToString()),
                                    E310 = dr["E310"].ToString(),
                                    E310p = Convert.ToDecimal(dr["E310p"].ToString()),
                                    E311 = dr["E311"].ToString(),
                                    E312 = dr["E312"].ToString(),
                                    E313 = dr["E313"].ToString(),
                                    E314 = dr["E314"].ToString(),
                                    E315 = dr["E315"].ToString(),
                                    E316 = dr["E316"].ToString(),
                                    E41 = dr["E41"].ToString(),
                                    E41v = Convert.ToDecimal(dr["E41v"].ToString()),
                                    E41g = Convert.ToDecimal(dr["E41g"].ToString()),
                                    E42 = dr["E42"].ToString(),
                                    E42v = Convert.ToDecimal(dr["E42v"].ToString()),
                                    E42g = Convert.ToDecimal(dr["E42g"].ToString()),
                                    E43 = dr["E43"].ToString(),
                                    E43v = Convert.ToDecimal(dr["E43v"].ToString()),
                                    E43g = Convert.ToDecimal(dr["E43g"].ToString()),
                                    E44 = dr["E44"].ToString(),
                                    E44v = Convert.ToDecimal(dr["E44v"].ToString()),
                                    E44g = Convert.ToDecimal(dr["E44g"].ToString()),
                                    E45 = dr["E45"].ToString(),
                                    E45v = Convert.ToDecimal(dr["E45v"].ToString()),
                                    E45g = Convert.ToDecimal(dr["E45g"].ToString()),
                                    E46 = dr["E46"].ToString(),
                                    E46v = Convert.ToDecimal(dr["E46v"].ToString()),
                                    E46g = Convert.ToDecimal(dr["E46g"].ToString()),
                                    E47 = dr["E47"].ToString(),
                                    E47v = Convert.ToDecimal(dr["E47v"].ToString()),
                                    E47g = Convert.ToDecimal(dr["E47g"].ToString()),
                                    E48 = dr["E48"].ToString(),
                                    E48v = Convert.ToDecimal(dr["E48v"].ToString()),
                                    E48g = Convert.ToDecimal(dr["E48g"].ToString()),
                                    E49 = dr["E49"].ToString(),
                                    E49v = Convert.ToDecimal(dr["E49v"].ToString()),
                                    E49g = Convert.ToDecimal(dr["E49g"].ToString()),
                                    E410 = dr["E410"].ToString(),
                                    E410v = Convert.ToDecimal(dr["E410v"].ToString()),
                                    E410g = Convert.ToDecimal(dr["E410g"].ToString()),
                                    E5 = dr["E5"].ToString(),
                                    E6 = dr["E6"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_DetalleEco>();
                    }
                }
            }
            return lista;
        }

    }
}
