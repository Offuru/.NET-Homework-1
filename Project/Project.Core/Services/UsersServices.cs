using Project.Core.Mapping;
using Project.Database.Dtos.Request;
using Project.Database.Dtos.Response;
using Project.Database.Repositories;
using Project.Database.Entities;


namespace Project.Core.Services
{
    public class UsersServices
    {
        public UsersRepository UsersRepository { get; set; }
        public AuthService AuthService { get; set; }
        public RolesRepository RolesRepository { get; set; }
        public List<String> Admins { get; set; } = ["andrei.rozmarin@gmail.com"];

        public UsersServices(AuthService authService, UsersRepository usersRepository, RolesRepository rolesRepository)
        {
            AuthService = authService;
            UsersRepository = usersRepository;
            RolesRepository = rolesRepository;
        }

        public void Register(RegisterRequest registerData)
        {
            if(registerData == null)
            {
                return;
            }

            var salt = AuthService.GenerateSalt();
            var hashedPassword = AuthService.HashPassword(registerData.Password, salt);
            var user = new User();

            user.Password = hashedPassword;
            user.DateCreated = DateTime.UtcNow;
            user.PasswordSalt = Convert.ToBase64String(salt);
            user.Email = registerData.Email;
            user.Username = registerData.Username;

            bool isAdmin = Admins.Any(admin => admin == user.Email);

            if (isAdmin)
            {
                user.Role = RolesRepository.GetRoleById(1);
            }
            else
            {
                user.Role = RolesRepository.GetRoleById(2);
            }

            UsersRepository.Add(user);
        }

        public string Login(LoginRequest loginData)
        {
            var user = UsersRepository.GetByEmail(loginData.Email);

            if(AuthService.HashPassword(loginData.Password, Convert.FromBase64String(user.PasswordSalt)) == user.Password)
            {
                var role = user.Role.ToString();

                return AuthService.GetToken(user, role);
            }
            else
            {
                return null;
            }
        }

        public void AddUser(AddUserRequest payload)
        {
            var user = payload.ToEntity();
            UsersRepository.Add(user);
        }

        public void AddUsers(List<AddUserRequest> payload)
        {
            var users = payload.ToEntities();
            UsersRepository.AddRange(users);
        }

        public GetUserDetailsResponse GetUserDetails(int userId)
        {
            var user = UsersRepository.GetById(userId);
            var result = user.ToUserDto();

            return result;
        }
    }
}
