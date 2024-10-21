﻿using BuberDinner.Domain.Common.Models;


namespace BuberDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; private set; }
        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique() => new(Guid.NewGuid());
        public static HostId Create(string value) => Create(new Guid(value));
        public static HostId Create(Guid value) => new HostId(value);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
