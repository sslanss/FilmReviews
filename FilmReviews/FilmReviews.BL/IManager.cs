using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL
{
    public interface IManager<TModel, TCreateModel>
    {
        TModel Create(TCreateModel model);
        TModel Update(Guid id, TModel model);
        void Delete(Guid id);
    }
}
