using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaValidator.Interfaces
{
    public interface IBracketValidator
    {
        bool IsWellFormed(string formula);
    }
}
