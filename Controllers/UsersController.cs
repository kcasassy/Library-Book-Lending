using System.Security.Claims;
using Library_Book_Lending.Data;
using Library_Book_Lending.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Book_Lending.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public UsersController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!int.TryParse(userIdValue, out var userId))
        {
            return Unauthorized(new { message = "Invalid user token." });
        }

        var user = await _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString(),
                MemberNumber = u.MemberNumber,
                MembershipExpiry = u.MembershipExpiry,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return NotFound(new { message = "User account not found." });
        }

        return Ok(user);
    }

    [HttpGet]
    [Authorize(Roles = "Librarian")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.Users
            .OrderBy(u => u.FullName)
            .Select(u => new UserResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString(),
                MemberNumber = u.MemberNumber,
                MembershipExpiry = u.MembershipExpiry,
                IsActive = u.IsActive,
                CreatedAt = u.CreatedAt
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpGet("staff")]
    [Authorize(Roles = "Librarian")]
    public IActionResult StaffAccess()
    {
        return Ok(new
        {
            message = "Librarian access granted.",
            role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    [HttpGet("member")]
    [Authorize(Roles = "Member")]
    public IActionResult MemberAccess()
    {
        return Ok(new
        {
            message = "Member access granted.",
            role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    [HttpGet("librarian")]
    [Authorize(Roles = "Librarian")]
    public IActionResult LibrarianAccess()
    {
        return Ok(new
        {
            message = "Librarian administrative access granted.",
            role = User.FindFirstValue(ClaimTypes.Role)
        });
    }
}