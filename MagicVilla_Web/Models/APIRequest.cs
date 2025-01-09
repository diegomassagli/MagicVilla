using static MagicVilla_Utilidad.DS;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;
        public string Url { get; set; }
        public object Datos { get; set; }
        public string Token {  get; set; }        
        public Parametros Parametros { get; set; }   // y ahora agrego una nueva propiedad a APIRequest de tipo "parametros"
    }


    public class Parametros   //agrego una nueva clase dentro de este nameSpace
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
