using System;
using System.Collections;
using System.Collections.Generic;

public class DynamicArray<T> : IEnumerable, IEnumerable<T>
{
    public DynamicArray()
    {
        this.Length = DefaultCapacity;
        this.Array = new T[this.Length];
        this.Enumerator = new DynamicArrayEnumerator<T>(this);
    }

    public DynamicArray(int cap)
    {
        this.Length = cap;
        this.Array = new T[this.Length];
        this.Enumerator = new DynamicArrayEnumerator<T>(this);
    }

    public DynamicArray(IEnumerable<T> collection)
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

        this.Enumerator = new DynamicArrayEnumerator<T>(this);
    }

    public static int DefaultCapacity
    {
        get
        {
            return 8;
        }
    }    

    public int Capacity
    {
        get
        {
            return this.Array.Length;
        }
    }

    public int Length { get; protected set; }

    protected DynamicArrayEnumerator<T> Enumerator { get; set; }

    protected T[] Array { get; set; }

    public T this[int i]
    {
        get
        {
            if (i >= this.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.Array[i];
        }

        set
        {
            if (i >= this.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Array[i] = value;
        }
    }

    public DynamicArray<T> Add(T t)
    {
        this.Extend(this.Length + 1);
        this.Array[this.Length] = t;
        return this;
    }

    public DynamicArray<T> AddRange(IEnumerable<T> range)
    {
        IEnumerator<T> range_enumerator = range.GetEnumerator();
        range_enumerator.Reset();
        int range_length = 0;

        foreach (T t in range)
        {
            range_length++;
        }

        this.Extend(this.Length + range_length);

        foreach (T t in range)
        {
            this.Add(t);
        }

        return this;
    }

    public bool Remove(T t)
    {
        int i;
        int j;
        bool success = false;

        for (i = 0; i < this.Length; i++)
        {
            if (this.Array[i].Equals(t))
            {
                this.Length--;

                for (j = i; j < this.Length; j++)
                {
                    this.Array[j] = this.Array[j + 1];
                }

                success = true;
            }
        }

        return success;
    }

    public bool Insert(T t, int position)
    {
        if (position > this.Length)
        {
            throw new ArgumentOutOfRangeException();
        }

        this.Extend(this.Length);

        for (int i = this.Length; i > position; i--)
        {
            this.Array[i] = this.Array[i - 1];
        }

        this.Array[position] = t;
        return true;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.Enumerator;
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return this.Enumerator;
    }

    private void Extend(int req_length)
    {
        if (req_length <= this.Array.Length)
        {
            return;
        }

        int new_cap = this.Array.Length;

        while (new_cap < req_length)
        {
            new_cap *= 2;
        }

        T[] temp = new T[new_cap];

        for (int i = 0; i < this.Array.Length; i++)
        {
            temp[i] = this.Array[i];
        }

        this.Array = temp;
    }    
}