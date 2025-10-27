namespace AsistenteMedicoAPI.Auth
{
    public interface IJwAuthenticationService
    {
       
            //Metodo para autenticar al usuario y generar un token JWT
            string Authenticate(string username);
       
    }
}
