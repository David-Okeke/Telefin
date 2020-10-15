using System.Linq;

namespace EarlyMan.Models
{
    public class EFPrintRepository : IPrintRepository
    {
        private ApplicationDbContext context;

        public EFPrintRepository(ApplicationDbContext cxt)
            => context = cxt;

        public IQueryable<Print> Prints
            => context.Prints;
    }
}