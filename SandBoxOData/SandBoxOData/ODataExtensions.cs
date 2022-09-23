using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SandBoxOData.Models;

namespace SandBoxOData
{
    public static class ODataOptionsExtensions
    {
        public static ODataOptions AddDataApiRoutingComponents(this ODataOptions odataOptions)
        {
            var builder = new ODataConventionModelBuilder();

            new ModelConfiguration().Apply(builder);

            return odataOptions.AddRouteComponents("", builder.GetEdmModel());
        }
    }
}
