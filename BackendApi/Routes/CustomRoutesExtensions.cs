namespace BackendApi.Routes
{
    public static class CustomRoutesExtensions
    {
        public static void LoginRoute (this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "Default",
                pattern: "/",
                defaults: new {controller = "Account", action= "Login" });

            endpoint.MapControllerRoute(
                name: "post",
                pattern: "/",
                defaults: new { controller = "Account", action = "Login" });

            endpoint.MapControllerRoute(
                name: "logout",
                pattern: "/logout",
                defaults: new { controller = "Account", action = "Logout" });
        }

        public static void PedidoRouters(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "pedidos",
                pattern: "pedidos/representante/{user}",
                defaults: new {controller= "Pedido", action= "PedidoRepresentante" });

            endpoint.MapControllerRoute(
                name: "buscapedido",
                pattern: "pedidos/busca-pedido",
                defaults: new {controller = "Pedido", action = "PegarUltimosPedidos" });
        }

        public static void ClienteRouters(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(
                name: "clientes",
                pattern: "/clientes/representante/{user}",
                defaults: new { controller = "Cliente", action = "GetClientesByRepresentante" });

            endpoint.MapControllerRoute(
                name: "info",
                pattern: "clientes/info/{codcli}",
                defaults: new { controller = "Cliente", action = "GetinfoClientes" });
        }

    }
}
