﻿using System;
using Microsoft.VisualBasic;


namespace PaymentGateway.Domain.Models
{
    public class Payment : Base
    {
        public decimal Amount { get; }
        public CreditCard CreditCard { get; }

        public Status Status { get; private set; }

        public Payment(Guid id, decimal amount, CreditCard creditCard)
            : base(id)
        {
            Amount = amount;
            CreditCard = creditCard;
        }

        public Payment(Guid id, decimal amount, CreditCard creditCard, Status status, DateTime createdDate)
            : base(id, createdDate)
        {
            Amount = amount;
            CreditCard = creditCard;
            Status = status;
        }

        public void SuccessPayment()
        {
            Status = Status.Success;
        }

        public void ErrorPayment()
        {
            Status = Status.Error;
        }
    }
}