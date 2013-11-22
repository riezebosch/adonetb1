using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace WcfDemo.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new MijnWcfService();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
