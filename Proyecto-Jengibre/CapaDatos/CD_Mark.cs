using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Mark
    {
        public List<Mark> List() //Lista los usuarios en la tabla.
        {
            List<Mark> list = new List<Mark>();

            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    string query = "SELECT ID_Mark, DescriptionMark, Active FROM Mark";

                    SqlCommand cmd = new SqlCommand(query, oconection);
                    cmd.CommandType = CommandType.Text;

                    oconection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Mark()
                            {
                                ID_Mark = Convert.ToInt32(reader["ID_Mark"]),
                                DescriptionMark = reader["DescriptionMark"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"])

                            });
                        }
                    }
                }
            }

            catch
            {
                list = new List<Mark>();
            }
            return list;
        }

        public int Register(Mark obj, out string Menssage)
        {
            int idAutogenerate = 0;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrerMark", oconection);
                    cmd.Parameters.AddWithValue("@DescriptionMark", obj.DescriptionMark);
                    cmd.Parameters.AddWithValue("Active", obj.Active);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconection.Open();

                    cmd.ExecuteNonQuery();

                    idAutogenerate = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
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


        public bool Edit(Mark obj, out string Menssage)
        {
            bool result = false;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditMark", oconection);
                    cmd.Parameters.AddWithValue("ID_Mark", obj.ID_Mark);
                    cmd.Parameters.AddWithValue("DescriptionMark", obj.DescriptionMark);
                    cmd.Parameters.AddWithValue("Active", obj.Active);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminateMark", oconection);

                    cmd.Parameters.AddWithValue("ID_Mark", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconection.Open();

                    cmd.ExecuteNonQuery();

                    result = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
    }
}

