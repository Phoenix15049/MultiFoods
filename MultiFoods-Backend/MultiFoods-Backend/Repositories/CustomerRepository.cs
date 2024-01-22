using Dapper;
using MultiFoods_Backend.Models;
using MultiFoods_Backend.Services;
using System.Collections.Generic;
using System.Data;

public class CustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<CustomerDTO> GetAllCustomers()
    {
        using var dbConnection = _dbContext.GetConnection();
        return dbConnection.Query<CustomerDTO>("SELECT * FROM Customers");
    }

    public CustomerDTO GetCustomerById(int customerId)
    {
        using var dbConnection = _dbContext.GetConnection();
        return dbConnection.QueryFirstOrDefault<CustomerDTO>("SELECT * FROM Customers WHERE Customer_ID = @CustomerId", new { CustomerId = customerId });
    }

    public void CreateCustomer(CustomerDTO customer)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "INSERT INTO Customers (First_Name, Last_Name, Email, Phone, Password, Address) VALUES (@First_Name, @Last_Name, @Email, @Phone, @Password, @Address)";
        dbConnection.Execute(query, customer);
    }

    public void UpdateCustomer(CustomerDTO customer)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "UPDATE Customers SET First_Name = @First_Name, Last_Name = @Last_Name, Email = @Email, Phone = @Phone, Password = @Password, Address = @Address WHERE Customer_ID = @Customer_ID";
        dbConnection.Execute(query, customer);
    }

    public void DeleteCustomer(int customerId)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "DELETE FROM Customers WHERE Customer_ID = @CustomerId";
        dbConnection.Execute(query, new { CustomerId = customerId });
    }
}
