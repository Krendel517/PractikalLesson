using MultiCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractikalLesson_1
{
    class SimpleBaseCalculator : SimpleCalculator
    {
    }
    class AgeBaseCalculator : AgeCalculator
    {
    }
    class TaxBaseCalculator : TaxCalculator
    {
    }

    public class BaseCalculator
    {
        public void BaseSimpleCalculator()
        {
            SimpleBaseCalculator simpleBase = new SimpleBaseCalculator();

            simpleBase.Start();
        }

        public void BaseAgeCalculator()
        {
            AgeBaseCalculator ageBase = new AgeBaseCalculator();
            ageBase.Start();
        }

        public void BaseTaxCalculator()
        {
            TaxBaseCalculator taxBase = new TaxBaseCalculator();
            taxBase.Start();
        }
    }
}
