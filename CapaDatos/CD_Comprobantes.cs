using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Comprobantes : Conexion
    {
        //***** METODO PARA BUSCAR EL COMPROBANTE QUE NECESITAMOS *****
        public int BuscoCpbte(string tipo)
        {
            int numero = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Comprobantes WHERE Tipo = @tipo";
                    command.CommandType = CommandType.Text;
                    MySqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            numero = int.Parse(dr[2].ToString());
                        };
                    }
                }
            }
            return numero;
        }

        //***** METODO PARA GRABAR EL NUMERO DE COMPROBANTE SEGÚN EL TIPO *****
        public bool GraboCpbte(string tipo, int numero)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@numero", numero);
                        command.Connection = connection;
                        command.CommandText = "UPDATE Comprobantes SET Numero = @numero WHERE Tipo = @tipo";
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

    }
}
