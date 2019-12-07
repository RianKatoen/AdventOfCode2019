using System.Collections.Generic;

namespace AOC2019.Modules.Fuel.ManagementSystem
{
    public interface IWire : IEnumerable<WireMovement>
    {
        WireMovement this[int index] { get; }

        string ToString();
    }
}