using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApiEmployeeCar.Models;

namespace WebApiEmployeeCar.Repositories
{
    public class CarRepository
    {
        private readonly string _connectionString;

        public CarRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var cars = new List<Car>();
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_GetAllCars", connection)
                    { CommandType = CommandType.StoredProcedure };
                
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    cars.Add(new Car
                    {
                        Id = reader.GetInt32(0),
                        Make = reader.GetString(1),
                        Model = reader.GetString(2)
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while retrieving cars.", ex);
            }

            return cars;
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_GetCarById", connection)
                    { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Id", id);
                
                await connection.OpenAsync();
                using var reader = await command.ExecuteReaderAsync();
                return await reader.ReadAsync()
                    ? new Car
                    {
                        Id = reader.GetInt32(0),
                        Make = reader.GetString(1),
                        Model = reader.GetString(2)
                    }
                    : null;
            }
            catch (SqlException ex)
            {
                throw new Exception($"An error occurred while retrieving the car with ID {id}.", ex);
            }
        }

        public async Task CreateCarAsync(Car car)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_CreateCar", connection)
                    { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while creating the car.", ex);
            }
        }

        public async Task UpdateCarAsync(int id, Car car)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_UpdateCar", connection)
                    { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Make", car.Make);
                command.Parameters.AddWithValue("@Model", car.Model);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    throw new Exception("Car not found or no changes made.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while updating the car.", ex);
            }
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                using var command = new SqlCommand("sp_DeleteCar", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected > 0; // Return true if at least one row was affected
            }
            catch (SqlException ex)
            {
                throw new Exception("An error occurred while deleting the car from the database.", ex);
            }
        }

    }
}
