namespace Munchkin.Cards
{
    public class CardData
    {
        private Dictionary<string, object> _data = new();

        public object this[string key]
        {
            get => Get<object>(key);
            set => Set(key, value);
        }

        public bool ContainsKey(string key) => _data.ContainsKey(key);

        public void Set<T>(string key, T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(T), "Value cannot be null.");

            _data[key] = value;
        }

        public T Get<T>(string key)
        {
            if (_data.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            throw new KeyNotFoundException($"Key '{key}' not found or value is not of type {typeof(T).Name}.");
        }
    }
}
