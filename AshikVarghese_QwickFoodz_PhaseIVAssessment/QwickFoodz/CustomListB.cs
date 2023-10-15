using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Partial Class used to CustomList Datatype creation
    /// </summary>
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        /// <summary>
        /// field for return the index of list <see cref="CustomList"/> class
        /// </summary>
        int i;
        // IEnumerator Method inherited from IEnumerator Interface
        /// <summary>
        /// Method used return index enumerator
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            i = -1;
            return (IEnumerator)this;
        }
        // MoveNext Method
        /// <summary>
        /// Method used return bool value to move
        /// </summary>
        public bool MoveNext()
        {
            if (i < _count - 1)
            {
                i++;
                return true;
            }
            Reset();
            return false;
        }
        /// <summary>
        ///  Property name used return current element
        /// </summary>
        public object Current { get { return _array[i]; } }
        // Reset Method
        /// <summary>
        /// Method used reset index
        /// </summary>
        public void Reset()
        {
            i = -1;
        }
    }

}