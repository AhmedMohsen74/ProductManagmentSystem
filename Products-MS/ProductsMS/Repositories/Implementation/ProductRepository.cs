using Microsoft.EntityFrameworkCore;
using ProductsMS.Models.Domain;
using ProductsMS.Repositories.Abstract;

namespace ProductsMS.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public bool AddUpdate(Product product)
        {
            try
            {

                if (product.Id == 0) 
                {
                    _context.Product.Add(product);
                }
                else
                {
                    var existingProduct = _context.Product.FirstOrDefault(p => p.Id == product.Id);
                    if (existingProduct != null)
                    {
                        existingProduct.Name = product.Name;
                        existingProduct.Description = product.Description;
                        existingProduct.Price = product.Price;
                        existingProduct.CategoryId = product.CategoryId;  
                                                              
                        existingProduct.CreatedDate = DateTime.Now;  
                        _context.Product.Update(existingProduct);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var record = GetById(id);
                if (record == null)
                {
                    return false;
                }
                _context.Product.Remove(record);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
      
        }
        public IEnumerable<Product> GetAll(string name = "")
        {
            var data = (from product in _context.Product
                        join category in _context.Category
                        on product.CategoryId equals category.Id
                        where string.IsNullOrEmpty(name) || product.Name.ToLower().Contains(name.ToLower())
                        select new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            CreatedDate = product.CreatedDate,
                            CategoryId = product.CategoryId,
                            CategoryName = category.Name,
                            Price = product.Price
                        }).ToList();
            return data;
        }

        public Product GetById(int id)
        {
            var product = _context.Product
                .FirstOrDefault(p => p.Id == id);
            return product;

        }
    }
}
