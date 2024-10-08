﻿using CapaEntidad;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class CD_Profesionales:Conexion
    {
        //***** METODO PARA LISTAR LOS PROFESIONALES *****
        public List<CE_Profesionales> ListaProf()
        {
            List<CE_Profesionales> lista = new List<CE_Profesionales>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM Profesionales ORDER BY ApelNombres";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Profesionales()
                                {
                                    id_Prof = Convert.ToInt32(dr["id_Prof"]),
                                    Matricula = Convert.ToInt32(dr["Matricula"]),
                                    ApelNombres = dr["ApelNombres"].ToString(),
                                    Usuario = dr["Usuario"].ToString(),
                                    TipoDoc = dr["TipoDoc"].ToString(),
                                    NumeroDoc = Convert.ToInt32(dr["NumeroDoc"]),
                                    Sexo = dr["Sexo"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Estado = dr["Estado"].ToString(),
                                    FechaEstado = Convert.ToDateTime(dr["FechaEstado"]),
                                    Obs = dr["Obs"].ToString(),
                                    UserRegistro = dr["UserRegistro"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lista = new List<CE_Profesionales>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA REGISTRAR UN PROFESIONAL *****
        public int Registrar(CE_Profesionales obj, out string mensaje)
        {
            int idProfesional = 0;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spRegistrarProfesional", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_idResultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        idProfesional = Convert.ToInt32(command.Parameters["_idResultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        idProfesional = 0;
                        mensaje = ex.Message;
                    }
                }
            }
            return idProfesional;
        }

        //***** METODO PARA EDITAR UN PACIENTE *****
        public bool Editar(CE_Profesionales obj, out string mensaje)
        {
            bool Resultado = false;
            mensaje = string.Empty;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("spEditarProfesional", connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("_id_Prof", obj.id_Prof);
                        command.Parameters.AddWithValue("_Matricula", obj.Matricula);
                        command.Parameters.AddWithValue("_ApelNombres", obj.ApelNombres);
                        command.Parameters.AddWithValue("_Usuario", obj.Usuario);
                        command.Parameters.AddWithValue("_TipoDoc", obj.TipoDoc);
                        command.Parameters.AddWithValue("_NumeroDoc", obj.NumeroDoc);
                        command.Parameters.AddWithValue("_Sexo", obj.Sexo);
                        command.Parameters.AddWithValue("_Telefono", obj.Telefono);
                        command.Parameters.AddWithValue("_Email", obj.Email);
                        command.Parameters.AddWithValue("_Estado", obj.Estado);
                        command.Parameters.AddWithValue("_FechaEstado", obj.FechaEstado);
                        command.Parameters.AddWithValue("_Obs", obj.Obs);
                        command.Parameters.AddWithValue("_UserRegistro", obj.UserRegistro);
                        command.Parameters.AddWithValue("_FechaRegistro", DateTime.Now);
                        command.Parameters.Add("_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                        command.Parameters.Add("_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        Resultado = Convert.ToBoolean(command.Parameters["_Resultado"].Value);
                        mensaje = command.Parameters["_Mensaje"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Resultado = false;
                        mensaje = ex.Message;
                    }
                }
            }
            return Resultado;
        }


    }
}
