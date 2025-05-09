using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Visitas.Dominio.Entidades;
using Visitas.Infraestructura.Repositorios;

namespace Visitas.Infraestructura.RepositoriosGenericos
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadBase
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private VisitasDBContext GetContext()
        { 
            return _serviceProvider.GetService<VisitasDBContext>();
        }

        protected DbSet<T> GetEntitySet()
        {
            return GetContext().Set<T>();
        }

        public async Task<T> Crear(T entity)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Actualizar(T entity)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            entitySet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> ObtenerPorId(object ValueKey)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.FindAsync(ValueKey);
            await _context.DisposeAsync();
            return res;
        }

        public async Task<List<T>> ObtenerPorFecha(DateTime ValueDate, Guid vendedorId)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.Where(v => EF.Property<DateTime>(v, "FechaVisita").Date == ValueDate.Date
                                            && EF.Property<Guid>(v, "IdVendedor") == vendedorId).ToListAsync();
            await _context.DisposeAsync();
            return res;
        }

        public async Task<List<T>> ObtenerPorGuid(Guid ValueAttribute, string Attribute)
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.Where(v => EF.Property<Guid>(v, Attribute) == ValueAttribute).ToListAsync();
            await _context.DisposeAsync();
            return res;
        }

        public async Task<List<T>> ObtenerTodos()
        {
            var _context = GetContext();
            var entitySet = _context.Set<T>();
            var res = await entitySet.ToListAsync();
            await _context.DisposeAsync();
            return res;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    var ctx = GetContext();
                    ctx.Dispose();
                }
                catch (Exception ex)
                { }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
