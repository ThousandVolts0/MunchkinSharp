using Munchkin.Cards;
using Munchkin.Events;
using Munchkin.Registries;

namespace Munchkin.Effects
{
    /// <summary>
    /// Simple helper to allow users to create effect definitions with events as generics
    /// </summary>
    public class EffectBuilder<TEvent> where TEvent : IGameEvent
    {
        private readonly EffectDefinition _instance;

        public EffectBuilder()
        {
            _instance = new EffectDefinition();
            _instance.EventType = typeof(TEvent);
        }

        public EffectBuilder<TEvent> Execute(Action<IGameEvent, GameAPI, CardInstance> action)
        {
            _instance.Action = (ev, ctx, source) => action.Invoke((TEvent)ev, ctx, source);
            return this;
        }

        public EffectBuilder<TEvent> When(Func<TEvent, GameAPI, CardInstance, bool> condition)
        {
            _instance.Condition = (ev, ctx, source) => condition.Invoke((TEvent)ev, ctx, source);
            return this;
        }

        public EffectBuilder<TEvent> WithPriority(int priority)
        {
            _instance.Priority = priority;
            return this;
        }

        public EffectDefinition Build()
        {
            return _instance;
        }
    }
}
