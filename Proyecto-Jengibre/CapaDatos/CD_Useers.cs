using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CapaDatos
{
    public class CD_Useers
    {
        public List<Useer> List() //Lista los usuarios en la tabla.
        {
            List<Useer> list = new List<Useer>();

            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    string query = "SELECT ID_User, NameUser, SurnameUser, Mail, Clave, Reseet,Active FROM Useer";
                    SqlCommand cmd = new SqlCommand(query, oconection); //
                    cmd.CommandType = CommandType.Text;

                    oconection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(
                                new Useer()
                                {
                                    ID_User = Convert.ToInt32(reader["ID_User"]),
                                    NameUser = reader["NameUser"].ToString(),
                                    SurnameUser = reader["SurnameUser"].ToString(),
                                    Mail = reader["Mail"].ToString(),
                                    Clave = reader["Clave"].ToString(),
                                    Reseet = Convert.ToBoolean(reader["Reseet"]),
                                    Active = Convert.ToBoolean(reader["Active"]),

                                }
                                );
                        }
                    }
                }
            }

            catch
            {
                list = new List<Useer>();
            }
            return list;
        }

        public int Register(Useer obj, out string Menssage)
        {
            int idAutogenerate = 0;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrationUser", oconection);
                    cmd.Parameters.AddWithValue("NameUser", obj.NameUser);
                    cmd.Parameters.AddWithValue("SurnameUser", obj.SurnameUser);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Active", obj.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconection.Open();

                    cmd.ExecuteNonQuery();

                    idAutogenerate = Convert.ToInt32(cmd.Parameters["Result"].Value);
                    Menssage = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idAutogenerate = 0;
                Menssage = ex.Message;
            }
            return idAutogenerate;
        }

        public bool Edit(Useer obj, out string Menssage)
        {
            bool result = false;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditUser", oconection);
                    cmd.Parameters.AddWithValue("ID_User", obj.ID_User);
                    cmd.Parameters.AddWithValue("NameUser", obj.NameUser);
                    cmd.Parameters.AddWithValue("SurnameUser", obj.SurnameUser);
                    cmd.Parameters.AddWithValue("Mail", obj.Mail);
                    cmd.Parameters.AddWithValue("Active", obj.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Menssage = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                result = false;
                Menssage = ex.Message;
            }
            return result;
        }



        public bool Eliminate(int id, out string Menssage)
        {
            bool result = false;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oConnection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("DELETE TOP (1) FROM Useer WHERE  ID_User = @ID_User", oConnection);
                    cmd.Parameters.AddWithValue("@ID_User", id);
                    cmd.CommandType = CommandType.Text;
                    oConnection.Open();
                    result = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                result = false;
                Menssage = ex.Message;
            }
            return result;
        }
    }
}
