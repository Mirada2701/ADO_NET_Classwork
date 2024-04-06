using System.Data.SqlClient;
using _04_data_access.Models;

namespace _04_data_access
{
    // Connection String - містить всю інформацію для підключення до сервера в певному форматі
    /* SQL Server:
        - Windows Authentication:    "Data Source=server_name;Initial Catalog=db_name;
                                     Integrated Security=True";
        - SQL Server Authentication: "Data Source=server_name;Initial Catalog=db_name;
                                     User ID=login;Password=password";
    */
    public class SportShopDB
    {
        private SqlConnection connection;
        private string connectionString;
        public SportShopDB(string connectionString)
        {
            this.connectionString = connectionString;
            //connectionString = $@"Data Source = {serverName};
            //                            Initial Catalog = {dbName};
            //                            Integrated Security = true;Connect Timeout = 2";
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Database is ready to work!");
        }

        //CRUD
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete
        public void Create(Product product)
        {
            //string cmdText = $@"INSERT INTO Products
            //                VALUES ('{product.Name}', 
            //                        '{product.Type}', 
            //                         {product.Quatity}, 
            //                         {product.CostPrice}, 
            //                        '{product.Producer}', 
            //                         {product.Price})";
            string cmdText = $@"INSERT INTO Products
                            VALUES (@name, 
                                    @type, 
                                    @quantity, 
                                    @costPrice, 
                                    @producer, 
                                    @price)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("type", product.Type);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("producer", product.Producer);
            cmd.Parameters.AddWithValue("price", product.Price);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Product was added to database!");
        }
        public void AddNewSalles(Sale s)
        {
            string cmdText = $@"INSERT INTO Salles
                               VALUES (@pro_id, 
                                       @price, @quantity,
                                       @e_id, @c_id,
                                       @sale_date)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("pro_id", s.ProductId);
            cmd.Parameters.AddWithValue("price", s.Price);
            cmd.Parameters.AddWithValue("quantity", s.Quantity);
            cmd.Parameters.AddWithValue("e_id", s.EmployeeId);
            cmd.Parameters.AddWithValue("c_id", s.ClientId);
            cmd.Parameters.AddWithValue("sale_date", s.SaleDate);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Sale was added to database!");
        }
        public List<Sale> GetAllSalles()
        {
            string cmdText = @"select * from Salles";

            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Sale> sales = new List<Sale>();

            while (reader.Read())
            {
                sales.Add(new Sale()
                {
                    Id = (int)reader[0],
                    ProductId = (int)reader[1],
                    Price = (decimal)reader[2],
                    Quantity = (int)reader[3],
                    EmployeeId = (int)reader[4],
                    ClientId = (int)reader[5],
                    SaleDate = (DateTime)reader[6]
                });
            }
            reader.Close();
            return sales;
        }
        public Sale GetLastSaleClient(string fullname)
        {
            string cmdText = $@"select top 1 * from Salles
                                where ClientId = (select Id from Clients where FullName = '{fullname}')
                                order by Date desc";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("fullname", System.Data.SqlDbType.NVarChar).Value = fullname;
            SqlDataReader reader = command.ExecuteReader();
            Sale sale = new Sale();

            while (reader.Read())
            {
                sale.Id = (int)reader[0];
                sale.ProductId = (int)reader[1];
                sale.Price = (decimal)reader[2];
                sale.Quantity = (int)reader[3];
                sale.EmployeeId = (int)reader[4];
                sale.ClientId = (int)reader[5];
                sale.SaleDate = (DateTime)reader[6];
            }
            reader.Close();
            return sale;
        }
        public void DeleteEmployee(int id)
        {
            string cmdText = $@"delete Employees where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        public void DeleteClient(int id)
        {
            string cmdText = $@"delete Clients where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }

        public Employee GetMostSaleEmployee()
        {
            string cmdText = $@"select * from Employees
                                where Id = (select top 1 EmployeeId
			                                from Salles
			                                group by EmployeeId 
			                                order by Sum(Price) desc)";
            Employee e = new Employee();

            SqlCommand cmd = new SqlCommand(cmdText,connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                e.Id = (int)reader[0];
                e.Fullname = (string)reader[1];
                e.HireDate = (DateTime)reader[2];
                e.Gender = (string)reader[3];
                e.Salary = (decimal)reader[4];
            }
            return e;
        }
        private List<Product> GetProductsByQuery(SqlDataReader reader)
        {
           
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public List<Product> GetAll()//Read
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
        }
        public Product GetOneProduct(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader).FirstOrDefault()!;
           
        }
        public List<Product> GetAllByName(string name)
        {
            //name = "Ball';drop database SportShop;--"
            //Ball';drop database SportShop;--
            string cmdText = $@"select * from Products where Name = '{name}'";

            SqlCommand command = new SqlCommand(cmdText, connection);
            //command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;
            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "name",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = name
            };
            command.Parameters.Add(parameter);

            SqlDataReader reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
        }
        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name =  @name, 
                                TypeProduct = @type, 
                                Quantity = @quantity, 
                                CostPrice = @costPrice, 
                                Producer = @producer, 
                                Price =@price
                                where Id = {product.Id}";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("type", product.Type);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("producer", product.Producer);
            cmd.Parameters.AddWithValue("price", product.Price);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Product was updated to database!");
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText,connection);
            command.ExecuteNonQuery();
        }
    }
}
