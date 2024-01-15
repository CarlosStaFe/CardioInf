using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_CodigosNacionales:Conexion
    {
        //***** METODO PARA LISTAR LOS CODIGOS NACIONALES *****
        public List<CE_CodigosNacionales> ListaCodPosNac()
        {
            List<CE_CodigosNacionales> lista = new List<CE_CodigosNacionales>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM CodigosNacionales";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_CodigosNacionales()
                                {
                                    Codigo = Convert.ToInt32(dr["Codigo"]),
                                    Localidad = dr["Localidad"].ToString(),
                                    Departamento = dr["Departamento"].ToString(),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_CodigosNacionales>();
                    }
                }
            }
            return lista;
        }

    }
}
