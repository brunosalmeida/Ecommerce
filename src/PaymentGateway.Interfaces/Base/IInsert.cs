﻿using System.Threading.Tasks;
using PaymentGateway.Domain.Models;

namespace PaymentGateway.Domain.Interfaces.Base
{
    public interface IInsert
    {
        Task<int> Insert(Payment payment);
    }
}