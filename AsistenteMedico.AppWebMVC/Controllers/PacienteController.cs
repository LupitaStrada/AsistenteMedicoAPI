using AsistenteMedico.DTOs.PacienteDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsistenteMedico.AppWebMVC.Controllers
{
    public class PacienteController : Controller
    {
        private readonly HttpClient _httpClientAsistMedAPI;
        // GET: CustomerController
        public PacienteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientAsistMedAPI = httpClientFactory.CreateClient("AsistMedAPI");
        }

        public async Task<IActionResult> Index(SearchQueryPacienteDTO searchQueryPacienteDTO, int CountRow = 0)
        {
            //configuracion de valores por defecto para la busqueda
            if (searchQueryPacienteDTO.SendRowCount == 0)
                searchQueryPacienteDTO.SendRowCount = 2;
            if (searchQueryPacienteDTO.Take == 0)
                searchQueryPacienteDTO.Take = 10;
            var result = new SearchQueryPacienteDTO();

            //realizar una solicitud http post para buscar clientes en el servicio web
            var response = await _httpClientAsistMedAPI.PostAsJsonAsync("/paciente/search", searchQueryPacienteDTO);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchQueryPacienteDTO>();
            result = result != null ? result : new SearchQueryPacienteDTO();

            if (result.CountRow == 0 && searchQueryPacienteDTO.SendRowCount == 1)
                result.CountRow = CountRow;
            ViewBag.CountRow = result.CountRow;
            searchQueryPacienteDTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryPacienteDTO;
            return View(result);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultPacienteDTO();
            //realizar una solicitud http get para obtener los detalles del cliente por ID
            var response = await _httpClientAsistMedAPI.GetAsync("/paciente/" + id);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPacienteDTO>();
             r
            return View(result ?? new GetIdResultPacienteDTO());
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePacienteDTOs createPacienteDTOs)
        {
            try
            {
                var response = await _httpClientAsistMedAPI.PostAsJsonAsync("/paciente", createPacienteDTOs);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "Error al intentar guardar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultPacienteDTO();
            var response = await _httpClientAsistMedAPI.GetAsync("/paciente/" + id);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPacienteDTO>();

            return View(new EditPacienteDTO(result ?? new GetIdResultPacienteDTO()));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPacienteDTO editPacienteDTO)
        {
            try
            {
                var response = await _httpClientAsistMedAPI.PutAsJsonAsync("/paciente", editPacienteDTO);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "error al intentar editar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultPacienteDTO();
            var response = await _httpClientAsistMedAPI.GetAsync("/paciente/" + id);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPacienteDTO>();
            return View(result ?? new GetIdResultPacienteDTO());
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultPacienteDTO GetIdResultPacienteDTO)
        {
            try
            {
                //realizar una solicitud http delete para eliminar un cliente por id
                var response = await _httpClientAsistMedAPI.DeleteAsync("/paciente/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Error = "error al intentar eliminar el registro";
                return View(GetIdResultPacienteDTO);
            }
            catch (Exception ex)
            {
                {
                    ViewBag.Error = ex.Message;
                    return View(GetIdResultPacienteDTO);
                }
            }
        }
    }
}
