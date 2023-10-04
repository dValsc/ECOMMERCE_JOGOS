using ecommercejogos.Model;

namespace ecommercejogos.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<IEnumerable<Produto>> GetByNomeOrConsole (string nome, string console);

        Task<IEnumerable<Produto>> GetByNomeandConsole(string nome, string console);

        Task<IEnumerable<Produto>> GetByPriceRange(decimal min, decimal max);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
