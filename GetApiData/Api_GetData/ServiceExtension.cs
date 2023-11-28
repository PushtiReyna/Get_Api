using Business_layer;
using Service_layer.Implementation;
using Service_layer.Interface;

namespace Api_GetData
{
    public static class ServiceExtension
    {
        public static void DIScope(this IServiceCollection service)
        {
            service.AddScoped<IGetData,GetDataImpl>();
            service.AddScoped<GetDataBLL>();
        }
    }
}
