using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Useers
    {
        public List<Useer> List()
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
                list= new List<Useer>();
            }
            return list;
        }
    }
}
