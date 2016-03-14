using System;
using NServiceBus.Saga;

namespace Case17613.Host.Handlers
{
    public class TheSagaData : ContainSagaData
    {
        [Unique]
        public Guid SagaId { get; set; }

        public decimal Value { get; set; }
    }
}