﻿using System;

namespace Rental.WebApi.Dto
{
    public class CompleteRentalDto
    {
        public Guid RentalGuidId { get; set; }
        public float PaidMoney { get; set; }
    }
}