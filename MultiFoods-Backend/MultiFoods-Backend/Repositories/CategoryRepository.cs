using Dapper;
using MultiFoods_Backend.Services;
using MultiFoods_Backend.Models;
using System.Collections.Generic;
using System.Data;

public class CategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<CategoryDTO> GetAllCategories()
    {
        using var dbConnection = _dbContext.GetConnection();
        return dbConnection.Query<CategoryDTO>("SELECT * FROM Categories");
    }

    public CategoryDTO GetCategoryById(int categoryId)
    {
        using var dbConnection = _dbContext.GetConnection();
        return dbConnection.QueryFirstOrDefault<CategoryDTO>("SELECT * FROM Categories WHERE Category_ID = @CategoryId", new { CategoryId = categoryId });
    }

    public void CreateCategory(CategoryDTO category)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "INSERT INTO Categories (Category_ID,Category_Name) VALUES (@Category_ID,@Category_Name)";
        dbConnection.Execute(query, category);
    }

    public void UpdateCategory(CategoryDTO category)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "UPDATE Categories SET Category_Name = @Category_Name WHERE Category_ID = @Category_ID";
        dbConnection.Execute(query, category);
    }

    public void DeleteCategory(int categoryId)
    {
        using var dbConnection = _dbContext.GetConnection();
        const string query = "DELETE FROM Categories WHERE Category_ID = @CategoryId";
        dbConnection.Execute(query, new { CategoryId = categoryId });
    }
}
