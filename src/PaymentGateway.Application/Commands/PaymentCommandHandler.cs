﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Dto;
using PaymentGateway.Dto.Response;
using PaymentGateway.Infrastructure;
using Domain = PaymentGateway.Domain.Models;

namespace Paymentgateway.Application.Commands
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCommand, PaymentResult>
    {
        private readonly IPaymentRepositoryResiliencePolicy _repository;
        public PaymentCommandHandler(IPaymentRepositoryResiliencePolicy repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResult> Handle(PaymentCommand command, CancellationToken cancellationToken)
        {
            var creditCard = new Domain.CreditCard(command.Payment.CreditCard.Name, command.Payment.CreditCard.Number,
                command.Payment.CreditCard.Month, command.Payment.CreditCard.Year, command.Payment.CreditCard.CVV);

            var payment = new Domain.Payment(command.Payment.Amount, creditCard);
            payment.SuccessPayment();

            var result = await _repository.Insert(payment);
            
            return await Task.FromResult(new PaymentResult
            {
                Id = payment.Id,
                Status = PaymentStatus.Success
            });
        }
    }
}