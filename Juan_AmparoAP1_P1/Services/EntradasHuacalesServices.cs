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


        public async Task<bool> Guardar(EntradasHuacales entrada)
        {
            if (entrada.idEntrada == 0)
                return await Insertar(entrada);
            else
                return await Modificar(entrada);
        }

        private async Task<bool> Insertar(EntradasHuacales entrada)
        {
            _contexto.EntradasHuacales.Add(entrada);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EntradasHuacales entrada)
        {
            _contexto.Update(entrada);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entrada = await _contexto.EntradasHuacales.FindAsync(id);
            if (entrada != null)
            {
                _contexto.EntradasHuacales.Remove(entrada);
                return await _contexto.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<EntradasHuacales> Buscar(int id)
        {
            return await _contexto.EntradasHuacales
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.idEntrada == id);
        }

        public async Task<List<EntradasHuacales>> ObtenerTodos()
        {
            return await _contexto.EntradasHuacales
                .AsNoTracking()
                .ToListAsync();
        }
    }
}





