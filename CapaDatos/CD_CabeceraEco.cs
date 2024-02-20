using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_CabeceraEco:Conexion
    {
        //***** METODO PARA LISTAR LAS CABECERAS ECOGRAFÍAS *****
        public List<CE_CabeceraEco> ListaCabEco(string fecha)
        {
            List<CE_CabeceraEco> lista = new List<CE_CabeceraEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@fecha", fecha);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM CabeceraEco WHERE FechaEco = @fecha ORDER BY FechaEco,NumeroCab";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CabeceraEco()
                                {
                                    id_CabEco = Convert.ToInt32(dr["id_CabEco"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"].ToString()),
                                    FechaEco = Convert.ToDateTime(dr["FechaEco"]),
                                    NumeroCab = Convert.ToInt32(dr["NumeroCab"].ToString()),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    PlanOS = dr["PlanOS"].ToString(),
                                    Afiliado = dr["Afiliado"].ToString(),
                                    AA = Convert.ToInt32(dr["AA"]),
                                    MM = Convert.ToInt32(dr["MM"]),
                                    DD = Convert.ToInt32(dr["DD"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CabeceraEco>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA CABECERA DE ECOGRAFIA *****
        public int Registrar(CE_CabeceraEco obj, out string Mensaje)
        {
            int idCabEco = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarCabEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("_FechaEco", obj.FechaEco);
                        command.Parameters.AddWithValue("_NumeroCab", obj.NumeroCab);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("_PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("_Afiliado", obj.Afiliado);
                        command.Parameters.AddWithValue("_AA", obj.AA);
                        command.Parameters.AddWithValue("_MM", obj.MM);
                        command.Parameters.AddWithValue("_DD", obj.DD);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idCabEco = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        Mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idCabEco = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idCabEco;
        }

        //***** METODO PARA EDITAR UNA CABECERA DE ECOGRAFÍA *****
        public bool Editar(CE_CabeceraEco obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarCabEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_CabEco", obj.id_CabEco);
                        command.Parameters.AddWithValue("_Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("_FechaEco", obj.FechaEco);
                        command.Parameters.AddWithValue("_NumeroCab", obj.NumeroCab);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_FechaNacim", obj.FechaNacim);
                        command.Parameters.AddWithValue("_ObraSocial", obj.ObraSocial);
                        command.Parameters.AddWithValue("_PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("_Afiliado", obj.Afiliado);
                        command.Parameters.AddWithValue("_AA", obj.AA);
                        command.Parameters.AddWithValue("_MM", obj.MM);
                        command.Parameters.AddWithValue("_DD", obj.DD);
                        command.Parameters.AddWithValue("_Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
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

        //***** METODO PARA ELIMINAR UNA CABECERA DE ECOGRAFÍA *****
        public bool Eliminar(CE_CabeceraEco obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEliminarCabEco", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Eco", obj.id_CabEco);
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

        //***** METODO PARA LISTAR LAS CABECERAS DE ECOGRAFÍAS *****
        public List<CE_CabeceraEco> ListaEco()
        {
            List<CE_CabeceraEco> lista = new List<CE_CabeceraEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spListaCabEco";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CabeceraEco()
                                {
                                    id_CabEco = Convert.ToInt32(dr["id_CabEco"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"].ToString()),
                                    FechaEco = Convert.ToDateTime(dr["FechaEco"]),
                                    NumeroCab = Convert.ToInt32(dr["NumeroCab"].ToString()),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    PlanOS = dr["PlanOS"].ToString(),
                                    Afiliado = dr["Afiliado"].ToString(),
                                    AA = Convert.ToInt32(dr["AA"]),
                                    MM = Convert.ToInt32(dr["MM"]),
                                    DD = Convert.ToInt32(dr["DD"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CabeceraEco>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA GRABAR EL ESTADO DE LA CABECERA *****
        public bool ActualizoCabecera(int id, string estado)
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
                        command.CommandText = "UPDATE CabeceraEco SET Estado = @estado WHERE id_CabEco = @id";
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

        //***** METODO PARA LEER LA CABECERA DE UNA ECOGRAFIA *****
        public List<CE_CabeceraEco> LeerCabecera(string paciente, string numero)
        {
            List<CE_CabeceraEco> lista = new List<CE_CabeceraEco>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@pacte", paciente);
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM CabeceraEco WHERE Pacte = @pacte AND NumeroCab = @numero";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CabeceraEco()
                                {
                                    id_CabEco = Convert.ToInt32(dr["id_CabEco"]),
                                    Pacte = Convert.ToInt32(dr["Pacte"].ToString()),
                                    FechaEco = Convert.ToDateTime(dr["FechaEco"]),
                                    NumeroCab = Convert.ToInt32(dr["NumeroCab"].ToString()),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    FechaNacim = Convert.ToDateTime(dr["FechaNacim"]),
                                    ObraSocial = dr["ObraSocial"].ToString(),
                                    PlanOS = dr["PlanOS"].ToString(),
                                    Afiliado = dr["Afiliado"].ToString(),
                                    AA = Convert.ToInt32(dr["AA"]),
                                    MM = Convert.ToInt32(dr["MM"]),
                                    DD = Convert.ToInt32(dr["DD"]),
                                    Tipo = dr["Tipo"].ToString(),
                                    Obs = dr["Obs"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CabeceraEco>();
                    }
                }
            }
            return lista;
        }


    }
}
