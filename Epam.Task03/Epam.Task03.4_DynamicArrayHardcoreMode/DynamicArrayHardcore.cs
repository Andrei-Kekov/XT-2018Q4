using System;
using System.Collections;
using System.Collections.Generic;

public class DynamicArrayHardcore<T> : DynamicArray<T>, ICloneable, IEnumerable, IEnumerable<T>
{
    public DynamicArrayHardcore() : base()
    {
    }

    public DynamicArrayHardcore(T[] t) : base(t)
    {
    }

    public DynamicArrayHardcore(IEnumerable<T> collection) : base(collection)
    {
    }

    public new int Capacity
    {
        get
        {
            return base.Capacity;
        }

        set
        {
            T[] temp = new T[value];

            for (int i = 0; i < value; i++)
            {
                temp[i] = this.Array[i];
            }

            this.Array = temp;
            
            if (value < this.Length)
            {
                this.Length = value;
            }
        }
    }

    public new T this[int i]
    {
        get
        {
            return base[i >= 0 ? i : this.Length + i];
        }

        set
        {
            base[i >= 0 ? i : this.Length + i] = value;
        }
    }

    public object Clone()
    {
        return new DynamicArrayHardcore<T>(this);
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Length];

        for (int i = 0; i < this.Length; i++)
        {
            result[i] = this[i];
        }

        return result;
    }
}