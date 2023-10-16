using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
   
    // Partial Class used to CustomList Datatype creation
    public partial class CustomList<Type> : IEnumerable, IEnumerator
    {
        //Index value for List
        int i;
       
       //Getting the Enumerator for the List
        public IEnumerator GetEnumerator()
        {
            i = -1;
            return (IEnumerator)this;
        }
        
        //List Traversing Method
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
       
       //Returns the current object of the list
        public object Current { get { return _array[i]; } }
        
        //Reset Index Value
        public void Reset()
        {
            i = -1;
        }
    }

}