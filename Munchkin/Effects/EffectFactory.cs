using Munchkin.Cards;
using Munchkin.Events;
using Munchkin.Registries;

namespace Munchkin.Effects
{
    /// <summary>
    /// Simple helper to allow users to create effect definitions with events as generics
    /// </summary>
    public static class EffectFactory
    {
        public static EffectDefinition Create<TEvent>(Action<TEvent, GameAPI, CardInstance> action) where TEvent : IGameEvent
        {
            EffectDefinition effect = new()
            {
                EventType = typeof(TEvent),
                Action = (ev, ctx, source) => action.Invoke((TEvent)ev, ctx, source),
            };

            return effect;
        }

        public static EffectDefinition Create<TEvent>(Action<TEvent, GameAPI, CardInstance> action, Func<TEvent, GameAPI, CardInstance, bool> condition) where TEvent : IGameEvent
        {
            EffectDefinition effect = new()
            {
                EventType = typeof(TEvent),
                Action = (ev, ctx, source) => action.Invoke((TEvent)ev, ctx, source),
                Condition = (ev, ctx, source) => condition.Invoke((TEvent)ev, ctx, source),
            };

            return effect;
        }
    }
}
