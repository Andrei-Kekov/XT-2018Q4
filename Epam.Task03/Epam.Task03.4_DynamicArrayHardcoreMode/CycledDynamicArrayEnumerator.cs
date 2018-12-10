using System.Collections.Generic;

public class CycledDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>, IEnumerator<T>
{
    public CycledDynamicArrayEnumerator(CycledDynamicArray<T> subject) : base(subject)
    {
    }

    public new bool MoveNext()
    {
        if (!base.MoveNext())
        {
            this.Reset();
        }

        return true;
    }
}
