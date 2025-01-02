using ProductsMS.Models.Domain;

namespace ProductsMS.Repositories.Abstract
{
    public interface IProductRepository
    {
        bool AddUpdate(Product Product);
        bool Delete(int id);

        Product GetById(int id);   
        IEnumerable<Product> GetAll(string name = "");

    }
}
