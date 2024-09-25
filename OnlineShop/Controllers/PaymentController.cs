using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Repositories;

namespace OnlineShop.Controllers
{
    public class PaymentController
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentController(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void AddPayment(Payment payment)
        {
            _paymentRepository.AddPayment(payment);
            Console.WriteLine($"Payment with ID {payment.Id} added successfully.");
        }

        public Payment GetPayment(int id)
        {
            var payment = _paymentRepository.GetPayment(id);
            if (payment == null)
            {
                Console.WriteLine($"Payment with ID {id} not found.");
                return null;
            }
            Console.WriteLine($"Payment with ID {id} retrieved successfully.");
            return payment;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            var payments = _paymentRepository.GetAllPayments();
            Console.WriteLine("All payments retrieved successfully.");
            return payments;
        }
    }
}
