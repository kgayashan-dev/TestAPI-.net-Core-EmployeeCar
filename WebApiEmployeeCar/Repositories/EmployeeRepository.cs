using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiEmployeeCar.Models;

namespace WebApiEmployeeCar.Repositories
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_GetAllEmployees", connection)
                    { CommandType = CommandType.StoredProcedure };

                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving employees.", ex);
            }

            return employees;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_GetEmployeeById", connection)
                    { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                return await reader.ReadAsync()
                    ? new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    }
                    : null;
            }
            catch (SqlException ex)
            {
                throw new Exception($"An error occurred while retrieving the employee with ID {id}.", ex);
            }
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_CreateEmployee", connection)
                    { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the employee.", ex);
            }
        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_UpdateEmployee", connection)
                    { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Address", employee.Address);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    throw new Exception("Employee not found or no changes made.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the employee.", ex);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_DeleteEmployee", connection)
                    { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the employee.", ex);
            }
        }
    }
}
