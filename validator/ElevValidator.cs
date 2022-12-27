using JrNBALeagueRo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JrNBALeagueRo.exceptions;

namespace JrNBALeagueRo.validator
{
    internal class ElevValidator : IValidator<Elev>
    {
        public void validate(Elev e)
        {
            validateNume(e);
        }
        private void validateNume(Elev e) 
        {
            if (!Regex.IsMatch(e.Nume, "^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)"))
            {
                
            }
        }
        private void validateNumeScoala(Elev e)
        {

        }
    }
}
