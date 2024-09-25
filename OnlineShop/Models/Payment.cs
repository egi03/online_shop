using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    /// <summary>
    /// Specifies the payment methods available in the online shop.
    /// </summary>
    public enum PaymentMethod
    {
        VISA,
        MasterCard,
        AMEX
    }

    /// <summary>
    /// Represents a payment made in the online shop.
    /// </summary>
    /// <param name="Id">The unique identifier of the payment.</param>
    /// <param name="Method">The method used for the payment.</param>
    /// <param name="Buyer">The user who made the payment.</param>
    /// <param name="IsSuccessful">Indicates whether the payment was successful or not.</param>
    /// <param name="Amount">The amount of the payment.</param>
    public record Payment(int Id, PaymentMethod Method, User Buyer, bool IsSuccessful, decimal Amount);
}
