using FormulaValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaValidator
{
    public class BracketValidator : IBracketValidator
    {
        public bool IsWellFormed(string formula)
        {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (var c in formula)
            {
                if (pairs.ContainsValue(c))
                    stack.Push(c);
                else if (pairs.ContainsKey(c))
                {
                    if (stack.Count == 0 || stack.Pop() != pairs[c])
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
