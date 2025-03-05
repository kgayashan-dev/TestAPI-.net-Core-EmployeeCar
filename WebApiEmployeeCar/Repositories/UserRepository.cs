using WebApiEmployeeCar.Models;
using Microsoft.Data.SqlClient;


namespace WebApiEmployeeCar.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
  
        }

        // Get all users using stored procedure
        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_GetAllUsers", connection)
                    { CommandType = System.Data.CommandType.StoredProcedure };
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Role = reader.GetString(3),
                        Password = reader.GetString(4) // Storing plain text password
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        // Get user by ID using stored procedure
        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_GetUserById", connection)
                    { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Id", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Role = reader.GetString(3),
                        Password = reader.GetString(4) // Storing plain text password
                    };
                }
            }

            return user;
        }

        // Add new user using the stored procedure (NO HASHING)
        public async Task AddUserAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_CreateUser", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Hash the password before storing it
                string hashedPassword = Encryption.Encrypt(user.Password);

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Email", user.Email);

                await command.ExecuteNonQueryAsync();
            }
        }


        // Update user using stored procedure (NO HASHING)
        public async Task UpdateUserAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_UpdateUser", connection)
                    { CommandType = System.Data.CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", user.Password); // Storing plain text password
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Role", user.Role);

                await command.ExecuteNonQueryAsync();
            }
        }

        // Delete user using stored procedure
        public async Task DeleteUserAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_DeleteUser", connection)
                    { CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            User user = null;
            string hashedPassword = Encryption.Encrypt(password); // Hash the password for comparison

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("sp_GetUserByUsernameAndPassword", connection)
                    { CommandType = System.Data.CommandType.StoredProcedure };

                // Ensure correct parameter names
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", hashedPassword); // Make sure it's PasswordHash here

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    // Don't pass password, just pass other details
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Role = reader.GetString(3),
                        // Exclude Password from being passed
                    };
                }
            }

            return user;
        }
    }
}