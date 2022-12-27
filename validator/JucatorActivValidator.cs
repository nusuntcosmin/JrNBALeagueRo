using JrNBALeagueRo.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JrNBALeagueRo.exceptions;
namespace JrNBALeagueRo.validator
{
    internal class JucatorActivValidator : IValidator<JucatorActiv>
    {
        public void validate(JucatorActiv e)
        {
            validatePuncte(e);
        }

        private void validatePuncte(JucatorActiv e)
        {
            if(e.getNrPuncteInscrise<0 || e.Tip.Equals("Rezerva") && e.getNrPuncteInscrise >0)
            {
                throw new ValidationException("Numar de puncte invalid");
            }
        }
    }
}
