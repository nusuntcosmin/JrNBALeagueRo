using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrNBALeagueRo.domain
{
    internal class Entity<T>
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
