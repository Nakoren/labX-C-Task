using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        CustomList CL = new CustomList();
        CL.add(3);
        int? test = CL.get(1);
        Console.WriteLine(test);
    }
}

public class CustomList
{
    private int[] list = new int[4];
    private int _length = 0;
    private int _maxSize = 4;

    private int size{
    get {
            return _length; 
        }
    }

    public int? get(int index)
    {
        if ((index >= 0) && (index <= this._length))
        {
            return list[index-1];
        }
        return null;
    }
    
    public void add(int num)
    {
        if (_length == _maxSize)
        {
            extendList();
            _length++;
            list[_length-1] = num;
        }
        else
        {
            _length++;
            list[_length-1] = num;
        }
    }
    public void removeValue(int val)
    {
        for(int i=0;i<_length; i++)
        {
            if (list[i] == val)
            {
                shiftLeft(i);
            }
        }
    }

    public void removeAt(int index)
    {
        if (index <= _length)
        {
            shiftLeft(index - 1);
        }
    }
    public void insert(int index, int val)
    {
        shiftRight(index);
        list[index - 1] = val;
    }
    private void shiftLeft(int startIndex)
    {
        for (int i = startIndex; i < _length; i++){
            if (i == _maxSize)
            {
                break;
            }
            if (i == _length)
            {
                list[i] = 0;
                break;
            }
            list[i] = list[i + 1];
        }
        _length--;
        if (_length == _maxSize / 2)
        {
            compressList();
        }
    }

    private void shiftRight(int startIndex)
    {
        if (_length == _maxSize)
        {
            extendList();
        }
        _length++;
        for (int i = _length; i >= startIndex; i--)
        {
            list[i] = list[i - 1];
        }
        list[startIndex - 1] = 0;
    }


    private void extendList()
    {
        _maxSize *= 2;
        int[] extended = new int[_maxSize];
        for (int i = 0; i < _length; i++)
        {
            extended[i] = list[i];
        }
        list = extended;
    }
    private void compressList()
    {
        _maxSize /= 2;
        int[] compressed = new int[_maxSize];
        for (int i = 0; i < _length; i++)
        {
            compressed[i] = list[i];
        }
        list = compressed;
    }

    public void clear()
    {
        _maxSize = 4;
        _length=0;
        list = new int[4];
    }

    public override string ToString()
    {
        if (_length == 0)
        {
            return "";
        }
        string resString = "";
        for(int i=0;i< _length-1; i++)
        {
            resString += list[i].ToString()+" ";
        }
        resString += list[_length - 1].ToString();
        return resString;
    }
}