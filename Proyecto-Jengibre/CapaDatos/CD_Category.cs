using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;

namespace CapaDatos
{
    public class CD_Category
    {
        public List<Category> List() //Lista los usuarios en la tabla.
        {
            List<Category> list = new List<Category>();

            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    string query = "SELECT ID_Category, DescriptionCategory, Active FROM Category";

                    SqlCommand cmd = new SqlCommand(query, oconection);
                    cmd.CommandType = CommandType.Text;

                    oconection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Category()
                            {
                                ID_Category = Convert.ToInt32(reader["ID_Category"]),
                                DescriptionCategory = reader["DescriptionCategory"].ToString(),
                                Active = Convert.ToBoolean(reader["Active"])

                            });
                        }
                    }
                }
            }

            catch
            {
                list = new List<Category>();
            }
            return list;
        }

        public int Register(Category obj, out string Menssage)
        {
            int idAutogenerate = 0;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrerCategory", oconection);
                    cmd.Parameters.AddWithValue("@DescriptionCateogry", obj.DescriptionCategory);
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

        public bool Edit(Category obj, out string Menssage)
        {
            bool result = false;
            Menssage = string.Empty;
            try
            {
                using (SqlConnection oconection = new SqlConnection(Conection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditCategory", oconection);
                    cmd.Parameters.AddWithValue("ID_Category", obj.ID_Category);
                    cmd.Parameters.AddWithValue("DescriptionCateogry", obj.DescriptionCategory);                  
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
                SqlCommand cmd = new SqlCommand("sp_EliminateCategory", oconection);
               
                cmd.Parameters.AddWithValue("ID_Category", id);     
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
