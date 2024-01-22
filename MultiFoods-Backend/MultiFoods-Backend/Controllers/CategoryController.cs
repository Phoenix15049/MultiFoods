using Microsoft.AspNetCore.Mvc;
using MultiFoods_Backend.Models;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryController(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _categoryRepository.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _categoryRepository.GetCategoryById(id);

        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] CategoryDTO category)
    {
        _categoryRepository.CreateCategory(category);
        return CreatedAtAction(nameof(GetCategory), new { id = category.Category_ID }, category);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, [FromBody] CategoryDTO category)
    {
        var existingCategory = _categoryRepository.GetCategoryById(id);

        if (existingCategory == null)
            return NotFound();

        category.Category_ID = id;
        _categoryRepository.UpdateCategory(category);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var existingCategory = _categoryRepository.GetCategoryById(id);

        if (existingCategory == null)
            return NotFound();

        _categoryRepository.DeleteCategory(id);

        return NoContent();
    }
}
