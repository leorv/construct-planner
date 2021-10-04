using Domain.Entities.Bidding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdditiveRepository : IRepository<Additive>
    {
        // Aqui definimos os métodos específicos de Additives. Por exemplo, GetDetalhes. etc.
    }
}
