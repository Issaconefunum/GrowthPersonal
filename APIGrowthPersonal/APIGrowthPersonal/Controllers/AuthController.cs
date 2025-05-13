// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.EntityFrameworkCore;
using APIGrowthPersonal.Models;
using System;
using Org.BouncyCastle.Crypto.Generators;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        // Проверка, существует ли пользователь
        if (await _context.Users.AnyAsync(u => u.username == model.Username))
            return BadRequest("Username already exists");

        // Хэширование пароля (используйте BCrypt или аналоги)
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

        var user = new User
        {
            username = model.Username,
            name = model.Name,
            secondName = model.SecondName,
            password = hashedPassword,
            id_class = model.IdClass
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.username == model.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.password))
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.username),
            new Claim("userId", user.id.ToString()),
            new Claim("name", user.name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

// DTO-классы
public class RegisterDto
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string Password { get; set; }
    public int? IdClass { get; set; }
}

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}