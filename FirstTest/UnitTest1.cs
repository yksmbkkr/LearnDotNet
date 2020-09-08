using System;
using FirstLib;
using Xunit;

namespace FirstTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var ob = new Addition();
            Assert.Equal("ok", ob.display());
        }
    }
}