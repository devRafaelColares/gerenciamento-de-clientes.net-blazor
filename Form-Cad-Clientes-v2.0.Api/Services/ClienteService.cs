using Microsoft.EntityFrameworkCore;
using Formulario.Api.Data;
using Formulario.Api.Interfaces;
using Formulario.Core.DTOs;
using Formulario.Core.Requests;
using Formulario.Core.Models;
using Formulario.Core;
using Formulario.Core.Requests.Clientes;

namespace Formulario.Api.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        private ClienteDTO ConvertToDTO(Clientes cliente)
        {
            return new ClienteDTO
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Foto = cliente.Foto,
                Sexo = cliente.Sexo,
                Cidade = new CidadeDTO
                {
                    Id = cliente.Cidade.Id,
                    Nome = cliente.Cidade.Nome,
                    Estado = cliente.Cidade.Estado
                }
            };
        }

        private Clientes ConvertToEntity(CreateClienteRequest request, long cidadeId)
        {
            return new Clientes
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Foto = request.Foto,
                Sexo = request.Sexo,
                CidadeId = cidadeId
            };
        }

        public async Task<Response<ClienteDTO?>> CreateAsync(CreateClienteRequest request)
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

                var cliente = ConvertToEntity(request, cidade.Id);

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                var clienteDto = ConvertToDTO(cliente);

                return new Response<ClienteDTO?>(true, clienteDto, "Cliente criado com sucesso", 201);
            }
            catch (Exception ex)
            {
                return new Response<ClienteDTO?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<List<ClienteDTO>>> GetAllAsync()
        {
            try
            {
                var clientes = await _context.Clientes
                    .Include(c => c.Cidade)
                    .ToListAsync();

                var clienteDtos = clientes.Select(ConvertToDTO).ToList();

                return new Response<List<ClienteDTO>>(true, clienteDtos);
            }
            catch (Exception ex)
            {
                return new Response<List<ClienteDTO>>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<ClienteDTO?>> GetByIdAsync(long id)
        {
            try
            {
                var cliente = await _context.Clientes
                    .Include(c => c.Cidade)
                    .FirstOrDefaultAsync(c => c.Codigo == id);

                if (cliente == null)
                {
                    return new Response<ClienteDTO?>(false, null, "Cliente não encontrado", 404);
                }

                var clienteDto = ConvertToDTO(cliente);

                return new Response<ClienteDTO?>(true, clienteDto);
            }
            catch (Exception ex)
            {
                return new Response<ClienteDTO?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<ClienteDTO?>> UpdateAsync(long id, UpdateClienteRequest request)
        {
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Codigo == id);

                if (cliente == null)
                {
                    return new Response<ClienteDTO?>(false, null, "Cliente não encontrado", 404);
                }

                cliente.Nome = request.Nome;
                cliente.Telefone = request.Telefone;
                cliente.Foto = request.Foto;
                cliente.Sexo = request.Sexo;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                var clienteDto = ConvertToDTO(cliente);

                return new Response<ClienteDTO?>(true, clienteDto, "Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<ClienteDTO?>(false, null, ex.Message, 500);
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
