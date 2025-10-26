using Microsoft.EntityFrameworkCore;

namespace BillsPieShopDemo.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BillsPieShopDbContext _billsPieShopDbContext;

        public PieRepository(BillsPieShopDbContext billsPieShopDbContext)
        {
            _billsPieShopDbContext = billsPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _billsPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _billsPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _billsPieShopDbContext.Pies.Include(c => c.Category).FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _billsPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
