using MagicVilla_API.Datos;
using MagicVilla_API.Modelos.Especificaciones;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }


        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad); // agrega el registro
            await Grabar();                // hace el savechanges
        }

        public async Task Grabar()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true, string? incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;  // es una variable que significa que vamos a poder hacer consultas...
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filtro != null)
            {
                query = query.Where(filtro); // donde filtro es una expresion Linq
            }

            if(incluirPropiedades != null) // indica que necesitamos incluir los datos relacionados (se recibe una cadena como: "Villa,OtroModelo")
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, string? incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (incluirPropiedades != null) // indica que necesitamos incluir los datos relacionados (se recibe una cadena como: "Villa,OtroModelo")
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            return await query.ToListAsync();

        }


        public PagedList<T> ObtenerTodosPaginado(Parametros parametros, Expression<Func<T, bool>>? filtro = null, string? incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (incluirPropiedades != null) // indica que necesitamos incluir los datos relacionados (se recibe una cadena como: "Villa,OtroModelo")
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            return PagedList<T>.ToPagedList(query, parametros.PageNumber, parametros.PageSize);

        }



        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }


        // el Update no se incluye porque es mas especifico de cada entidad...


    }
}
