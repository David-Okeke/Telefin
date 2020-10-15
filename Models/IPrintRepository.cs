using System.Linq;

namespace EarlyMan.Models
{
    public interface IPrintRepository
    {
        IQueryable<Print> Prints { get; }
    }
}