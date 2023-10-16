using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{


    // Partial Class used to CustomList Datatype creation
    public partial class CustomList<Type>
    {

        // field for return the count of list
        private int _count;

        // field for return the size of list
        private int _size;

        // property used to get count of list
        public int Count { get { return _count; } }

        // property name used to get size/capacity of list
        public int Capacity { get { return _size; } }

        // field for return the array of list 
        private Type[] _array;

        // field for return the temp array of list 
        private Type[] temp;

        //Indexer
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        //Constructor with default size - 4
        public CustomList()
        {
            _size = 4;
            _count = 0;
            _array = new Type[_size];
        }

        //Constructor with defined size
        public CustomList(int size)
        {
            _size = size;
            _count = 0;
            _array = new Type[_size];
        }

        //Add method used to add an element to the list
        public void Add(Type data)
        {
            if (_count == _size)
            {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }

        //GrowSize method used to increase the size of the list
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

        //AddRange Method used to add another CustomList at the end of the existing CustomList 
        public void AddRange(CustomList<Type> dataList)
        {
            _size += dataList.Capacity;
            temp = new Type[_size];
            int i, j = 0;
            for (i = 0; i < _count + dataList.Count; i++)
            {
                if (i < _count)
                {
                    temp[i] = _array[i];
                }
                else
                {
                    temp[i] = dataList[j];
                    j++;
                }
                

            }
            _array = temp;
            _count = _count + dataList.Count;
        }

    }
}