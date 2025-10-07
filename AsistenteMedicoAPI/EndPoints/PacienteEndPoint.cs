using AsistenteMedicoAPI.Models.DAL;
using AsistenteMedico.DTOs.PacienteDTOs;
using AsistenteMedicoAPI.Models.EN;

namespace AsistenteMedicoAPI.EndPoints
{
    public static class PacienteEndPoint
    {
        public static void AddPacienteEndpoints(this WebApplication app)
        {
            //configurar un andpoint de tipo post para buscar pacientes
            app.MapPost("/paciente/search", async (SearchQueryPacienteDTO pacienteDTO, PacienteDAL pacienteDAL) =>
            {
                var paciente = new Paciente
                {
                    PrimerNombre = pacienteDTO.Nombre_Like != null ? pacienteDTO.Nombre_Like.ToString() : string.Empty, // Convertir el int a string
                    Telefono = pacienteDTO.Telefono_Like != null ? pacienteDTO.Telefono_Like.ToString() : string.Empty, // Convertir el int a string
                    Email = pacienteDTO.Email_Like != null ? pacienteDTO.Email_Like.ToString() : string.Empty, // Convertir el int a string
                };
              
                var pacientes = new List<Paciente>();
                int countRow = 0;
                if (pacienteDTO.SendRowCount == 2)

                {
                    pacientes = await pacienteDAL.Search(paciente, skip: pacienteDTO.Skip, take: pacienteDTO.Take);

                    if (pacientes.Count > 0)
                        countRow = await pacienteDAL.CountSearch(paciente);

                }
                else
                {
                    pacientes = await pacienteDAL.Search(paciente, skip: pacienteDTO.Skip, take: pacienteDTO.Take);
                }
                var pacienteResult = new SearchResultPacienteDTO
                {
                    Data = new List<SearchResultPacienteDTO.PacienteDTO>(),
                    CountRow = countRow
                };
                //mapear los resultados a objetos customeDAL y agregarlos al resultado
                pacientes.ForEach(s =>
                {
                    pacienteResult.Data.Add(new SearchResultPacienteDTO.PacienteDTO
                    {

                        Id = s.Id,
                        PrimerNombre = s.PrimerNombre,
                        Telefono = s.Telefono,
                        Email = s.Email,
                       Apellido = s.Apellido,

                    });
                });
                return pacienteResult;
            });
            app.MapGet("/paciente/{id}", async (int id, PacienteDAL pacienteDAL) =>
            {
                //obtener cliente por id
                var paciente = await pacienteDAL.GetById(id);
                //crear un objeto  getIdResultCustomerDTo
                var pacienteResult = new GetIdResultPacienteDTO
                {
                    Id = paciente.Id,
                    PrimerNombre = paciente.PrimerNombre,                
                    Telefono = paciente.Telefono,
                    Email = paciente.Email,
                    FechaNacimiento = paciente.FechaNacimiento,
                    Apellido = paciente.Apellido,
                    Genero = paciente.Genero,
                    ContactoEmergencia = paciente.ContactoEmergencia,
                    TelefonoEmergencia = paciente.TelefonoEmergencia,
                };
                if (pacienteResult.Id > 0)
                    return Results.Ok(pacienteResult);
                else
                    return Results.NotFound(pacienteResult);
            });
            //configurar un andpoint de tipo post para crear un nuevo paciente
            app.MapPost("/paciente", async (CreatePacienteDTOs pacienteDTO, PacienteDAL pacienteDAL) =>
            {
                //crear un objeto customer  a partir de los datos proporcionados
                var paciente = new Paciente
                {
                    CentroId = pacienteDTO.CentroId,
                    PrimerNombre = pacienteDTO.PrimerNombre,
                    Apellido = pacienteDTO.Apellido,
                    Telefono = pacienteDTO.Telefono,
                    Email = pacienteDTO.Email,
                    FechaNacimiento = pacienteDTO.FechaNacimiento, 
                    ContactoEmergencia = pacienteDTO.ContactoEmergencia,
                    TelefonoEmergencia = pacienteDTO.TelefonoEmergencia,
                    //RecibirSms = pacienteDTO.RecibirSms,
                    //RecibirEmail = pacienteDTO.RecibirEmails,
                    NumeroPaciente = pacienteDTO.NumeroPaciente,
                    EstaActivo = true,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    UltimaVisita = null
                };
                
                //intentar crear el cliente y devolver el resultado correspondiente
                int result = await pacienteDAL.Create(paciente);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
            //configurar el endpoint de tipo put para editar un cliente existente
            app.MapPut("/paciente", async (EditPacienteDTO pacienteDTO, PacienteDAL pacienteDAL) =>
            {
                var pacienteExistente = await pacienteDAL.GetById(pacienteDTO.Id);
                pacienteExistente.Apellido = pacienteDTO.Apellido;
                pacienteExistente.PrimerNombre = pacienteDTO.PrimerNombre;
                pacienteExistente.Telefono = pacienteDTO.Telefono;
                pacienteExistente.Email = pacienteDTO.Email;
                pacienteExistente.ContactoEmergencia = pacienteDTO.ContactoEmergencia;
                pacienteExistente.TelefonoEmergencia = pacienteDTO.TelefonoEmergencia;
                pacienteExistente.FechaActualizacion = DateTime.Now;
              

                int result = await pacienteDAL.Edit(pacienteExistente);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            ////app.MapPut("/paciente/updatenombre", async (UpdateNombrePacienteDTO paciente, PacienteDAL pacienteDAL) =>
            //{
            //    var pacienteExistente = await pacienteDAL.GetById(paciente.Id);
            //    //crear un objeto "customer" a partir de los datos proporcionados
            //     pacienteExistente.PrimerNombre = paciente.PrimerNombre;


            //    int result = await pacienteDAL.Edit(pacienteExistente);
            //    if (result != 0)
            //        return Results.Ok(result);
            //    else
            //        return Results.StatusCode(500);
            //});
            //configurar un endpoint de tipo delete para eliminar un cliente por su ID
            app.MapDelete("/paciente/{id}", async (int id, PacienteDAL pacienteDAL) =>
            {
                //intentar eliminar el cliente y devolver el resultado correspondiente
                int result = await pacienteDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

        }
    }
}
