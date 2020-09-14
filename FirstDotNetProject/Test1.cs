using FirstLib;
using Xunit;

namespace FirstDotNetProject
{
    public class Test1
    {
        [Fact]
        public void Test0()
        {
            var ob = new Addition();
            Assert.Equal("ok", ob.display());
        }
        
        [Fact]
        public void Test2()
        {
            var c1 = new Class1();
            Assert.NotEqual(0, c1.ret_val(5,5));
        }
        
        [Fact]
        public void Test3()
        {
            var p1 = new SampleClass();
            Assert.Equal(0, p1.toTest());
        }
        
        [Fact]
        public void Test4()
        {
            var p1 = new SampleClass();
            Assert.Equal(1, p1.toTest2());
        }
        
        [Fact]
        public void Test5()
        {
            var p1 = new SampleClass();
            Assert.Equal(2, p1.toTest3());
        }
    }
}