using System;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Partners
{
    public interface IPartnerService
    {
        Task<Partner> Create(Partner partner);
        Task<Partner> Update(Partner partner);
        Task<Partner> GetById(Guid partnerId);
    }
}
