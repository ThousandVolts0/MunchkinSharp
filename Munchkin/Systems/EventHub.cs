using Munchkin.Effects;
using Munchkin.Events;
namespace Munchkin.Systems
{
    public class EventHub
    {
        private readonly Dictionary<Type, List<Effect>> _handlers = new()
        {
            [typeof(OnTurnBegin)] = new List<Effect>(),
            [typeof(OnTurnEnd)] = new List<Effect>(),
            [typeof(OnCardPlayed)] = new List<Effect>()
        };
        private readonly GameContext _gameContext;

        public EventHub(GameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Subscribe<TEvent>(Effect effect) where TEvent : IGameEvent
        {
            Type eventType = typeof(TEvent);
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Effect>();
            }

            _handlers[eventType].Add(effect);
        }

        public void Unsubscribe<TEvent>(Effect effect)
        {
            Type eventType = typeof(TEvent);
            if (_handlers.ContainsKey(eventType))
            {
                _handlers[eventType].Remove(effect);
            }
        }

        public void Invoke(IGameEvent ev)
        {
            Type eventType = ev.GetType();
            if (!_handlers.ContainsKey(eventType))
                return;

            foreach (var effect in _handlers[eventType])
            {
                if (effect.Condition == null || effect.Condition(ev, _gameContext))
                {
                    effect.Action?.Invoke(ev, _gameContext);
                }
            }
        }
    }
}
