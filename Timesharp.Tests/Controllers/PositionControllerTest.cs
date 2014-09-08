// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionControllerTest.cs" company="">
//   
// </copyright>
// <summary>
//   The position controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Tests.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Timesharp.Controllers;
    using Timesharp.Models;

    /// <summary>
    /// The position controller.
    /// </summary>
    [TestClass]
    public class PositionControllerTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get positions.
        /// </summary>
        [TestMethod]
        public void GetPositions()
        {
            var mockTimesharpDbContext = new Mock<ITimesharpDbContext>();
            var controller = new PositionController(mockTimesharpDbContext.Object);

            controller.GetPositions();

            mockTimesharpDbContext.VerifyGet(db => db.Positions, Times.AtMostOnce);
        }

        /// <summary>
        /// The get positions.
        /// </summary>
        [TestMethod]
        public void DeletePositionsWithExistingPosition()
        {
            var mockTimesharpDbContext = new Mock<ITimesharpDbContext>();
            var fakeId = 0;
            var fakePosition = new Position();
            var controller = new PositionController(mockTimesharpDbContext.Object);
            mockTimesharpDbContext.Setup(db => db.Positions.FindAsync(fakeId)).ReturnsAsync(fakePosition);
            
            controller.DeletePosition(fakeId);

            mockTimesharpDbContext.Verify(db => db.Positions.Remove(fakePosition), Times.AtMostOnce);
            mockTimesharpDbContext.Verify(db => db.SaveChangesAsync(), Times.AtMostOnce);
        }

        #endregion
    }
}