public class MyString
{
    private char[] ms;

    public MyString()
    {
        this.ms = new char[0];
    }

    public MyString(char c)
    {
        this.ms = new char[1];
        this.ms[0] = c;
    }

    public MyString(char[] c)
    {
        this.ms = new char[c.Length];
        
        for (int i = 0; i < c.Length; i++)
        {
            this.ms[i] = c[i];
        }
    }

    public MyString(string s)
    {
        this.ms = s.ToCharArray();
    }

    public int Length
    {
        get
        {
            return this.ms.Length;
        }
    }

    public char this[int i]
    {
        get
        {
            return this.ms[i];
        }

        set
        {
            this.ms[i] = value;
        }
    }

    public static bool operator ==(MyString ms1, MyString ms2)
    {
        if (ms1.Length != ms2.Length)
        {
            return false;
        }

        for (int i = 0; i < ms1.Length; i++)
        {
            if (ms1.ms[i] != ms2.ms[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator !=(MyString ms1, MyString ms2)
    {
        if (ms1.Length != ms2.Length)
        {
            return true;
        }

        for (int i = 0; i < ms1.Length; i++)
        {
            if (ms1.ms[i] != ms2.ms[i])
            {
                return true;
            }
        }

        return false;
    }

    public static MyString operator +(MyString ms1, MyString ms2)
    {
        char[] result = new char[ms1.Length + ms2.Length];
        int i;

        for (i = 0; i < ms1.Length; i++)
        {
            result[i] = ms1[i];
        }

        for (; i < result.Length; i++)
        {
            result[i] = ms2[i - ms1.Length];
        }

        return new MyString(result);
    }

    public static implicit operator char[](MyString ms1)
    {
        char[] result = new char[ms1.Length];

        for (int i = 0; i < ms1.Length; i++)
        {
            result[i] = ms1[i];
        }

        return result;
    }

    public static implicit operator string(MyString ms1)
    {
        return new string(ms1.ms);
    }

    public int Find(char c)
    {
        for (int i = 0; i < this.Length; i++)
        {
            if (this.ms[i] == c)
            {
                return i;
            }
        }

        return -1;
    }

    public override string ToString()
    {
        return new string(this.ms);
    }
}