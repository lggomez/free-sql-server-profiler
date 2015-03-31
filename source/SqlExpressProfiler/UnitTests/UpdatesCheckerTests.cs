using NUnit.Framework;
using System;

namespace AnfiniL.SqlExpressProfiler.UnitTests
{
    [TestFixture]
    public class UpdatesCheckerTests
    {
        [Test]
        public void TestGetLatestVersion()
        {
            Version v = UpdatesChecker.GetLatestVersion();
            Assert.IsNotNull(v);
            Assert.Greater(v,  new Version("0.0.0.0"));
        }
    }
}
