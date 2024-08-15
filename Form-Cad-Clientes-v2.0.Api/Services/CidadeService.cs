using Formulario.Api.Interfaces;
using Formulario.Core.Requests;
using Formulario.Core.Responses;
using Formulario.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formulario.Core;
using Formulario.Api.Data;

namespace Formulario.Api.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly AppDbContext _context;

        public CidadeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CidadeDetalhesResponse?>> CreateAsync(CreateCidadeRequest request)
        {
            try
            {
                var cidade = new Cidades
                {
                    Nome = request.Nome,
                    Estado = request.Estado
                };

                await _context.Cidades.AddAsync(cidade);
                await _context.SaveChangesAsync();

                var cidadeResponse = new CidadeDetalhesResponse
                {
                    Id = cidade.Id,
                    Nome = cidade.Nome,
                    Estado = cidade.Estado
                };

                return new Response<CidadeDetalhesResponse?>(true, cidadeResponse, "Cidade criada com sucesso", 201);
            }
            catch (Exception ex)
            {
                return new Response<CidadeDetalhesResponse?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<Cidades?>> UpdateAsync(long id, UpdateCidadeRequest request)
        {
            try
            {
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cidade == null)
                {
                    return new Response<Cidades?>(false, null, "Cidade não encontrada", 404);
                }

                cidade.Nome = request.Nome;
                cidade.Estado = request.Estado;

                _context.Cidades.Update(cidade);
                await _context.SaveChangesAsync();

                return new Response<Cidades?>(true, cidade, "Cidade atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<Cidades?>(false, null, ex.Message, 500);
            }
        }


        public async Task<Response<bool>> DeleteAsync(long id)
        {
            try
            {
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cidade == null)
                {
                    return new Response<bool>(false, false, "Cidade não encontrada", 404);
                }

                _context.Cidades.Remove(cidade);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, true, "Cidade excluída com sucesso");
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, ex.Message, 500);
            }
        }

        public async Task<Response<CidadeDetalhesResponse?>> GetByIdAsync(long id)
        {
            try
            {
                var cidade = await _context.Cidades
                    .Include(c => c.Clientes)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cidade == null)
                {
                    return new Response<CidadeDetalhesResponse?>(false, null, "Cidade não encontrada", 404);
                }

                var cidadeResponse = new CidadeDetalhesResponse
                {
                    Id = cidade.Id,
                    Nome = cidade.Nome,
                    Estado = cidade.Estado,
                    Clientes = cidade.Clientes.Select(cliente => new ClienteResponse
                    {
                        Codigo = cliente.Codigo,
                        Nome = cliente.Nome,
                        Telefone = cliente.Telefone,
                        Foto = cliente.Foto,
                        Sexo = cliente.Sexo,
                        CreatedAt = cliente.CreatedAt
                    }).ToList()
                };

                return new Response<CidadeDetalhesResponse?>(true, cidadeResponse);
            }
            catch (Exception ex)
            {
                return new Response<CidadeDetalhesResponse?>(false, null, ex.Message, 500);
            }
        }

        public async Task<Response<List<CidadeDetalhesResponse>>> GetAllAsync()
        {
            try
            {
                var cidades = await _context.Cidades
                    .Include(c => c.Clientes)
                    .ToListAsync();

                var cidadeResponses = cidades.Select(c => new CidadeDetalhesResponse
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Estado = c.Estado,
                    Clientes = c.Clientes.Select(cliente => new ClienteResponse
                    {
                        Codigo = cliente.Codigo,
                        Nome = cliente.Nome,
                        Telefone = cliente.Telefone,
                        Foto = cliente.Foto,
                        Sexo = cliente.Sexo,
                        CreatedAt = cliente.CreatedAt
                    }).ToList()
                }).ToList();

                return new Response<List<CidadeDetalhesResponse>>(true, cidadeResponses);
            }
            catch (Exception ex)
            {
                return new Response<List<CidadeDetalhesResponse>>(false, null, ex.Message, 500);
            }
        }
    }
}
