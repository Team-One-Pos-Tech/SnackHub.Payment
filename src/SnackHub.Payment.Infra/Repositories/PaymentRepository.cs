using Domain = SnackHub.Payment.Domain.Entities;
using SnackHub.Payment.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnackHub.Payment.Infra.interfaces;
using SnackHub.Payment.Infra.Contexts;

namespace SnackHub.Payment.Infra.Repositories
{
    public class PaymentRepository : Repository<Domain.Entities.Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentContext context) : base(context)
        {
        }
    }
}
