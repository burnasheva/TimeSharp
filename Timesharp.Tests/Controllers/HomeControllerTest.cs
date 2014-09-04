// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="">
//   
// </copyright>
// <summary>
//   The home controller test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Timesharp.Controllers;

    /// <summary>
    /// The home controller test.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The index.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }

        #endregion
    }
}