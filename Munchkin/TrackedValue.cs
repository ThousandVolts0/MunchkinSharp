using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Munchkin
{
    public class TrackedValue<T> where T : INumber<T>
    {
        List<(Operation, T)> _changes = new();

        public void Modify(Operation operation, T value)
        {
            _changes.Add((operation, value));
        }

        public T GetTotal()
        {
            _changes = _changes.OrderBy(x => x.Item1).ToList(); // Sorts by operation type

            T val = T.Zero;
            foreach (var change in _changes)
            {
                val = change.Item1 switch
                {
                    Operation.Add => val + change.Item2,
                    Operation.Subtract => val - change.Item2,
                    Operation.Multiply => val * change.Item2,
                    Operation.Divide => val / change.Item2,
                    _ => val
                };
            }

            return val;
        }
    }

    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
