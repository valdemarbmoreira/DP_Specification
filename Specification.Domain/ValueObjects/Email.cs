﻿using Specification.Domain.Specifications.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int AddressMinLength = 3;
        public const int AddressMaxLength = 255;

        public Email(string address)
        {
            Address = address;
            ValidSpecification = new EmailValidSpecification<object>();
        }

        public string Address { get; }

        public override string ToString() => Address;
    }
}
