// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesControllerTest.cs" company="">
//   
// </copyright>
// <summary>
//   The values controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Timesharp.Controllers;

    /// <summary>
    /// The values controller test.
    /// </summary>
    [TestClass]
    public class ValuesControllerTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The delete.
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }

        /// <summary>
        /// The get.
        /// </summary>
        [TestMethod]
        public void Get()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        /// <summary>
        /// The post.
        /// </summary>
        [TestMethod]
        public void Post()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }

        /// <summary>
        /// The put.
        /// </summary>
        [TestMethod]
        public void Put()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        #endregion
    }
}