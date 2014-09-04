// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionController.cs" company="">
//   
// </copyright>
// <summary>
//   The position controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Timesharp.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Timesharp.Models;

    /// <summary>
    /// The position controller.
    /// </summary>
    [Authorize(Roles = RoleHelper.Manager)]
    public class PositionController : ApiController
    {
        #region Fields

        /// <summary>
        /// The db.
        /// </summary>
        private readonly TimesharpDbContext db = new TimesharpDbContext();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The delete position.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> DeletePosition(int id)
        {
            Position position = await this.db.Positions.FindAsync(id);
            if (position == null)
            {
                return this.NotFound();
            }

            this.db.Positions.Remove(position);
            await this.db.SaveChangesAsync();

            return this.Ok(position);
        }

        /// <summary>
        /// The get position.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OverrideAuthorization]
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> GetPosition(int id)
        {
            // TODO: check if manager, or if the position is owned by the employee
            Position position = await this.db.Positions.FindAsync(id);
            if (position == null)
            {
                return this.NotFound();
            }

            return this.Ok(position);
        }

        /// <summary>
        /// The get positions.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Position> GetPositions()
        {
            return this.db.Positions;
        }

        /// <summary>
        /// The post position.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(Position))]
        public async Task<IHttpActionResult> PostPosition(Position position)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Positions.Add(position);
            await this.db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = position.ID }, position);
        }

        /// <summary>
        /// The put position.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPosition(int id, Position position)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != position.ID)
            {
                return this.BadRequest();
            }

            this.db.Entry(position).State = EntityState.Modified;

            try
            {
                await this.db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.PositionExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// The position exists.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool PositionExists(int id)
        {
            return this.db.Positions.Count(e => e.ID == id) > 0;
        }

        #endregion
    }
}