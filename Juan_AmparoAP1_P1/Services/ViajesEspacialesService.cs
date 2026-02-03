using Juan_AmparoAP1_P1.DAL;
using Juan_AmparoAP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Juan_AmparoAP1_P1.Services
{
    public class ViajesEspacialesService
    {
        private readonly Contexto _contexto;

        public ViajesEspacialesService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
        {
            return await _contexto.ViajesEspaciales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}