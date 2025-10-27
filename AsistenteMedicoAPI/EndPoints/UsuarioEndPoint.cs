using AsistenteMedico.DTOs.PacienteDTOs;
using AsistenteMedico.DTOs.UsuarioDTO;
using AsistenteMedicoAPI.Models.DAL;
using AsistenteMedicoAPI.Models.EN;
using System.Security.Claims;

namespace AsistenteMedicoAPI.EndPoints
{
    public static  class UsuarioEndPoint
    {
        public static void AddUsuarioEndpoints(this WebApplication app)
        {
            //configurar un andpoint de tipo post para buscar pacientes
            app.MapPost("/usuario/search", async (SearchQueryUsuarioDTO usuarioDTO, UsuarioDAL usuarioDAL) =>
            {
                var usuario = new Usuario
                {
                    Correo = usuarioDTO.Email_Like != null ? usuarioDTO.Email_Like.ToString() : string.Empty, // Convertir el int a string
               
                };

                var usuarios = new List<Usuario>();
                int countRow = 0;
                if (usuarioDTO.SendRowCount == 2)

                {
                    usuarios = await usuarioDAL.Search(usuario, skip: usuarioDTO.Skip, take: usuarioDTO.Take);

                    if (usuarios.Count > 0)
                        countRow = await usuarioDAL.CountSearch(usuario);

                }
                else
                {
                    usuarios = await usuarioDAL.Search(usuario, skip: usuarioDTO.Skip, take: usuarioDTO.Take);
                }
                var usuarioResult = new SearchResultUsuarioDTO
                {
                    Data = new List<SearchResultUsuarioDTO.UsuarioDTO>(),
                    CountRow = countRow
                };
                //mapear los resultados a objetos customeDAL y agregarlos al resultado
                usuarios.ForEach(s =>
                {
                    usuarioResult.Data.Add(new SearchResultUsuarioDTO.UsuarioDTO
                    {

                        Id = s.Id,
                        Correo = s.Correo,
                        Status = s.Status.ToString(), // Convertir byte a string
                        Rol = s.Rol,
                      
                    });
                });
                return usuarioResult;
            });
            app.MapGet("/usuario/{id}", async (int id, UsuarioDAL usuarioDAL) =>
            {
                //obtener cliente por id
                var usuario = await usuarioDAL.GetById(id);
                //crear un objeto  getIdResultCustomerDTo
                var usuarioResult = new GetidResultUsuarioDTO 
                {
                    Id = usuario.Id,
                    Correo = usuario.Correo,
                    Status = usuario.Status.ToString(), // Convertir byte a string
                    Rol = usuario.Rol,
                };
                
                if (usuarioResult.Id > 0)
                    return Results.Ok(usuarioResult);
                else
                    return Results.NotFound(usuarioResult);
            });
            //configurar un andpoint de tipo post para crear un nuevo paciente
            app.MapPost("/usuario", async (CreateUsuarioDTO usuarioDTO, UsuarioDAL usuarioDAL) =>
            {
                //crear un objeto customer  a partir de los datos proporcionados
                var usuario = new Usuario
                {
                    Correo = usuarioDTO.Correo,
                    Status = usuarioDTO.Status,
                    Rol = usuarioDTO.Rol,
                 
                };

                //intentar crear el cliente y devolver el resultado correspondiente
                int result = await usuarioDAL.Create(usuario);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
            //configurar el endpoint de tipo put para editar un cliente existente
            app.MapPut("/usuario", async (EditUsuarioDTO usuarioDTO, UsuarioDAL usuarioDAL) =>
            {
                var usuarioExistente = await usuarioDAL.GetById(usuarioDTO.Id);
                usuarioExistente.Correo = usuarioDTO.Correo;
                usuarioExistente.Rol = usuarioDTO.Rol;
                usuarioExistente.Status = usuarioDTO.Status;
               

                int result = await usuarioDAL.Edit(usuarioExistente);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            app.MapDelete("/usuario/{id}", async (int id, UsuarioDAL usuarioDAL) =>
            {
                //intentar eliminar el cliente y devolver el resultado correspondiente
                int result = await usuarioDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

        }

    }
}
