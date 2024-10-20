using BuberDinner.Domain.Common.Models;


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
        public static HostId Create(string value) => new HostId( new Guid(value));

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
