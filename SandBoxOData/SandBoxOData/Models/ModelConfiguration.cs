using Microsoft.OData.ModelBuilder;

namespace SandBoxOData.Models
{
    public interface IModelConfiguration
    {
        void Apply(ODataConventionModelBuilder builder);
    }

    public class ModelConfiguration : IModelConfiguration
    {
        public void Apply(ODataConventionModelBuilder builder)
        {
            builder.EntitySet<Driver>("Drivers");
        }
    }
}
