using System.Collections;
using System.Collections.Generic;

public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable, IEnumerable<T>
{
    public CycledDynamicArray()
    {
        this.Length = CycledDynamicArray<T>.DefaultCapacity;
        this.Array = new T[this.Length];
        this.Enumerator = new CycledDynamicArrayEnumerator<T>(this);
    }

    public CycledDynamicArray(int cap)
    {
        this.Length = cap;
        this.Array = new T[this.Length];
        this.Enumerator = new CycledDynamicArrayEnumerator<T>(this);
    }

    public CycledDynamicArray(IEnumerable<T> collection)
    {
        foreach (T t in collection)
        {
            this.Length++;
        }

        this.Array = new T[this.Length];
        int i = 0;

        foreach (T t in collection)
        {
            this.Array[i] = t;
            i++;
        }

        this.Enumerator = new CycledDynamicArrayEnumerator<T>(this);
    }
}