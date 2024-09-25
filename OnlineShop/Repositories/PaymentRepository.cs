using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories
{
    public class PaymentRepository
    {
        private readonly List<Payment> _payments = new List<Payment>();

        public void AddPayment(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));
            _payments.Add(payment);
        }

        public Payment GetPayment(int id) => _payments.FirstOrDefault(payment => payment.Id == id);

        public IEnumerable<Payment> GetAllPayments() => _payments;
    }
}
