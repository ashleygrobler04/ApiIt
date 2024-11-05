using lib;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestResultSuccess()
        {
            Result<string> res = Result<string>.Succeed("Operation successfull");
            //Hope it passes
            Assert.True(res.IsSuccess);
            Assert.NotNull(res.Data);
        }

        [Test]
        public void TestResultError()
        {
            Result<string> errorResult = Result<string>.Fail("Error");
            Assert.False(errorResult.IsSuccess);
            Assert.NotNull(errorResult.Data);
        }
    }
}