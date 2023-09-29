using ecommercejogos.Data;
using ecommercejogos.Model;
using Microsoft.EntityFrameworkCore;

namespace ecommercejogos.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var produto = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);
                return produto;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Where(t => t.Nome.Contains(nome)).ToListAsync();
            return produto;
        }

        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categoria is not null)
            {
                var buscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (buscaCategoria == null)
                    return null;
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto?> Update(Produto produto)
        {
            var produtoUpdate = await _context.Produtos.FindAsync(produto.Id);

            if (produtoUpdate == null)
                return null;

            if (produto.Categoria is not null)
            {
                var buscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (buscaCategoria == null)
                    return null;
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;

            _context.Entry(produtoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);

            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Produto>> GetByPriceRange(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetByNomeOrConsole(string nome, string console)
        {
            throw new NotImplementedException();
        }
    }
}
