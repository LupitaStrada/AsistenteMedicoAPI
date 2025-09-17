using AsistenteMedicoAPI.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AsistenteMedicoAPI.Models.DAL
{
    public class CitaDAL
    {
        readonly AsistenteMedicoContext _context;

        // Constructor que recibe el contexto de la base de datos
        public CitaDAL(AsistenteMedicoContext context)
        {
            _context = context;
        }

        // Método para crear un nueva cita
        public async Task<int> Create(Cita cita)
        {
            _context.Citas.Add(cita);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener una cita por su ID
        public async Task<Cita> GetById(int id)
        {
            var cita = await _context.Citas.SingleOrDefaultAsync(s => s.Id == id);
            return cita;
        }

        // Método para editar una cita existente
        public async Task<int> Edit(Cita cita)
        {
            int result = 0;
            var citaUpdate = await GetById(cita.Id);
            if (citaUpdate != null)
            {
                // Actualiza los datos del centro médico
                citaUpdate.CentroId = citaUpdate.CentroId;
                citaUpdate.PacienteId = citaUpdate.PacienteId;
                citaUpdate.MedicoId = citaUpdate.MedicoId;
                citaUpdate.TipoCitaId = citaUpdate.TipoCitaId;
                citaUpdate.HoraInicio = citaUpdate.HoraInicio;
                citaUpdate.HoraFin = citaUpdate.HoraFin;
                citaUpdate.Estado = citaUpdate.Estado;
                citaUpdate.Motivo = citaUpdate.Motivo;
                citaUpdate.Notas = citaUpdate.Notas;
                citaUpdate.CreadaPor = citaUpdate.CreadaPor;
                citaUpdate.Precio = citaUpdate.Precio;
                citaUpdate.EstaPagada = citaUpdate.EstaPagada;
                citaUpdate.MetodoPago = citaUpdate.MetodoPago;                             
                citaUpdate.FechaActualizacion = DateTime.Now;
                citaUpdate.NotasMedicas = citaUpdate.NotasMedicas;
                citaUpdate.FechaCreacion = citaUpdate.FechaCreacion;
                citaUpdate.FechaCita = citaUpdate.FechaCita;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un centro médico por su ID
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var citaDelete = await GetById(id);
            if (citaDelete != null)
            {
                // Elimina el centro médico de la base de datos
                _context.Citas.Remove(citaDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        //metodo privado para construir una consulta IQueryable para buscar con filtros
        private IQueryable<Cita> Query(Cita cita)
        {
            var query = _context.Citas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(cita.PacienteId.ToString()))
                query = query.Where(s => s.PacienteId.ToString().Contains(cita.PacienteId.ToString()));
            if (!string.IsNullOrWhiteSpace(cita.MedicoId.ToString()))
                query = query.Where(s => s.MedicoId.ToString().Contains(cita.MedicoId.ToString()));
            return query;
        }

        public async Task<int> CountSearch(Cita cita)
        {
            return await Query(cita).CountAsync();
        }
        //metodo para buscar clientes con filtros, paginacion y ordenamiento
        public async Task<List<Cita>> Search(Cita cita, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(cita);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
        // Método para buscar y obtener todas las citas
        public async Task<List<Cita>> GetAll()
        {
            return await _context.Citas.ToListAsync();
        }
    }
}
