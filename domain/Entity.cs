using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    public class Entity<T> 
    {
        private T id;
        
        public T ID
        {
            get 
            {
                return id; 
            }
            set 
            {
                id = value; 
            }
        }

    }
}
