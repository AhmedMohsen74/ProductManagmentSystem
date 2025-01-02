using ProductsMS.Models.Domain;
using ProductsMS.Repositories.Abstract;

namespace ProductsMS.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public bool AddUpdate(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(category));
                }

                if (category.Id == 0)
                { 
                    _context.Category.Add(category);
                }
                else
                {
                    if (category.Id != 0)
                    {
                        var existingCategory = _context.Category.Find(category.Id);
                        if (existingCategory == null)
                        {
                            throw new KeyNotFoundException($"Category with Id {category.Id} not found");
                        }
                        _context.Entry(existingCategory).CurrentValues.SetValues(category);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
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
                _context.Category.Remove(record);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
      
        }

        public IEnumerable<Category> GetAll(string name = "")
        {
            var data = (from category in _context.Category
                        where string.IsNullOrEmpty(name) || category.Name.ToLower().Contains(name.ToLower())
                        select new Category
                        {
                            Id = category.Id,
                            Name = category.Name
                        }).ToList();
            return data;
        }

        public Category GetById(int id)
        {
            var Category = _context.Category.Find(id);
            return Category;

        }
    }
}
