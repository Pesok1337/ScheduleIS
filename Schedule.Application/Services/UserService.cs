using ScheduleIS.Application.Interfaces.Auth;
using ScheduleIS.Application.Interfaces.Services;
using ScheduleIS.Core.Abstractions;
using ScheduleIS.Core.Models;


namespace ScheduleIS.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            
            var user = User.Create(
                Guid.NewGuid(), 
                userName, 
                hashedPassword, 
                email);

            await _usersRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
