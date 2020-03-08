using LSP.Exercise;

namespace LSP.UnitTests.Exercise
{
    public class UpperCaseStringOperationTest: StringOperationConditionsTest
    {
        protected override IStringOperation GetTestFixture()
        {
            return new UpperCaseStringOperation();
        }
    }
}
