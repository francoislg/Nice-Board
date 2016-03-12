using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nice_Board.Assembly
{
    internal class ClassFactory
    {
        public Type FindType(string p_TypeName)
        {
            return Type.GetType(p_TypeName, true);
        }

        public object CreateClass(Type p_Type, params object[] p_Params)
        {
            return Activator.CreateInstance(p_Type, p_Params);
        }
    }
}
