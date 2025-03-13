namespace Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()), // кастомный Id
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireHours = int.TryParse(_configuration["Jwt:ExpireHours"], out var hours) ? hours : 1;

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.UtcNow.AddHours(expireHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}





// namespace Service
// {
//     public class JwtService : IJwtService
//     {
//         private readonly IConfiguration _configuration;
//         public JwtService(IConfiguration configuration)
//         {
//             _configuration = configuration;
//         }

//         public string GenerateToken(User user)
//         {
//             var claims = new List<Claim>
//             {
//                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//                 new Claim(ClaimTypes.Name, user.Name),
//                 new Claim(ClaimTypes.Email, user.Email),
//                 new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddHours(1).ToString())
//             };

//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var token = new JwtSecurityToken(
//                 null,
//                 null,
//                 claims,
//                 expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:ExpireHours"])),
//                 signingCredentials: creds
//             );

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }
//     }
// }