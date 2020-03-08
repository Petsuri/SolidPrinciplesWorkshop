using LSP.Exercise;

namespace LSP.UnitTests.Exercise
{
    public class LowerCaseStringOperationTest: StringOperationConditionsTest
    {
        protected override IStringOperation GetTestFixture()
        {
            return new LowerCaseStringOperation();
        }
    }
}
