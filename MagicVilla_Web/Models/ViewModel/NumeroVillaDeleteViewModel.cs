using MagicVilla_Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.ViewModel
{
    public class NumeroVillaDeleteViewModel
    {

        public NumeroVillaDeleteViewModel()
        {
            NumeroVilla = new NumeroVillaDto();  // para el delete necesito el NumeroVillaDto principal
        }

        public NumeroVillaDto  NumeroVilla { get; set; }
        public IEnumerable<SelectListItem> VillaList { get; set; }



    }
}
