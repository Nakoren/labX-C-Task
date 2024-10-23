using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public class CustomList<T>
{
    private T[] _list = new T[4];
    private int _length = 0;
    private int _maxSize = 4;

    private int Size
    {
        get => _list.Length;
    }

    public T Get(int index)
    {
        if ((index >= 0) && (index <= this._length))
        {
            return _list[index - 1];
        }
        return default;
    }

    public void Add(T num)
    {
        if (_length == _maxSize)
        {
            ExtendList();
            _length++;
            _list[_length - 1] = num;
        }
        else
        {
            _length++;
            _list[_length - 1] = num;
        }
    }
    public void RemoveValue(T val)
    {
        for (int i = 0; i < _length; i++)
        {
            if (_list[i].Equals(val))
            {
                ShiftLeft(i);
            }
        }
    }

    public void RemoveAt(int index)
    {
        if (index <= _length)
        {
            ShiftLeft(index - 1);
        }
    }
    public void Insert(int index, T val)
    {
        ShiftRight(index);
        _list[index - 1] = val;
    }
    private void ShiftLeft(int startIndex)
    {
        for (int i = startIndex; i < _length; i++)
        {
            if (i == _maxSize)
            {
                break;
            }
            if (i == _length)
            {
                _list[i] = default;
                break;
            }
            _list[i] = _list[i + 1];
        }
        _length--;
        if (_length == _maxSize / 2)
        {
            CompressList();
        }
    }

    private void ShiftRight(int startIndex)
    {
        if (_length == _maxSize)
        {
            ExtendList();
        }
        _length++;
        for (int i = _length; i >= startIndex; i--)
        {
            _list[i] = _list[i - 1];
        }
        _list[startIndex - 1] = default;
    }


    private void ExtendList()
    {
        _maxSize *= 2;
        T[] extended = new T[_maxSize];
        for (int i = 0; i < _length; i++)
        {
            extended[i] = _list[i];
        }
        _list = extended;
    }
    private void CompressList()
    {
        _maxSize /= 2;
        T[] compressed = new T[_maxSize];
        for (int i = 0; i < _length; i++)
        {
            compressed[i] = _list[i];
        }
        _list = compressed;
    }

    public void Clear()
    {
        _maxSize = 4;
        _length = 0;
        _list = new T[4];
    }

    public override string ToString()
    {
        if (_length == 0)
        {
            return "";
        }
        string resString = "";
        for (int i = 0; i < _length - 1; i++)
        {
            resString += _list[i].ToString() + " ";
        }
        resString += _list[_length - 1].ToString();
        return resString;
    }

    public int IndexOf(T item)
    {
        for(int i=0; i < _length; i++)
        {
            if (_list[i].Equals(item))
            {
                return i+1;
            }
        }
        return -1;
    }   
    
    public T? Find(System.Func<T, bool> findFunc)
    {
       for(int i=0;i < _length; i++)
        {
            if (findFunc.Invoke(_list[i]) == true)
            {
                return _list[i];
            }
        }
        return default;
    }

    public void Sort(System.Func<T, T, int> equalFunc)
    {
        for(int i=0;i< _length; i++)
        {
            for(int j=i; j< _length-i; j++)
            {
                if (equalFunc(_list[j], _list[j + 1]) == 1)
                {
                    T temp = _list[j];
                    _list[j] = _list[j + 1];
                    _list[j + 1] = temp;
                }
            }
        }
    }
}


