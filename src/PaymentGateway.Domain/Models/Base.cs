﻿using System;

namespace PaymentGateway.Domain.Models
{ public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        public Base(Guid id, DateTime createdDate)
        {
            Id = id;
            CreatedDate = createdDate;
        }
    }
}