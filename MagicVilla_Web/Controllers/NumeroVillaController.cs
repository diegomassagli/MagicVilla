using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.ViewModel;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace MagicVilla_Web.Controllers
{
    public class NumeroVillaController : Controller
    {
        private readonly INumeroVillaService _numeroVillaService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public NumeroVillaController(INumeroVillaService numeroVillaService, IVillaService villaService, IMapper mapper)
        {
            _numeroVillaService = numeroVillaService;
            _villaService = villaService;
            _mapper = mapper;            
        }


        public async Task<IActionResult> IndexNumeroVilla()
        {
            List<NumeroVillaDto> numeroVillaList = new();
            var response = await _numeroVillaService.ObtenerTodos<APIResponse>();
            if(response != null && response.IsExitoso)
            {
                numeroVillaList = JsonConvert.DeserializeObject<List<NumeroVillaDto>>(Convert.ToString(response.Resultado));
            }
            return View(numeroVillaList);
        }


        public async Task<IActionResult> CrearNumeroVilla()
        {
            NumeroVillaViewModel numeroVillaVM = new();
            var response = await _villaService.ObtenerTodos<APIResponse>();
            if (response != null && response.IsExitoso)
            {
                numeroVillaVM.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Resultado))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Nombre,
                        Value = v.Id.ToString()
                    });
            }
            return View(numeroVillaVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearNumeroVilla(NumeroVillaViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                var response = await _numeroVillaService.Crear<APIResponse>(modelo.NumeroVilla);
                if (response != null && response.IsExitoso)
                {
                    TempData["exitoso"] = "Numero Villa Creado Exitosamente";
                    return RedirectToAction(nameof(IndexNumeroVilla));
                }
                else
                {
                    if(response.ErrorMessages.Count> 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            // si hay algo mal en el modelo, tengo que volver a llenar la lista para usar en el dropdown
            var res = await _villaService.ObtenerTodos<APIResponse>();
            if (res != null && res.IsExitoso)
            {
                modelo.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(res.Resultado))
                    .Select(v => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = v.Nombre,
                        Value = v.Id.ToString()
                    });
            }


            return View(modelo);
        }



    public async Task<IActionResult> ActualizarNumeroVilla(int villaNro)  // debe coincidir nombre metodo y parametro con lo que dice en el llamador: Views/NumeroVilla/IndexNumeroVilla
    {
            NumeroVillaUpdateViewModel numeroVillaVM = new();  // creo una instancia de mi viewModel y le doy un nombre

            var response = await _numeroVillaService.Obtener<APIResponse>(villaNro);
            if(response != null && response.IsExitoso)
            {
                NumeroVillaDto modelo = JsonConvert.DeserializeObject<NumeroVillaDto>(Convert.ToString(response.Resultado));
                numeroVillaVM.NumeroVilla = _mapper.Map<NumeroVillaUpdateDto>(modelo);
            }

            response = await _villaService.ObtenerTodos<APIResponse>();
            if (response != null && response.IsExitoso)
            {
                numeroVillaVM.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Resultado))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Nombre,
                        Value = v.Id.ToString()
                    });

                return View(numeroVillaVM);
            }
            return NotFound();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarNumeroVilla(NumeroVillaUpdateViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _numeroVillaService.Actualizar<APIResponse>(modelo.NumeroVilla);
                if (response != null && response.IsExitoso)
                {
                    TempData["exitoso"] = "Numero Villa actualizada Exitosamente";
                    return RedirectToAction(nameof(IndexNumeroVilla));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            // si hay algo mal en el modelo, tengo que volver a llenar la lista para usar en el dropdown
            var res = await _villaService.ObtenerTodos<APIResponse>();
            if (res != null && res.IsExitoso)
            {
                modelo.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(res.Resultado))
                    .Select(v => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Text = v.Nombre,
                        Value = v.Id.ToString()
                    });
            }


            return View(modelo);

        }



        public async Task<IActionResult> RemoverNumeroVilla(int villaNro)  // debe coincidir nombre metodo y parametro con lo que dice en el llamador: Views/NumeroVilla/IndexNumeroVilla
        {
            NumeroVillaDeleteViewModel numeroVillaVM = new();  // creo una instancia de mi viewModel y le doy un nombre

            var response = await _numeroVillaService.Obtener<APIResponse>(villaNro);
            if (response != null && response.IsExitoso)
            {
                NumeroVillaDto modelo = JsonConvert.DeserializeObject<NumeroVillaDto>(Convert.ToString(response.Resultado));
                numeroVillaVM.NumeroVilla = modelo;  // en este caso no necesito mapear porque es el mismo tipo
            }

            response = await _villaService.ObtenerTodos<APIResponse>();
            if (response != null && response.IsExitoso)
            {
                numeroVillaVM.VillaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Resultado))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Nombre,
                        Value = v.Id.ToString()
                    });

                return View(numeroVillaVM);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoverNumeroVilla(NumeroVillaDeleteViewModel modelo)
        {
            var response = await _numeroVillaService.Remover<APIResponse>(modelo.NumeroVilla.VillaNro);
            if(response != null && response.IsExitoso)
            {
                TempData["exitoso"] = "Numero Villa eliminada Exitosamente";
                return RedirectToAction(nameof(IndexNumeroVilla));  //si todo ok vuelvo a mostrar los que quedaron
            }
            TempData["error"] = "Un Error ocurrio al Remover";
            return View(modelo);  // si hubo un error, devuelvo el modelo
        }



    }
}
