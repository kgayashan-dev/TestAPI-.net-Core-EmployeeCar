namespace WebApiEmployeeCar.Models;

public class User
{
    public int Id { get; set; } // Unique identifier for the user
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; // Store hashed password
    public string Role { get; set; } = string.Empty; // Store hashed password
    public string Email { get; set; } = string.Empty;
    

    // You can add more properties as needed (e.g., role, first name, etc.)
} 