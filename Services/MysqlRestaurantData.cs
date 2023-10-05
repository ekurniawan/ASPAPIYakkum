using MySql.Data.MySqlClient;
using MyBackendApp.DTO;
using System.Data.SqlTypes;
using System.Transactions;
using System.Text;

namespace MyBackendApp.Services
{
    public class MysqlRestaurantData
    {
        private readonly IConfiguration _configuration;
        public MysqlRestaurantData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnStr()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<RestaurantDTO> GetAll()
        {
            List<RestaurantDTO> restaurants = new List<RestaurantDTO>();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants r
                                inner join RestaurantTypes rt 
                                on r.RestaurantTypeID = rt.RestaurantTypeID";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                conn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    while (dr.Read())
                    {
                        restaurants.Add(
                            new RestaurantDTO
                            {
                                RestaurantID = Convert.ToInt32(dr["RestaurantID"]),
                                Name = dr["Name"].ToString(),
                                RestaurantTypeName = dr["RestaurantTypeName"].ToString(),
                                RestaurantTypeID = Convert.ToInt32(dr["RestaurantTypeID"])
                            }
                        );
                    }
                }
                return restaurants;
            }
        }

        public RestaurantDTO GetById(int id)
        {
            RestaurantDTO restaurant = new RestaurantDTO();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants r
                                inner join RestaurantTypes rt 
                                on r.RestaurantTypeID = rt.RestaurantTypeID
                                where RestaurantID = @id";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    restaurant.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    restaurant.Name = dr["Name"].ToString();
                    restaurant.RestaurantTypeID = Convert.ToInt32(dr["RestaurantTypeID"]);
                    restaurant.RestaurantTypeName = dr["RestaurantTypeName"].ToString();
                }
            }
            return restaurant;
        }

        public RestaurantDTO Create(RestaurantDTO restaurant)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
                {
                    string strSql = @"insert into Restaurants(Name, RestaurantTypeID) 
                                values(@Name,@RestaurantTypeID);select last_insert_id() as RestaurantID";
                    MySqlCommand cmd = new MySqlCommand(strSql, conn);
                    cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@RestaurantTypeID", restaurant.RestaurantTypeID);
                    StringBuilder sb = new StringBuilder();
                    conn.Open();

                    try
                    {
                        restaurant.RestaurantID = Convert.ToInt32(cmd.ExecuteScalar());


                        /*using (MySqlConnection conn2 = new MySqlConnection(GetConnStr()))
                        {

                            if (restaurant.RestaurantMenus != null)
                            {
                                foreach (var item in restaurant.RestaurantMenus)
                                {
                                    sb.Append($@"insert into RestaurantMenus(RestaurantID, MenuName) 
                                values({restaurant.RestaurantID},'{item.MenuName}');");
                                }
                                MySqlCommand cmd2 = new MySqlCommand(sb.ToString(), conn2);
                                cmd2.CommandText = sb.ToString();
                                cmd2.ExecuteNonQuery();
                            }
                        }*/

                        if (restaurant.RestaurantMenus != null)
                        {
                            foreach (var item in restaurant.RestaurantMenus)
                            {
                                sb.Append($@"insert into RestaurantMenus(RestaurantID, MenuName) 
                                values({restaurant.RestaurantID},'{item.MenuName}');");
                            }
                            //MySqlCommand cmd2 = new MySqlCommand(sb.ToString(), conn2);
                            cmd.CommandText = sb.ToString();
                            cmd.ExecuteNonQuery();
                        }

                        scope.Complete();

                        return restaurant;
                    }
                    catch (MySqlException sqlEx)
                    {
                        restaurant.Deskripsi = "Err Number: " + sqlEx.Number.ToString();
                        throw new Exception(sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
            }




        }

        public RestaurantDTO Update(int id, RestaurantDTO restaurant)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"update Restaurants set Name=@Name, RestaurantTypeID=@RestaurantTypeID
                                where RestaurantID=@RestaurantID";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", restaurant.Name);
                cmd.Parameters.AddWithValue("@RestaurantTypeID", restaurant.RestaurantTypeID);
                cmd.Parameters.AddWithValue("@RestaurantID", id);

                conn.Open();
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    restaurant.RestaurantID = id;
                    if (result != 1) throw new Exception("Data tidak ditemukan");
                    return restaurant;
                }
                catch (MySqlException sqlEx)
                {
                    restaurant.Deskripsi = "Err Number: " + sqlEx.Number.ToString();
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public RestaurantDTO Delete(int id)
        {
            RestaurantDTO restaurant = new RestaurantDTO();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Restaurants where RestaurantID=@RestaurantID";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@RestaurantID", id);

                conn.Open();
                try
                {
                    int result = cmd.ExecuteNonQuery();
                    restaurant.RestaurantID = id;
                    if (result != 1) throw new Exception("Data tidak ditemukan");
                    return restaurant;
                }
                catch (MySqlException sqlEx)
                {
                    restaurant.Deskripsi = "Err Number: " + sqlEx.Number.ToString();
                    throw new Exception(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }



}