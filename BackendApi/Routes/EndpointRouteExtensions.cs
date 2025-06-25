namespace BackendApi.Routes
{
    public static class EndpointRouteExtensions
    {
        public static void MapCustomRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.LoginRoute();
            endpoints.PedidoRouters();
            endpoints.ClienteRouters();
        }
    }
}
