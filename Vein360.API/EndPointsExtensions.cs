using Vein360.API.EndPoints;

namespace Vein360.API
{
    public static class EndPointsExtensions
    {
        public static void MapEndpoints(this WebApplication app) 
        {
            app.MapDonationEndpoints();
            app.MapProductEndpoints();
            app.MapDonationContainerEndpoints();
            app.MapContainerTypeEndpoints();
            app.MapContainerEndpoints();
            app.MapDocumentEndpoints();
            app.MapAccountEndpoints();
            app.MapClinicEndpoints();
            app.MapShippingLabelEndpoints();
            app.MapUserEndpoints();
            app.MapDonorPreferenceEndpoints();
            app.MapProductRateEndpoints();
            app.MapUserProductEndpoints();
            app.MapOrderEndpoints();
        }
    }
}
