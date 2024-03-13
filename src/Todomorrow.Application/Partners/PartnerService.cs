using System;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.Partners;

namespace Todomorrow.Application.Partners
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly INotificationContext _notificationContext;
        public PartnerService(IPartnerRepository partnerRepository, INotificationContext notificationContext)
        {
            _partnerRepository = partnerRepository;
            _notificationContext = notificationContext;
        }

        private async Task<Partner> ValidatePartner(Guid partnerId)
        {
            Partner partner = await _partnerRepository.GetById(partnerId);
            if (partner is null)
            {
                _notificationContext.AddValidationError(PartnerError.PARTNER_NOT_FOUND);
                return null;
            }

            return partner;
        }

        public Task<Partner> Create(Partner partner)
        {
            throw new NotImplementedException();
        }

        public Task<Partner> GetById(Guid partnerId)
        {
            throw new NotImplementedException();
        }

        public Task<Partner> Update(Partner partner)
        {
            throw new NotImplementedException();
        }
    }
}
