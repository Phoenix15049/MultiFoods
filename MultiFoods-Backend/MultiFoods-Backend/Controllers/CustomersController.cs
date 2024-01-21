using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MultiFoods_Backend.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


[ApiController]
[Route("api/Users")]
public class CustomerController : ControllerBase
{
    private readonly CustomerRepository _customerRepository;
    private readonly IConfiguration _configuration;

    public CustomerController(CustomerRepository customerRepository, IConfiguration configuration)
    {
        _customerRepository = customerRepository;
        _configuration = configuration;
    }
    [Authorize]
    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customers = _customerRepository.GetAllCustomers();
        return Ok(customers);
    }
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customerRepository.GetCustomerById(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }
    
    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerDTO customer)
    {
        _customerRepository.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Customer_ID }, customer);
    }
    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] CustomerDTO customer)
    {
        var existingCustomer = _customerRepository.GetCustomerById(id);

        if (existingCustomer == null)
            return NotFound();

        customer.Customer_ID = id;
        _customerRepository.UpdateCustomer(customer);

        return NoContent();
    }
    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var existingCustomer = _customerRepository.GetCustomerById(id);

        if (existingCustomer == null)
            return NotFound();

        _customerRepository.DeleteCustomer(id);

        return NoContent();
    }
    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDTO customer)
    {
        CustomerDTO dbUser = _customerRepository.GetAllCustomers().Where(x => x.Phone == customer.Phone && x.Password == customer.Password).FirstOrDefault();
        if (dbUser == null)
        {
            return BadRequest("invalid user name or password");
        }

        List<Claim> authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, dbUser.Phone.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, dbUser.Email.ToString()),
            new Claim(ClaimTypes.StreetAddress, dbUser.Address.ToString()),
        };
        var token = GetToken(authClaims);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo

        });

    }
    [HttpPost("Register")]
    public IActionResult Register([FromBody] CustomerDTO customer)
    {
        CustomerDTO dbUser = _customerRepository.GetAllCustomers().Where(x => x.Phone == customer.Phone || x.Email == customer.Email|| x.Customer_ID == customer.Customer_ID).FirstOrDefault();
        if(dbUser != null)
        {
            return BadRequest("alridm");
        }
        _customerRepository.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Customer_ID }, customer);
    }

    private JwtSecurityToken GetToken(List<Claim> authClaim)
    {
        var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            ) ;

        return token;
    }
}

