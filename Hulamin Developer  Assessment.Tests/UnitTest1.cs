using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hulamin_Developer__Assessment.BusinessLogic;
using System;

namespace Hulamin_Developer__Assessment.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_Encrtpt()
        {
            var cryto = new EncryptDecryptBusinessLogic();

            string item = cryto.Encrypt("Password1");

            //if (item != "Pek06SyLOc7al7qfizp8NvokJ4/oE65XiI98LdxExFM=")
            //    throw new InvalidOperationException();
            Assert.AreEqual(item, "Pek06SyLOc7al7qfizp8NvokJ4/oE65XiI98LdxExFM=");
        }

        [TestMethod]
        public void Test_Decrypt()
        {
            var cryto = new EncryptDecryptBusinessLogic();

            string item = cryto.Decrypt("Pek06SyLOc7al7qfizp8NvokJ4/oE65XiI98LdxExFM=");

            if (item != "Password1")
                throw new InvalidOperationException();
            //Assert.AreEqual(item, "NRRcuUk6O05NevoLM59Y920l9g07E7Vqp4fW0REm5hc=");
        }
    }
}
