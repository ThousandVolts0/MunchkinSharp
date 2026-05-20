using Munchkin.Effects;
using Munchkin.Events;
using System.Net;
namespace Munchkin.Systems
{
    public class EffectDispatcher
    {
        private readonly Dictionary<Type, List<EffectInstance>> _handlers = new()
        {
            [typeof(OnTurnBegin)] = new List<EffectInstance>(),
            [typeof(OnTurnEnd)] = new List<EffectInstance>(),
            [typeof(OnCardPlayed)] = new List<EffectInstance>()
        };
        private readonly GameAPI _gameApi;
        public EffectDispatcher(GameAPI gameApi)
        {
            _gameApi = gameApi;
        }

        public void Subscribe(EffectInstance effect)
        {
            Type eventType = effect.Definition.EventType;
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<EffectInstance>();
            }

            _handlers[eventType].Add(effect);
        }

        public void Subscribe(IEnumerable<EffectInstance> effects)
        {
            foreach (var effect in effects)
            {
                Subscribe(effect);
            }
        }

        public void Unsubscribe(EffectInstance effect)
        {
            Type eventType = effect.Definition.EventType;
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
                if (effect.Definition.Condition == null || effect.Definition.Condition(ev, _gameApi, effect.Source))
                {
                    effect.Definition.Action?.Invoke(ev, _gameApi, effect.Source);
                }
            }
        }
    }
}
