using TesteSenior.Models;

namespace TesteSenior.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> GetPessoa();

        Task<List<Pessoa>> GetPessoaEstado(string estado);

        Task<Pessoa> GetPessoaId(int id);

        Task<Pessoa> PostPessoa(Pessoa pessoa);

        Task<Pessoa> PutPessoa(int id, Pessoa pessoa);

        Task<bool> DeletePessoa(int id);
    }
}
