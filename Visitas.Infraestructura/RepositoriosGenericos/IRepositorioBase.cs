using Visitas.Dominio.Entidades;

namespace Visitas.Infraestructura.RepositoriosGenericos
{
    public interface IRepositorioBase<T> : IDisposable where T : EntidadBase
    {
        Task<T> Crear(T entidad);
        Task Actualizar(T entidad);
        Task<T> ObtenerPorId(object ValueKey);
        Task<List<T>> ObtenerPorFecha(DateTime ValueDate);
        Task<List<T>> ObtenerPorGuid(Guid ValueAttribute, string Attribute);
        Task<List<T>> ObtenerTodos();
    }
}
