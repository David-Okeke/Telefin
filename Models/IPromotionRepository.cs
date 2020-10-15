using System.Linq;

namespace EarlyMan.Models
{
    public interface IPromotionRepository
    {
        IQueryable<Promotion> Promos { get; }
    }
}