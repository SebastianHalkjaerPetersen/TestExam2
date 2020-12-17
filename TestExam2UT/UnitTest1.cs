using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestExam2;
using TestExam2.Controllers;

namespace TestExam2UT
{
    [TestClass]
    public class UnitTest1
    {
        private MeasurementsController cntr = null;
        private Measurement i1 = null;
        private Measurement i2 = null;
        [TestInitialize]
        public void AtStartOfEachTest()
        {
            cntr = new MeasurementsController();
            i1 = new Measurement(2, 15,22);
            i2 = new Measurement(3, 13, 33);
        }
        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            //in AtStartOfEachTest();
            List<Measurement> list1 = new List<Measurement>();
            list1.Add(i1);
            list1.Add(i2);
            cntr.Post(i1);
            cntr.Post(i2);

            //act
            List<Measurement> measurements = new List<Measurement>(cntr.Get());

            //Assert
            Assert.AreEqual(list1, measurements);

            cntr.Delete(i1.Id);
            cntr.Delete(i2.Id);

        }

        [TestMethod]
        public void TestGetById()
        {
            //Arrange
            cntr.Post(i1);

            //act
            Measurement m1 = cntr.Get(1);

            //assert
            Assert.AreEqual(i1, m1);

            cntr.Delete(i1.Id);
        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange
            cntr.Post(i1);

            //act
            Measurement m1 = cntr.Get(1);

            //assert
            Assert.AreEqual(i1, m1);

            cntr.Delete(i1.Id);

        }

        [TestMethod]
        public void TestDelete()
        {
            //arrange
            cntr.Post(i1);
            cntr.Post(i2);

            //act
            cntr.Delete(i1.Id);
            List<Measurement> measurements = new List<Measurement>(cntr.Get());

            //assert
            Assert.IsTrue(measurements.Count == 1);

        }
    }
}
