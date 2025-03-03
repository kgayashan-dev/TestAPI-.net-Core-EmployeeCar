// using WebApiEmployeeCar.Repositories;
//
//  builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container
// builder.Services.AddControllers();
//
// // Register repositories
// builder.Services.AddScoped<CarRepository>();
// // Remove UserRepository if it doesn't exist
// builder.Services.AddScoped<UserRepository>();
// builder.Services.AddScoped<EmployeeRepository>();
//
// // Add other services and configurations
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// // Configure CORS to allow specific origins
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowSpecificOrigin", policy =>
//     {
//         policy.WithOrigins("http://localhost:3000") // Replace with your frontend URL
//             .AllowAnyMethod()
//             .AllowAnyHeader()
//             .AllowCredentials();
//     });
// });
//
// // Add services for authentication and authorization
// // Note: You should configure a specific authentication scheme here
// builder.Services.AddAuthentication();
// builder.Services.AddAuthorization();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// // Set the HTTPS port explicitly
// app.UseHttpsRedirection();
//
// // Other middlewares
// app.UseCors("AllowSpecificOrigin");
// app.UseAuthentication();
// app.UseAuthorization();
//
// app.MapControllers();
// app.Run();