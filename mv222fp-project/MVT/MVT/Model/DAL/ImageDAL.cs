using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVT.Model;


namespace MVT.Model.DAL
{
    public class ImageDAL : DALBase
    {

        /// <summary>
        /// Updates products
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(ImageTyp product)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspUpdateProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Value = product.MedlemID;
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 50).Value = product.ImageAdres;
                    cmd.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = product.ImageID;
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        public void InsertProduct(ImageTyp product)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.uspInsertProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

          
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 50).Value = product.ImageAdres;
                    cmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    product.MedlemID = (int)cmd.Parameters["@ProductID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }
        /// <summary>
        /// Method to get product by specific id
        /// </summary>
        /// <param name="id">Product identity</param>
        /// <returns>Product</returns>
        /// 
        public ImageTyp GetProductById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("appSchema.uspGetProductById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", id);
                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var ProductIDIndex = reader.GetOrdinal("ProductID");
                            int ImageIndex = reader.GetOrdinal("Image");
                            int CategoryIDIndex = reader.GetOrdinal("CategoryID");


                            return new ImageTyp 
                            {
                                MedlemID = reader.GetInt32(ProductIDIndex),
                                ImageAdres = reader.GetString(ImageIndex),
                                ImageID = reader.GetInt32(CategoryIDIndex),
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

    }
}
