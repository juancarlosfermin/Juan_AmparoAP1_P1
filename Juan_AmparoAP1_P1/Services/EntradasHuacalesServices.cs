using Juan_AmparoAP1_P1.DAL;
using Juan_AmparoAP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Juan_AmparoAP1_P1.Services
{
    public class EntradasHuacalesServices
    {
        private readonly Contexto _contexto;

        public EntradasHuacalesServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
        {
            return await _contexto.EntradasHuacales
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}