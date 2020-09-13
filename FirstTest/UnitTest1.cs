using System;
using FirstLib;
using PRJ1 = FirstDotNetProject;
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
        
        [Fact]
        public void Test2()
        {
            var c1 = new Class1();
            Assert.Equal(0, c1.ret_val());
        }
        
        [Fact]
        public void Test3()
        {
            var p1 = new PRJ1.Program();
            Assert.Equal(0, p1.toTest());
        }
    }
}