using OnlineShop.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Order
    {
        #region Properties

        public int Id { get; private set; }
        public User Buyer { get; private set; }
        public DateTime PlacedAt { get; private set; }
        public decimal Subtotal { get; private set; }
        public Dictionary<Product, int> Products { get; private set; } // Product : quantity
        public Payment Payment { get; private set; }

        #endregion

        #region Constructors
        public Order(int id, User buyer, DateTime placedAt, decimal subtotal, Dictionary<Product, int> products, Payment payment)
        {
            Id = id;
            Buyer = buyer ?? throw new ArgumentNullException(nameof(buyer), "Buyer cannot be null");
            PlacedAt = placedAt;
            Subtotal = subtotal >= 0 ? subtotal : throw new ArgumentOutOfRangeException(nameof(subtotal), "Subtotal cannot be negative");
            Products = products ?? throw new ArgumentNullException(nameof(products), "Products cannot be null");
            Payment = payment ?? throw new ArgumentNullException(nameof(payment), "Payment cannot be null");
        }

        #endregion

        #region Methods
        public string CreateReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("************************************");
            receipt.AppendLine("             RECEIPT                ");
            receipt.AppendLine("************************************");
            receipt.AppendLine($"Order ID: {Id}");
            receipt.AppendLine($"Buyer: {Buyer.Username}");
            receipt.AppendLine($"Date: {PlacedAt:yyyy-MM-dd HH:mm:ss}");
            receipt.AppendLine("------------------------------------");
            receipt.AppendLine("Products:");
            foreach (var entry in Products)
            {
                receipt.AppendLine($"{entry.Key.Name} - {entry.Value} x {entry.Key.Price:C} = {(entry.Value * entry.Key.Price):C}");
            }
            receipt.AppendLine("------------------------------------");
            receipt.AppendLine($"Subtotal: {Subtotal:C}");
            receipt.AppendLine($"Payment Method: {Payment.Method}");
            receipt.AppendLine($"Payment Verified: {Payment.IsSuccessful}");
            receipt.AppendLine("************************************");
            receipt.AppendLine("    THANK YOU FOR YOUR PURCHASE!    ");
            receipt.AppendLine("************************************");

            return receipt.ToString();
        }

        #endregion
    }
}
