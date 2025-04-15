using Repositories.Contracts;

namespace Entities.Models
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product entity);
    }
}