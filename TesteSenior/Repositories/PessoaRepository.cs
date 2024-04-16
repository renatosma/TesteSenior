using Microsoft.EntityFrameworkCore;
using TesteSenior.Datas;
using TesteSenior.Models;
using TesteSenior.Repositories.Interfaces;

namespace TesteSenior.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaDbContext _dbContext;

        public PessoaRepository(PessoaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pessoa>> GetPessoa()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }

        public async Task<List<Pessoa>> GetPessoaEstado(string estado)
        {
            return (await _dbContext.Pessoas.ToListAsync()).FindAll(c=>c.Estado.Contains(estado)).ToList();
        }

        public async Task<Pessoa> GetPessoaId(int id)
        {
            return await _dbContext.Pessoas.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<Pessoa> PostPessoa(Pessoa pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> PutPessoa(int id, Pessoa pessoa)
        {
            Pessoa pessoaId = await GetPessoaId(id);
            if (pessoaId == null)
            {
                throw new Exception($"O código da pessoa informada {id} não está cadastrado no banco de dados, favor verificar!");
            }
            if (pessoa.Id != pessoaId.Id)
            {
                throw new Exception($"O código da pessoa informada {id} é diferente da pessoa {pessoa.Id} a ser alterada!");
            }

            pessoaId.Nome = pessoa.Nome;
            pessoaId.cpfCnpj = pessoa.cpfCnpj;
            pessoaId.Cidade = pessoa.Cidade;
            pessoaId.Estado = pessoa.Estado;

            _dbContext.Pessoas.Update(pessoaId);
            await _dbContext.SaveChangesAsync();

            return pessoaId;
        }

        public async Task<bool> DeletePessoa(int id)
        {
            Pessoa pessoaId = await GetPessoaId(id);
            if (pessoaId == null)
            {
                throw new Exception($"O código da pessoa informada {id} não está cadastrado no banco de dados, favor verificar!");
            }

            _dbContext.Pessoas.Remove(pessoaId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
