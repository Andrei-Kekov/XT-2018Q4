using System.Collections;
using System.Collections.Generic;

public class DynamicArrayEnumerator<T> : IEnumerator<T>
{
    private int i = 0;
    private DynamicArray<T> subject;

    public DynamicArrayEnumerator(DynamicArray<T> subject)
    {
        this.subject = subject;
    }

    object IEnumerator.Current
    {
        get
        {
            return this.subject[this.i] as object;
        }
    }

    T IEnumerator<T>.Current
    {
        get
        {
            return this.subject[this.i];
        }
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (this.i < this.subject.Length - 1)
        {
            this.i++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        this.i = 0;
    }
}