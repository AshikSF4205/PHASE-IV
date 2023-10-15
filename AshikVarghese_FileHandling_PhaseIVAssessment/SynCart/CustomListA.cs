using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SynCart;
public partial class CustomList<Type>
{
    //fields
    private int _count;

    private int _size;

    //Properties
    public int Count { get { return _count; } }

    public int Capacity { get { return _size; } }

    private Type[] _array;
    private Type[] temp;

    //Indexer
    public Type this[int index]
    {
        get { return _array[index]; }
        set { _array[index] = value; }
    }

    public CustomList()
    {
        _size = 4;
        _count = 0;
        _array = new Type[_size];
    }

    public CustomList(int size)
    {
        _size = size;
        _count = 0;
        _array = new Type[_size];
    }

    public void Add(Type data)
    {
        if (_count == _size)
        {
            GrowSize();
        }
        _array[_count] = data;
        _count++;
    }

    private void GrowSize()
    {
        _size *= 2;
        temp = new Type[_size];
        for (int i = 0; i < _count; i++)
        {
            temp[i] = _array[i];
        }
        _array = temp;
    }

    public void AddRange(CustomList<Type> dataList)
    {
        _size += dataList.Capacity;
        temp = new Type[_size];
        int i, j;
        for (i = 0; i < _count; i++)
        {
            temp[i] = _array[i];
        }
        i = 0;
        for (j = _count; j < _count + dataList.Count; j++)
        {
            temp[j] = dataList[i];
            i++;
        }
        _array = temp;
        _count = _count + dataList.Count;
    }

    public void Insert(int position, Type data)
    {

        _size++;
        temp = new Type[_size];
        for (int i = 0; i <= _count; i++)
        {
            if (i < position)
                temp[i] = _array[i];
            else if (i == position)
                temp[i] = data;
            else
                temp[i] = _array[i - 1];
        }
        _array = temp;
        _count++;
    }

    public void RemoveAt(int position)
    {

        for (int i = 0; i < _count; i++)
        {
            if (i >= position)
                _array[i] = _array[i + 1];
        }
        _array[_count - 1] = default;
        _count--;
    }

    public void InsertRange(int position, CustomList<Type> dataList)
    {
        _size += dataList.Capacity;
        temp = new Type[_size];
        int j = 0;
        for (int i = 0; i < _count + dataList.Count; i++)
        {
            if (i < position)
                temp[i] = _array[i];
            else if (i < position + dataList.Count)
            {
                temp[i] = dataList[j];
                j++;
            }
            else
                temp[i] = _array[i - j];


        }
        _array = temp;
        _count += dataList.Count;
    }

    public void RemoveRange(int position, int removeCount)
    {
        int i;
        for (i = 0; i < _count; i++)
        {
            if (i < position)
                continue;
            if (i >= position && i < _count - (position + removeCount))
                _array[i] = _array[i + removeCount];
            else
                _array[i] = default;
        }
        _count -= removeCount;
    }


}
