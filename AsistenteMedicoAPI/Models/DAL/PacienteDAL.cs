using AsistenteMedicoAPI.Models.EN;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace AsistenteMedicoAPI.Models.DAL
{
    public class PacienteDAL
    {
        readonly AsistenteMedicoContext _context;
        //constructor que recibe un objeto CRMContext para intereactuar con la base de datos
        public PacienteDAL(AsistenteMedicoContext context)
        {
            _context = context;
        }

        //metodo para crear un nuevo cliente en la base d datos
        public async Task<int> Create(Paciente pacientes)
        {
            _context.Add(pacientes);
            return await _context.SaveChangesAsync();
        }
        //metodo para obtener un paciente por su id
        public async Task<Paciente?> GetById(int id)
        {
            // El método ya devuelve null si no encuentra el paciente.
            // Usar el signo de interrogación `?` en el tipo de retorno indica que
            // el método puede devolver un valor nulo.
            return await _context.Pacientes.SingleOrDefaultAsync(s => s.Id == id);
        }
        //Metodo para editar un paciente existente en la base de datos
        public async Task<int> Edit(Paciente pacientes)
        {
            int result = 0;
            var pacienteUpdate = await GetById(pacientes.Id);
            if (pacienteUpdate.Id != 0)
            {
                //actualiza los datos del paciente
                pacienteUpdate.Id = pacientes.Id;
                pacienteUpdate.CentroId = pacientes.CentroId;
                pacienteUpdate.PrimerNombre = pacientes.PrimerNombre;
                pacienteUpdate.Apellido = pacientes.Apellido;
                pacienteUpdate.Telefono = pacientes.Telefono;
                pacienteUpdate.Email = pacientes.Email;
                pacienteUpdate.FechaNacimiento = pacientes.FechaNacimiento;
                pacienteUpdate.Genero = pacientes.Genero;
                pacienteUpdate.ContactoEmergencia = pacientes.ContactoEmergencia;
                pacienteUpdate.TelefonoEmergencia = pacientes.TelefonoEmergencia;
                pacienteUpdate.RecibirSms = pacientes.RecibirSms;
                pacienteUpdate.RecibirEmail = pacientes.RecibirEmail;
                //pacienteUpdate.NumeroPaciente = pacientes.NumeroPaciente;
                //pacienteUpdate.EstaActivo = pacientes.EstaActivo;
                //pacienteUpdate.FechaCreacion = pacientes.FechaCreacion;
                //pacienteUpdate.FechaActualizacion = DateTime.Now;
                //pacienteUpdate.UltimaVisita = pacientes.UltimaVisita;
                
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        //metodo para eliminar un producto de la base de datos por su ID
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var pacienteDelete = await GetById(id);
            if (pacienteDelete.Id > 0)
            {
                //elimina el producto de la base de datos
                _context.Pacientes.Remove(pacienteDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }
        // Replacing the problematic line in the Query method  
        private IQueryable<Paciente> Query(Paciente paciente)
        {
            var query = _context.Pacientes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(paciente.PrimerNombre))
                query = query.Where(s => s.PrimerNombre.Contains(paciente.PrimerNombre));

            if (!string.IsNullOrWhiteSpace(paciente.Apellido))
                query = query.Where(s => s.Apellido.Contains(paciente.Apellido));

            return query;
        }
        //metodo para contar la cantidad de resultados de busqueda con filtros
        public async Task<int> CountSearch(Paciente paciente)
        {
            return await Query(paciente).CountAsync();
        }
        //metodo para buscar clientes con filtros, paginacion y ordenamiento
        public async Task<List<Paciente>> Search(Paciente paciente, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(paciente);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();

        }
    }
}
