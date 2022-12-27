using JrNBALeagueRo.domain;
using JrNBALeagueRo.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JrNBALeagueRo.exceptions;
namespace JrNBALeagueRo.validator
{
    internal class EchipaValidator : IValidator<Echipa>
    {
        public void validate(Echipa e)
        {
            validateNumeEchipa(e);
        }

        private void validateNumeEchipa(Echipa e)
        {
            if (!Utils.existaEchipa(e.Nume))
                throw new ValidationException("Nume de echipa invalid");
        }
    }
}
