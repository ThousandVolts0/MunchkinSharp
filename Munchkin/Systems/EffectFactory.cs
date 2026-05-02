using Munchkin.Effects;
using Munchkin.Events;

namespace Munchkin.Systems
{
    public static class EffectFactory
    {
        public static Effect Create<TEvent>(string identifier, Action<TEvent, GameContext> action) where TEvent : IGameEvent
        {
            Effect effect = new()
            {
                EventType = typeof(TEvent),
                Action = (ev, ctx) => action.Invoke((TEvent)ev, ctx),
            };

            return effect;
        }

        public static Effect Create<TEvent>(string identifier, Action<TEvent, GameContext> action, Func<TEvent, GameContext, bool> condition) where TEvent : IGameEvent
        {
            Effect effect = new()
            {
                EventType = typeof(TEvent),
                Action = (ev, ctx) => action.Invoke((TEvent)ev, ctx),
                Condition = (ev, ctx) => condition.Invoke((TEvent)ev, ctx),
            };

            return effect;
        }
    }
}
