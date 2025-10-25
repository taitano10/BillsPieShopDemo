namespace BillsPieShopDemo.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly BillsPieShopDbContext _billsPieShopDbContext;
        public CategoryRepository(BillsPieShopDbContext billsPieShopDbContext)
        {
            _billsPieShopDbContext = billsPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _billsPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
