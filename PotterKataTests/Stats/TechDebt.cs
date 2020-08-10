using System;
using System.Reflection;
using NUnit.Framework;
using PotterDiscount;
using TechDebtAttributes;

namespace PotterKataTests.Stats
{
    [TestFixture]
    public class TechDebt
    {
        [Test]
        public void ReportOnTechDebtAndFailTestIfTotalPainExceeded()
        {
            var assemblyContainingTechDebt = Assembly.GetAssembly(typeof(Book));

            //would need team / business descision as to how much pain we are willing to incur
            //find code hotspots see how often things change, also how easy is it to change this will give pain metric
            const int maximumPainInCodebaseThatWereWillingToLiveWith = 50;
            
            TechDebtReporter.AssertMaxPainNotExceeded(assemblyContainingTechDebt, maximumPainInCodebaseThatWereWillingToLiveWith);            
        }
        
        [Test]
        public void ShouldRenderReportWithMultipleAssemblies()
        {
            var assemblyToReportOn = new[]
            {
                Assembly.GetAssembly(typeof (Book))
            };

           string report = TechDebtReporter.GenerateReport(assemblyToReportOn);
           
           Console.Write(report);
        }
    }
}