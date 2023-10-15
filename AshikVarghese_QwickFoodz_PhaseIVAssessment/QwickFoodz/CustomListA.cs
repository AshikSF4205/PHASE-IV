using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Partial Class used to CustomList Datatype creation
    /// </summary>

    public partial class CustomList<Type>
    {
        /// <summary>
        /// field for return the count of list <see cref="CustomList"/> class
        /// </summary>
        private int _count;
        /// <summary>
        /// field for return the size of list <see cref="CustomList"/> class
        /// </summary>
        private int _size;
        // property
        /// <summary>
        /// Property name used to get count of list
        /// </summary>
        /// <value>int returnType</value>
        public int Count { get { return _count; } }
        // property
        /// <summary>
        /// Property name used to get size/capacity of list
        /// </summary>
        /// <value>int returnType</value>
        public int Capacity { get { return _size; } }
        /// <summary>
        /// field for return the array of list <see cref="CustomList"/> class
        /// </summary>
        private Type[] _array;
        /// <summary>
        /// field for return the temp array of list <see cref="CustomList"/> class
        /// </summary>
        private Type[] temp;
        //Indexer
        public Type this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        // constructor
        /// <summary>
        /// Constructor used to get properties of list
        /// </summary>
        /// <param name="_size"></param>
        /// <param name="_count"></param>
        /// <param name="_array"></param>
        public CustomList()
        {
            _size = 4;
            _count = 0;
            _array = new Type[_size];
        }
        // constructor
        /// <summary>
        /// Constructor used to get properties of list
        /// </summary>
        /// <param name="_size"></param>
        /// <param name="_count"></param>
        /// <param name="_array"></param>
        public CustomList(int size)
        {
            _size = size;
            _count = 0;
            _array = new Type[_size];
        }
        // Add Method
        /// <summary>
        /// Method used to add elements to the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(Type data)
        {
            if (_count == _size)
            {
                GrowSize();
            }
            _array[_count] = data;
            _count++;
        }
        // GrowSize Method
        /// <summary>
        /// Method used to grow the size of the list
        /// </summary>
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
        
    }


}