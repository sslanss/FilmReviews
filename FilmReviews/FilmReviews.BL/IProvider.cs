using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL
{
    public interface IProvider<TModel, TModelFilter> where TModelFilter : class
    {
        IEnumerable<TModel> Get(TModelFilter? modelFilter = null);
        TModel GetInfo(Guid id);
    }
}
