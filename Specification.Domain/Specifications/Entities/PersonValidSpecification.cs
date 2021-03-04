﻿using Specification.Domain.Entities;
using Specification.Domain.Specifications.ValueObjects;
using Specification.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specification.Domain.Specifications.Entities
{
    public class PersonValidSpecification<T> : CompositeSpecification<T>
    {
        public override bool IsSatisfiedBy(T candidate)
        {
            var person = candidate as Person;

            var personNameSpecification = new PersonNameValidSpecification<Person>(true);
            if (!personNameSpecification.IsSatisfiedBy(person))
                return false;

            var emailSpecification = new EmailValidSpecification<Email>();
            if (!emailSpecification.IsSatisfiedBy(person?.Email))
                return false;

            return true;
        }
    }
}
