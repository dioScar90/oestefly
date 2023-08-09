using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Entities;
using backend.Context;
using backend.Dtos;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    private IMapper _mapper { get; }

    public UserController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _context.Users.Where(u => u.IsActive == true).Include(u => u.Addresses.Where(a => a.IsActive == true)).ToListAsync();
        
        var convertedUsers = _mapper.Map<IEnumerable<UserDto>>(users);

        return Ok(convertedUsers);
    }

    private async Task<ActionResult<IEnumerable<Address>>> GetAddresses(int id)
    {
        var addresses = await _context.Addresses.Where(a => a.UserId == id && a.IsActive == true).ToListAsync();
        return addresses;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser([FromRoute] int id)
    {
        var user = await _context.Users.Include(u => u.Addresses.Where(a => a.IsActive == true)).FirstOrDefaultAsync(u => u.Id == id && u.IsActive == true);
        
        if (user is null)
            return NotFound();
        
        var convertedUser = _mapper.Map<UserDto>(user);
        
        return Ok(convertedUser);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
    {
        User newUser = _mapper.Map<User>(dto);
        Console.WriteLine("\n\n\n\n\n\n\n\n\npelo menos aqui\n\n\n\n\n\n\n\n\n");
        await _context.Users.AddAsync(newUser);
        int newId = await _context.SaveChangesAsync();

        Console.WriteLine($"\n\n\n\n\n\n\n\n\nNew Id => {newId}\n\n\n\n\n\n\n\n\n");

        var objOk = new {
            id = newUser.Id,
            message = "User created successfully"
        };
        
        return Ok(objOk);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    
        if (user is null)
            return NotFound();
        
        if (user.IsActive == false)
            return BadRequest("User had already been deleted.");
        
        user.IsActive = false;
        user.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();
        
        return Ok($"User {user.GetFullName()} deleted successfully.");
    }
}