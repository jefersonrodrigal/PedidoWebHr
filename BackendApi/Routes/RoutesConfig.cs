using Microsoft.AspNetCore.Builder;

namespace BackendApi.Routes
{
    public static class RoutesConfig
    {

        public static void LoginRoute (this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            endpoint.MapControllerRoute(
                name: "logout",
                pattern: "/logout",
                defaults: new { controller = "Account", action = "Logout" });
        }

        public static void PedidoRouters(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "pedidosPorRepresentantes",
                pattern: "pedidos/representante/{codrep}",
                defaults: new {controler= "Pedido", action= "PedidoRepresentanteAsync"});
        }

        public static void ClienteRouters(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "clientes",
                pattern: "/clientes/representante/{codrep}",
                defaults: new { controller = "Cliente", action = "GetClientesByRepresentanteAsync" });
        }
    }
}
