using System.Collections.Generic;

namespace ServiceLib.Interfaces
{
    public interface IMenu<T>
    {
        IList<T> Items { get; set; }
        T ActiveItem {  get; set; }
    }
}