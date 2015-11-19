// Author: Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class GenericNode<T>
    {
        public GenericNode<T> Next
        {
            set;
            get;
        }

        public T Data
        {
            set;
            get;
        }
    }
}
