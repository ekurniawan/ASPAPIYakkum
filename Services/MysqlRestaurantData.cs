using MySql.Data.MySqlClient;
using MyBackendApp.DTO;

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

    }
}