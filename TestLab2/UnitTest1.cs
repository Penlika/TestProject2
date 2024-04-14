using SQSV_lab2;
using FluentAssertions;

namespace TestLab2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float income = 100000000;
            float dependentQty = 2;    
            float expectedResult = 0.035F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 9850000;

           
            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            
            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForNoDependent_ShouldBeCorrect()
        {
            float income = 20000000;
            float dependentQty = 0;  
            float expectedResult = 0.02F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 3250000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForMultipleDependents_ShouldBeCorrect()
        {
            float income = 50000000;
            float dependentQty = 3;  
            float expectedResult = 0.02F * (income - TaxCalculator.MONTHLY_REDUNDANT - dependentQty * TaxCalculator.DEPENDENT_REDUNDANT) - 3250000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForZeroIncome_ShouldBeZero()
        {
            float income = 0;
            float dependentQty = 1;
            float expectedResult = 0;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForIncomeFromZeroToFiveMillion_ShouldBeCorrect()
        {
            float income = 3000000;
            float dependentQty = 1;
            float expectedResult = 0.005F * income;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }


        [TestMethod]
        public void Calculate_TaxForIncomeFromFiveMillionToTenMillion_ShouldBeCorrect()
        {
            float income = 8000000;
            float dependentQty = 1;
            float expectedResult = 0.01F * income - 250000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

        [TestMethod]
        public void Calculate_TaxForIncomeAboveEightyMillion_ShouldBeCorrect()
        {
            float income = 90000000;
            float dependentQty = 1;
            float expectedResult = 0.035F * income - 9850000;

            float actualResult = TaxCalculator.Calculate(income, dependentQty);

            actualResult.Should().BeApproximately(expectedResult, 0.01f);
        }

    }
}