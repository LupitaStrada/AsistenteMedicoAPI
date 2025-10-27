using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace AsistenteMedicoAPI.Auth
{
    public class JwtAuthenticationService : IJwAuthenticationService
    {
        private readonly string _key;
        public JwtAuthenticationService(string key)
        {
            _key = key;
        }
        public string Authenticate(string userName)
        {
            //crear un manejador de tokens
            var tokenHandler = new JwtSecurityTokenHandler();
            //convertir la clave en bytes utilizando codificacion ASCII
            var tokenkey = Encoding.ASCII.GetBytes(_key);
            //configurar la informacion del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //definir la identidad del token con el nombre del usuario
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, userName)

                }),
                //establecer la fecha de vencimiento ( 8 horas desde ahora)
                Expires = DateTime.UtcNow.AddHours(8),
                //configurar la clave de firma y el algoritmo de firma
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


            };
            //crear el token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //escribir el token como una cadena y devolverlo
            return tokenHandler.WriteToken(token);
        }

    }
}
