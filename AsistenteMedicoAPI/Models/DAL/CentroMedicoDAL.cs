using AsistenteMedicoAPI.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AsistenteMedicoAPI.Models.DAL
{
    public class CentroMedicoDAL
    {
        readonly AsistenteMedicoContext _context;

        // Constructor que recibe el contexto de la base de datos
        public CentroMedicoDAL(AsistenteMedicoContext context)
        {
            _context = context;
        }

        // Método para crear un nuevo centro médico
        public async Task<int> Create(CentroMedico centroMedico)
        {
            _context.Centrosmedicos.Add(centroMedico);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un centro médico por su ID
        public async Task<CentroMedico> GetById(int id)
        {
            var centroMedico = await _context.Centrosmedicos.SingleOrDefaultAsync(s => s.Id == id);
            return centroMedico;
        }

        // Método para editar un centro médico existente
        public async Task<int> Edit(CentroMedico centroMedico)
        {
            int result = 0;
            var centroUpdate = await GetById(centroMedico.Id);
            if (centroUpdate != null)
            {
                // Actualiza los datos del centro médico
                centroUpdate.Nombre = centroMedico.Nombre;
                centroUpdate.Direccion = centroMedico.Direccion;
                centroUpdate.Telefono = centroMedico.Telefono;
                centroUpdate.Email = centroMedico.Email;
                centroUpdate.SitioWeb = centroMedico.SitioWeb;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un centro médico por su ID
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var centroDelete = await GetById(id);
            if (centroDelete != null)
            {
                // Elimina el centro médico de la base de datos
                _context.Centrosmedicos.Remove(centroDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para buscar y obtener todos los centros médicos
        public async Task<List<CentroMedico>> GetAll()
        {
            return await _context.Centrosmedicos.ToListAsync();
        }

    }
}
