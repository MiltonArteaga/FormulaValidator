using FormulaValidator.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FormulaValidator.Tests
{
    [TestClass]
    public class UnitTestBracketValidator
    {
        private readonly IBracketValidator _validator = new BracketValidator();

        public static List<string> ReadMultiLineCommaSeparatedFormulas(string filePath)
        {
            var fullText = File.ReadAllText(filePath);
            var rawFormulas = fullText.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var cleanedFormulas = new List<string>();

            foreach (var raw in rawFormulas)
            {
                var trimmed = raw.Replace("\r", "").Replace("\n", "").Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    cleanedFormulas.Add(trimmed);
                }
            }

            return cleanedFormulas;
        }

        [TestMethod]
        public void TestWellFormedFormulas()
        {
            var formulas = ReadMultiLineCommaSeparatedFormulas("Well formed formulas.txt");
            foreach (var formula in formulas)
                Assert.IsTrue(_validator.IsWellFormed(formula), $"Failed: {formula}");
        }

        [TestMethod]
        public void TestBadFormedFormulas()
        {
            List<string> formulas = ReadMultiLineCommaSeparatedFormulas("Bad formed formulas.txt");
            foreach (string formula in formulas)
                Assert.IsFalse(_validator.IsWellFormed(formula), $"Failed: {formula}");
        }
    }
}
