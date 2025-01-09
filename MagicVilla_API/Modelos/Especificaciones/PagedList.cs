namespace MagicVilla_API.Modelos.Especificaciones
{
    public class PagedList<T> : List<T>        // va a ser una clase generica que recepta cualquier tipo de modelo que hereda de una lista generica
    {

        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize) // este constructor recibe una lista generica "items" y devuelve la cantidad de paginas totales
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)  // por ej. 1.5 lo transforma a 2, osea convierte al entero mayor
            };
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> entidad, int pageNumber, int pageSize)  // este metodo es el que recorta la info, recibe una lista, el numero de pagina que quiero y cuantos registros por pagina
        {
            var count = entidad.Count();
            var items = entidad.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
