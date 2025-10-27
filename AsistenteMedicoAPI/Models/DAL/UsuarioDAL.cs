using AsistenteMedicoAPI.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace AsistenteMedicoAPI.Models.DAL
{
    public class UsuarioDAL
    {
        // Inyecta tu Contexto de Base de Datos
         readonly AsistenteMedicoContext _context;

        // Constructor: Recibe el Contexto (Inyección de Dependencias)
        public UsuarioDAL(AsistenteMedicoContext context)
        {
            _context = context;
        }

        // Método para Autenticar (Reemplaza los métodos Create/Edit/Delete/Search del CRUD)
        // Su único propósito es verificar las credenciales y devolver el objeto AppUser.
        public async Task<Usuario?> Authenticate(string correo, string password)
        {
            // 1. Usa Entity Framework Core para buscar en la tabla 'Usuario'
            //    (mapeada a AppUsers) por Username y Password.

            var user = await _context.Usuarios
                                     .SingleOrDefaultAsync(u =>
                                         u.Correo == correo &&
                                         u.PasswordHash == password);

            // 2. Retorna el objeto AppUser completo si lo encuentra, o null si falla.
            return user;
        }

        public async Task<int> Create(Usuario usuarios)
        {
            _context.Add(usuarios);
            return await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> GetById(int id)
        {
            // El método ya devuelve null si no encuentra el paciente.
            // Usar el signo de interrogación `?` en el tipo de retorno indica que
            // el método puede devolver un valor nulo.
            return await _context.Usuarios.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<int> Edit(Usuario usuarios)
        {
            int result = 0;
            var usuarioUpdate = await GetById(usuarios.Id);
            if (usuarioUpdate.Id != 0)
            {
                //actualiza los datos del paciente
                usuarioUpdate.Id = usuarios.Id;
               usuarioUpdate.Correo = usuarios.Correo;
                usuarioUpdate.Status = usuarios.Status;
                usuarioUpdate.Rol = usuarios.Rol;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        public async Task<int> Delete(int id)
        {
            // Obtiene el paciente. Si no lo encuentra, devuelve null.
            var usuarioDelete = await GetById(id);

            // Si el objeto no es nulo, significa que el paciente fue encontrado.
            if (usuarioDelete != null)
            {
                _context.Usuarios.Remove(usuarioDelete);
                return await _context.SaveChangesAsync();
            }

            // Si el paciente no se encontró, devolvemos 0 para indicar que no hubo cambios.
            return 0;
        }
        private IQueryable<Usuario> Query(Usuario usuario)
        {
            var query = _context.Usuarios.AsQueryable();
            if (!string.IsNullOrWhiteSpace(usuario.Correo))
                query = query.Where(s => s.Correo.Contains(usuario.Correo));

            return query;
        }
        //metodo para contar la cantidad de resultados de busqueda con filtros
        public async Task<int> CountSearch(Usuario usuario)
        {
            return await Query(usuario).CountAsync();
        }
        //metodo para buscar clientes con filtros, paginacion y ordenamiento
        public async Task<List<Usuario>> Search(Usuario usuario, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(usuario);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();

        }
    }
}
