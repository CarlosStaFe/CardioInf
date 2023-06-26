using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Ecografias:Conexion
    {
        //***** METODO PARA LISTAR LAS ECOGRAFÍAS *****
        public List<CE_Ecografias> ListaEcografias()
        {
            List<CE_Ecografias> lista = new List<CE_Ecografias>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Ecografias ORDER BY Numero";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Ecografias()
                                {
                                    //id_Usuario = Convert.ToInt32(dr["id_Usuario"]),
                                    //Apellido = dr["Apellido"].ToString(),
                                    //Nombres = dr["Nombres"].ToString(),
                                    //Nivel = Convert.ToInt32(dr["Nivel"]),
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
                        lista = new List<CE_Ecografias>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UNA ECOGRAFIA *****
        public int Registrar(CE_Ecografias obj, out string Mensaje)
        {
            int idEcografia = 0;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_RegistrarEcografia", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("Numero", obj.Numero);
                        command.Parameters.AddWithValue("OS", obj.OS);
                        command.Parameters.AddWithValue("PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("FechaEco", obj.FechaEco);
                        command.Parameters.AddWithValue("AA", obj.AA);
                        command.Parameters.AddWithValue("MM", obj.MM);
                        command.Parameters.AddWithValue("DD", obj.DD);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Diagnostico", obj.Diagnostico);
                        command.Parameters.AddWithValue("E1", obj.E1);
                        command.Parameters.AddWithValue("E2", obj.E2);
                        command.Parameters.AddWithValue("E31", obj.E31);
                        command.Parameters.AddWithValue("E32", obj.E32);
                        command.Parameters.AddWithValue("E33", obj.E33);
                        command.Parameters.AddWithValue("E34", obj.E34);
                        command.Parameters.AddWithValue("E35", obj.E35);
                        command.Parameters.AddWithValue("E36", obj.E36);
                        command.Parameters.AddWithValue("E37", obj.E37);
                        command.Parameters.AddWithValue("E38", obj.E38);
                        command.Parameters.AddWithValue("E39", obj.E39);
                        command.Parameters.AddWithValue("E310", obj.E310);
                        command.Parameters.AddWithValue("E311", obj.E311);
                        command.Parameters.AddWithValue("E312", obj.E312);
                        command.Parameters.AddWithValue("E313", obj.E313);
                        command.Parameters.AddWithValue("E314", obj.E314);
                        command.Parameters.AddWithValue("E315", obj.E315);
                        command.Parameters.AddWithValue("E316", obj.E316);
                        command.Parameters.AddWithValue("E41", obj.E41);
                        command.Parameters.AddWithValue("E41v", obj.E41v);
                        command.Parameters.AddWithValue("E41g", obj.E41g);
                        command.Parameters.AddWithValue("E42", obj.E42);
                        command.Parameters.AddWithValue("E42v", obj.E42v);
                        command.Parameters.AddWithValue("E42g", obj.E42g);
                        command.Parameters.AddWithValue("E43", obj.E43);
                        command.Parameters.AddWithValue("E43v", obj.E43v);
                        command.Parameters.AddWithValue("E43g", obj.E43g);
                        command.Parameters.AddWithValue("E44", obj.E44);
                        command.Parameters.AddWithValue("E44v", obj.E44v);
                        command.Parameters.AddWithValue("E44g", obj.E44g);
                        command.Parameters.AddWithValue("E45", obj.E45);
                        command.Parameters.AddWithValue("E45v", obj.E45v);
                        command.Parameters.AddWithValue("E45g", obj.E45g);
                        command.Parameters.AddWithValue("E46", obj.E46);
                        command.Parameters.AddWithValue("E46v", obj.E46v);
                        command.Parameters.AddWithValue("E46g", obj.E46g);
                        command.Parameters.AddWithValue("E47", obj.E47);
                        command.Parameters.AddWithValue("E47v", obj.E47v);
                        command.Parameters.AddWithValue("E47g", obj.E47g);
                        command.Parameters.AddWithValue("E48", obj.E48);
                        command.Parameters.AddWithValue("E48v", obj.E48v);
                        command.Parameters.AddWithValue("E48g", obj.E48g);
                        command.Parameters.AddWithValue("E49", obj.E49);
                        command.Parameters.AddWithValue("E49v", obj.E49v);
                        command.Parameters.AddWithValue("E49g", obj.E49g);
                        command.Parameters.AddWithValue("E410", obj.E410);
                        command.Parameters.AddWithValue("E410v", obj.E410v);
                        command.Parameters.AddWithValue("E410g", obj.E410g);
                        command.Parameters.AddWithValue("E5", obj.E5);
                        command.Parameters.AddWithValue("E6", obj.E6);
                        command.Parameters.AddWithValue("UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("FechaRegistro", DateTime.Now);
                        command.Parameters.Add("idResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idEcografia = Convert.ToInt32(command.Parameters["idResultado"].Value);
                        Mensaje = command.Parameters["Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idEcografia = 0;
                        Mensaje = ex.Message;
                    }
                }
            }
            return idEcografia;
        }

        //***** METODO PARA EDITAR UNA ECOGRAFÍA *****
        public bool Editar(CE_Ecografias obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EditarEcografia", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Eco", obj.id_Eco);
                        command.Parameters.AddWithValue("Pacte", obj.Pacte);
                        command.Parameters.AddWithValue("Numero", obj.Numero);
                        command.Parameters.AddWithValue("OS", obj.OS);
                        command.Parameters.AddWithValue("PlanOS", obj.PlanOS);
                        command.Parameters.AddWithValue("FechaEco", obj.FechaEco);
                        command.Parameters.AddWithValue("AA", obj.AA);
                        command.Parameters.AddWithValue("MM", obj.MM);
                        command.Parameters.AddWithValue("DD", obj.DD);
                        command.Parameters.AddWithValue("Tipo", obj.Tipo);
                        command.Parameters.AddWithValue("Diadnostico", obj.Diagnostico);
                        command.Parameters.AddWithValue("E1", obj.E1);
                        command.Parameters.AddWithValue("E2", obj.E2);
                        command.Parameters.AddWithValue("E31", obj.E31);
                        command.Parameters.AddWithValue("E32", obj.E32);
                        command.Parameters.AddWithValue("E33", obj.E33);
                        command.Parameters.AddWithValue("E34", obj.E34);
                        command.Parameters.AddWithValue("E35", obj.E35);
                        command.Parameters.AddWithValue("E36", obj.E36);
                        command.Parameters.AddWithValue("E37", obj.E37);
                        command.Parameters.AddWithValue("E38", obj.E38);
                        command.Parameters.AddWithValue("E39", obj.E39);
                        command.Parameters.AddWithValue("E310", obj.E310);
                        command.Parameters.AddWithValue("E311", obj.E311);
                        command.Parameters.AddWithValue("E312", obj.E312);
                        command.Parameters.AddWithValue("E313", obj.E313);
                        command.Parameters.AddWithValue("E314", obj.E314);
                        command.Parameters.AddWithValue("E315", obj.E315);
                        command.Parameters.AddWithValue("E316", obj.E316);
                        command.Parameters.AddWithValue("E41", obj.E41);
                        command.Parameters.AddWithValue("E41v", obj.E41v);
                        command.Parameters.AddWithValue("E41g", obj.E41g);
                        command.Parameters.AddWithValue("E42", obj.E42);
                        command.Parameters.AddWithValue("E42v", obj.E42v);
                        command.Parameters.AddWithValue("E42g", obj.E42g);
                        command.Parameters.AddWithValue("E43", obj.E43);
                        command.Parameters.AddWithValue("E43v", obj.E43v);
                        command.Parameters.AddWithValue("E43g", obj.E43g);
                        command.Parameters.AddWithValue("E44", obj.E44);
                        command.Parameters.AddWithValue("E44v", obj.E44v);
                        command.Parameters.AddWithValue("E44g", obj.E44g);
                        command.Parameters.AddWithValue("E45", obj.E45);
                        command.Parameters.AddWithValue("E45v", obj.E45v);
                        command.Parameters.AddWithValue("E45g", obj.E45g);
                        command.Parameters.AddWithValue("E46", obj.E46);
                        command.Parameters.AddWithValue("E46v", obj.E46v);
                        command.Parameters.AddWithValue("E46g", obj.E46g);
                        command.Parameters.AddWithValue("E47", obj.E47);
                        command.Parameters.AddWithValue("E47v", obj.E47v);
                        command.Parameters.AddWithValue("E47g", obj.E47g);
                        command.Parameters.AddWithValue("E48", obj.E48);
                        command.Parameters.AddWithValue("E48v", obj.E48v);
                        command.Parameters.AddWithValue("E48g", obj.E48g);
                        command.Parameters.AddWithValue("E49", obj.E49);
                        command.Parameters.AddWithValue("E49v", obj.E49v);
                        command.Parameters.AddWithValue("E49g", obj.E49g);
                        command.Parameters.AddWithValue("E410", obj.E410);
                        command.Parameters.AddWithValue("E410v", obj.E410v);
                        command.Parameters.AddWithValue("E410g", obj.E410g);
                        command.Parameters.AddWithValue("E5", obj.E5);
                        command.Parameters.AddWithValue("E6", obj.E6);
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

        //***** METODO PARA ELIMINAR UNA ECOGRAFÍA *****
        public bool Eliminar(CE_Ecografias obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SP_EliminarUsuario", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("id_Eco", obj.id_Eco);
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
