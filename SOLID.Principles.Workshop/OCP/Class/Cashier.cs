using System;
using System.Collections.Generic;
using System.Text;

namespace OCP.Class
{
    public sealed class Cashier
    {
        private readonly IWithdrawal _withdrawal;

        public Cashier(IWithdrawal withdrawal)
        {
            _withdrawal = withdrawal;
        }

        public decimal Withdraw(decimal amount)
        {
            // Logic to validate if withdrawal can actually be make

            return _withdrawal.Amount(amount);
        }
    }
}
