using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaalLib
{
    public class RecordNotFoundException : ApplicationException
    {
        public RecordNotFoundException(){
        
        }

        public RecordNotFoundException(string msg): base(msg){
            
        }
    }
}
