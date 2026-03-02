using Juan_AmparoAP1_P1.DAL;
using Juan_AmparoAP1_P1.Models;
using Microsoft.EntityFrameworkCore;

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

            foreach (var detalle in entrada.EntradasDetalle)
            {
                var tipo = await _contexto.TiposHuacales.FindAsync(detalle.TipoId);
                if (tipo != null)
                    tipo.Existencia += detalle.Cantidad;
            }

            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(EntradasHuacales entrada)
        {
            var entradaOriginal = await _contexto.EntradasHuacales
                .Include(e => e.EntradasDetalle)
                .FirstOrDefaultAsync(e => e.idEntrada == entrada.idEntrada);

            if (entradaOriginal == null) return false;

            foreach (var detalleOriginal in entradaOriginal.EntradasDetalle)
            {
                var tipo = await _contexto.TiposHuacales.FindAsync(detalleOriginal.TipoId);
                if (tipo != null)
                    tipo.Existencia -= detalleOriginal.Cantidad;
            }

            _contexto.RemoveRange(entradaOriginal.EntradasDetalle);

            entradaOriginal.Fecha = entrada.Fecha;
            entradaOriginal.NombreCliente = entrada.NombreCliente;

            foreach (var detalleNuevo in entrada.EntradasDetalle)
            {
                var tipo = await _contexto.TiposHuacales.FindAsync(detalleNuevo.TipoId);
                if (tipo != null)
                    tipo.Existencia += detalleNuevo.Cantidad;

                entradaOriginal.EntradasDetalle.Add(detalleNuevo);
            }

            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entrada = await _contexto.EntradasHuacales
                .Include(e => e.EntradasDetalle)
                .FirstOrDefaultAsync(e => e.idEntrada == id);

            if (entrada != null)
            {
                foreach (var detalle in entrada.EntradasDetalle)
                {
                    var tipo = await _contexto.TiposHuacales.FindAsync(detalle.TipoId);
                    if (tipo != null)
                        tipo.Existencia -= detalle.Cantidad;
                }

                _contexto.EntradasHuacales.Remove(entrada);
                return await _contexto.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<EntradasHuacales> Buscar(int id)
        {
            return await _contexto.EntradasHuacales
                .Include(e => e.EntradasDetalle)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.idEntrada == id);
        }

        public async Task<List<EntradasHuacales>> ObtenerTodos()
        {
            return await _contexto.EntradasHuacales
                .Include(e => e.EntradasDetalle)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}