﻿namespace BackendApi.Routes
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
                defaults: new {controller= "Pedido", action= "OrderBySeller" });

            endpoint.MapControllerRoute(
                name: "buscapedido",
                pattern: "pedidos/busca-pedido",
                defaults: new {controller = "Pedido", action = "GetLastOrders" });

            endpoint.MapControllerRoute(
                name: "createpedido",
                pattern: "pedidos/lancamento-pedido",
                defaults: new { controller = "Pedido", action = "RenderPageCreateOrder" });

            endpoint.MapControllerRoute(
                name: "createpedidobuscacliente",
                pattern: "pedidos/lancamento-pedido/busca-cliente/{cliente}",
                defaults: new { controller = "Pedido", action = "GetClientFormGenerateOrder" });

            endpoint.MapControllerRoute(
                name: "createpedidobuscaproduto",
                pattern: "pedidos/lancamento-pedido/busca-produto/{produto}",
                defaults: new { controller = "Pedido", action = "GetProductFromFormToGenerateOrder" });

            endpoint.MapControllerRoute(
                name: "CreatePedido",
                pattern: "pedidos/lancamento-pedido/lancamento",
                defaults: new { controller = "Pedido", action = "CreateOrder" });

            endpoint.MapControllerRoute(
              name: "relcomissao",
              pattern: "pedidos/comissao-vendas/relatorio/{user}",
              defaults: new { controller = "Pedido", action = "GetReportCommission" });
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
