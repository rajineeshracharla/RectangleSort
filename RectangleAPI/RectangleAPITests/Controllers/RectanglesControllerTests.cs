using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleAPI.Model;
using System.Collections.Generic;
using Xunit.Sdk;

namespace RectangleAPI.Controllers.Tests
{
    [TestClass()]
    public class RectanglesControllerTests
    {
        private List<Rectangle> GetTestRectangles()
        {
            var testRectangles = new List<Rectangle>
            {
                new Rectangle { Length = 50, Breadth = 10 },//Area=500
                new Rectangle { Length = 10, Breadth = 7.5M },//Area=75
                new Rectangle { Length = 20, Breadth = 5.5M },//Area=110
                new Rectangle { Length = 100, Breadth = 50 },//Area=5000
                new Rectangle { Length = 100, Breadth = 55.6M }//Area=5560
            };

            return testRectangles;
        }

        [TestMethod()]
        public void PostTest_RectanglesCountAreEqual()
        {
            var testRectangles = GetTestRectangles();
            var controller = new RectanglesController();

            var result = controller.Post(testRectangles); ;
            Assert.AreEqual(testRectangles.Count, result.Result.Value.Count);
        }

        [TestMethod()]
        public void PostTest_RectangleWithMaxArea()
        {
            var testRectangles = GetTestRectangles();
            var controller = new RectanglesController();

            var result = controller.Post(testRectangles); ;
            Assert.AreEqual(5560, result.Result.Value[0].Area);
        }

        [TestMethod()]
        public void PostTest_RectangleWithMinArea()
        {
            var testRectangles = GetTestRectangles();
            var controller = new RectanglesController();

            var result = controller.Post(testRectangles); ;
            Assert.AreEqual(75, result.Result.Value[4].Area);
        }

        [TestMethod()]
        public void PostTest_RectangleWithNoLength()
        {
            var testRectangles = GetTestRectangles();
            testRectangles.Add(new Rectangle {Breadth=2 });
            var controller = new RectanglesController();

            var result = controller.Post(testRectangles); ;
            Assert.AreEqual(0, result.Result.Value[5].Area);
        }
    }
}