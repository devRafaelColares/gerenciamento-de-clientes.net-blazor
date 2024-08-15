using Microsoft.EntityFrameworkCore;
using Formulario.Api.Data;
using Formulario.Api.Interfaces;
using Formulario.Core.Requests;
using Formulario.Core.Responses;
using Formulario.Core.Models;
using Formulario.Core;

namespace Formulario.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Clientes?>> CreateAsync(CreateClienteRequest request)
        {
            try
            {
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.Nome == request.Cidade.Nome && c.Estado == request.Cidade.Estado);

                if (cidade == null)
                {
                    cidade = new Cidades
                    {
                        Nome = request.Cidade.Nome,
                        Estado = request.Cidade.Estado
                    };

                    _context.Cidades.Add(cidade);
                    await _context.SaveChangesAsync();
                }

                var cliente = new Clientes
                {
                    Nome = request.Nome,
                    Telefone = request.Telefone,
                    Foto = request.Foto,
                    Sexo = request.Sexo,
                    CidadeId = cidade.Id
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return new Response<Clientes?>(true, cliente, "Cliente criado com sucesso", 201);
            }
            catch (Exception ex)
            {
                return new Response<Clientes?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<List<Clientes>>> GetAllAsync()
        {
            try
            {
                var clientes = await _context.Clientes
                    .Include(c => c.Cidade)
                    .ToListAsync();

                return new Response<List<Clientes>>(true, clientes);
            }
            catch (Exception ex)
            {
                return new Response<List<Clientes>>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<Clientes?>> GetByIdAsync(long id)
        {
            try
            {
                var cliente = await _context.Clientes
                    .Include(c => c.Cidade)
                    .FirstOrDefaultAsync(c => c.Codigo == id);

                return cliente != null
                    ? new Response<Clientes?>(true, cliente)
                    : new Response<Clientes?>(false, null, "Cliente não encontrado", 404);
            }
            catch (Exception ex)
            {
                return new Response<Clientes?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<Clientes?>> UpdateAsync(long id, UpdateClienteRequest request)
        {
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Codigo == id);

                if (cliente == null)
                {
                    return new Response<Clientes?>(false, null, "Cliente não encontrado", 404);
                }

                cliente.Nome = request.Nome;
                cliente.Telefone = request.Telefone;
                cliente.Foto = request.Foto;
                cliente.Sexo = request.Sexo;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                return new Response<Clientes?>(true, cliente, "Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Clientes?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<bool>> DeleteAsync(long id)
        {
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Codigo == id);

                if (cliente == null)
                {
                    return new Response<bool>(false, false, "Cliente não encontrado", 404);
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, true, "Cliente excluído com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, ex.Message, 500);
            }
        }
    }
}
