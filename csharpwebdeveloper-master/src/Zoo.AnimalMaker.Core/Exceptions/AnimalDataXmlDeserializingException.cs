using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AnimalMaker.Core.Exceptions
{
    public class AnimalDataXmlDeserializingException : Exception
    {
        public AnimalDataXmlDeserializingException(Exception innerException)
            : base(String.Format("Exception occured when deserializing data xml"), innerException)
        {
        }
    }
}
