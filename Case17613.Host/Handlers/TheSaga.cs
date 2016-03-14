using System;
using Case17613.Messages;
using NServiceBus;
using NServiceBus.Saga;

namespace Case17613.Host.Handlers
{
    public class TheSaga : Saga<TheSagaData>, IAmStartedByMessages<StartTheSaga>, IHandleMessages<CompleteTheSaga>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<TheSagaData> mapper)
        {
            mapper.ConfigureMapping<StartTheSaga>(msg => msg.SagaId).ToSaga(saga => saga.SagaId);
            mapper.ConfigureMapping<CompleteTheSaga>(msg => msg.SagaId).ToSaga(saga => saga.SagaId);
        }

        public void Handle(StartTheSaga message)
        {
            Data.SagaId = message.SagaId;

            Data.Value = decimal.MinValue;

            Console.WriteLine("Saga " + Data.SagaId + " with value " + Data.Value + " has been started");
        }

        public void Handle(CompleteTheSaga message)
        {
            MarkAsComplete();

            Console.WriteLine("Saga " + Data.SagaId + " with value " + Data.Value + " has been completed");
        }
    }
}
