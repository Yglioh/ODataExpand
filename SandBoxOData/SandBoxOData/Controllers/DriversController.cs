using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SandBoxOData.Models;
using SandBoxOData.Services;
using static Microsoft.AspNetCore.OData.Query.AllowedQueryOptions;

namespace SandBoxOData.Controllers
{
    public class DriversController : ODataController
    {
        private readonly IDriverService DriverService;

        public DriversController(IDriverService driverService)
        {
            DriverService = driverService;
        }

        /// <summary>
        /// Retrieves all <see cref="Driver"/> objects after taken into account the <paramref name="odataQueryOptions"/>.
        /// </summary>
        /// <param name="odataQueryOptions">OData query options.</param>
        /// <returns></returns>
        [EnableQuery(AllowedQueryOptions = Select | Expand | Top | OrderBy | Count | Skip | Filter)]
        public ActionResult<IQueryable<Driver>> Get(ODataQueryOptions<Driver> odataQueryOptions)
        {
            var drivers = DriverService.Get();
            return Ok(drivers);
        }

        /// <summary>
        /// Retrieves a single <see cref="Driver"/> object.
        /// </summary>
        /// <param name="key">The requested object's identifier.</param>
        /// <param name="odataQueryOptions">OData query options.</param>
        /// <returns></returns>
        [EnableQuery(AllowedQueryOptions = Select | Expand)]
        public ActionResult<IQueryable<Driver>> Get(int key, ODataQueryOptions<Driver> odataQueryOptions)
        {
            var driver = DriverService.GetById(key);
            return Ok(driver);
        }
    }
}