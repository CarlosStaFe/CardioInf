using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Botones:Conexion
    {
        //***** METODO PARA BUSCAR LOS BOTONES PARA HABILITARLOS *****
        public List<CE_Botones> BuscaBotones(int idUsuario)
        {
            List<CE_Botones> lista = new List<CE_Botones>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Connection = connection;
                        command.CommandText = "SELECT B.Nombre FROM Botones B " +
                                              "INNER JOIN Permisos P ON B.id_Boton = P.fk_Botones " +
                                              "INNER JOIN Usuarios U ON U.id_Usuario = P.fk_Usuarios " +
                                              "WHERE U.id_Usuario = @idUsuario";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Botones()
                                {
                                    Nombre = dr["Nombre"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Botones>();
                    }
                    return lista;
                }
            }
        }

        //***** METODO PARA LISTAR LOS BOTONES BUSCADOS *****
        public List<CE_Botones> ListaBoton()
        {
            List<CE_Botones> lista = new List<CE_Botones>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Botones ORDER BY Nombre";
                        command.CommandType = CommandType.Text;

                        using (MySqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Botones()
                                {
                                    id_Boton = Convert.ToInt32(dr["id_Boton"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Detalle = dr["Detalle"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Botones>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN BOTON *****
        public int Registrar(CE_Botones obj, out string Mensaje)
        {
            int idBoton = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarBoton", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
                        command.Parameters.AddWithValue("_UserRegistro", CE_UserLogin.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idBoton = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idBoton = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idBoton;
        }

        //***** METODO PARA EDITAR UN BOTON *****
        public bool Editar(CE_Botones obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarBoton", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Boton", obj.id_Boton);
                        command.Parameters.AddWithValue("_Nombre", obj.Nombre);
                        command.Parameters.AddWithValue("_Detalle", obj.Detalle);
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

        //***** METODO PARA ELIMINAR UN BOTON *****
        public bool Eliminar(CE_Botones obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarBoton", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Boton", obj.id_Boton);
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
