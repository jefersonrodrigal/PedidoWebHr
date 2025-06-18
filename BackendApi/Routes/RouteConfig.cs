using Microsoft.AspNetCore.Builder;

namespace BackendApi.Routes
{
    public static class RouteConfig
    {
        public static void RoutesRegister(this IEndpointRouteBuilder endpoint)
        {

            endpoint.MapControllerRoute(
                name: "pedidosPorRepresentantes",
                pattern: "pedidos/representante/{codrep}",
                defaults: new {controler= "Pedido", action= "PedidoRepresentanteAsync"});

            endpoint.MapControllerRoute(
                name: "clientes",
                pattern: "/clientes/{codrep}",
                defaults: new { controller= "Cliente", action= "GetClientesByRepresentanteAsync"});

            endpoint.MapControllerRoute(
                name:"logout",
                pattern: "/logout",
                defaults: new {controller = "Account", action= "Logout"}
                );

            // Default Router
            endpoint.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
        }
    }
}
