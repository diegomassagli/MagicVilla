namespace MagicVilla_API.Modelos.Especificaciones
{
    public class MetaData
    {
        // esta clase es la info adicional que voy a retornar: cuantas paginas totales, que tamaño cada pagina y la cant.total de registros de la tabla

        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; } // total de registros de la tabla

    }
}
