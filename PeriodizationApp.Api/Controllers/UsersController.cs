using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public record AuthRequest(string Username, string? Email, string Password);
        public record UserDto(Guid Id, string Username, string Email, DateTime CreatedAt);

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var dtos = users.Select(u => new UserDto(u.Id, u.Username, u.Email, u.CreatedAt));
            return Ok(dtos);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Debes ingresar un nombre de usuario y una contraseña.");
            }

            var existing = await _userRepository.GetByUsernameOrEmailAsync(request.Username);
            if (existing != null)
            {
                return Conflict("Ese nombre de usuario ya está registrado.");
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var existingEmail = await _userRepository.GetByUsernameOrEmailAsync(request.Email);
                if (existingEmail != null)
                {
                    return Conflict("Ese correo electrónico ya está registrado.");
                }
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username.Trim(),
                Email = string.IsNullOrWhiteSpace(request.Email)
                    ? $"{request.Username.Trim().ToLower()}@odysseus.app"
                    : request.Email.Trim(),
                PasswordHash = HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(newUser);
            return Ok(new UserDto(newUser.Id, newUser.Username, newUser.Email, newUser.CreatedAt));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                return BadRequest("Ingresa tu usuario o correo.");
            }

            var user = await _userRepository.GetByUsernameOrEmailAsync(request.Username);
            if (user == null)
            {
                return Unauthorized("Usuario no encontrado. Verifica tus datos o crea una cuenta nueva.");
            }

            // Si la cuenta existía antes del sistema de contraseñas (PasswordHash == null),
            // permitimos el acceso o guardamos la contraseña si proporcionó una
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                var incomingHash = HashPassword(request.Password ?? string.Empty);
                if (user.PasswordHash != incomingHash)
                {
                    return Unauthorized("Contraseña incorrecta.");
                }
            }

            return Ok(new UserDto(user.Id, user.Username, user.Email, user.CreatedAt));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (user.Id == Guid.Empty) user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;
            var newUser = await _userRepository.AddAsync(user);
            return Ok(new UserDto(newUser.Id, newUser.Username, newUser.Email, newUser.CreatedAt));
        }

        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes($"OdysseusSalt::{password}"));
            return Convert.ToHexString(bytes);
        }
    }
}
