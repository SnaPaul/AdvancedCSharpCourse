using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpCourse
{
    //"where T : struct" means that T has to be a value type
    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable()
        {
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetVlaueOrDefault()
        {
            if(HasValue)
            {
                return (T)_value;
            }

            return default(T);
        }
    }
}
