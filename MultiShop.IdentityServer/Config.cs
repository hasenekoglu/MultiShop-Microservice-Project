using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{

    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        //Yetkilendirme yapacağımız yerlerin belirlenmesi
        new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission","CatalogReadPermission" } },
        new ApiResource("ResourceDiscount"){Scopes = { "DiscountFullPermission" }},
        new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" }},
        new ApiResource("ResourceCargo"){Scopes = { "CargoFullPermission" }},
        new ApiResource("ResourceBasket"){Scopes = { "BasketFullPermission" }},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };
    
    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        //Yetkilendirme yapıtğımız kısım
        new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
        new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),
        new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
        new ApiScope("OrderFullPermission", "Full authority for order operations"),
        new ApiScope("CargoFullPermission", "Full authority for cargo operations"),
        new ApiScope("BasketFullPermission", "Full authority for basket operations"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        //Visitor
        new Client()
        {
            ClientId = "MultiShopVisitor",
            ClientName = "Multi Shop Visitor User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes = { "DiscountFullPermission" }
        },

        //Manager
        new Client()
        {
            ClientId = "MultiShopManagerID",
            ClientName = "Multi Shop Manager User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }
        },

        //Admin
        new Client()
        {
            ClientId = "MultiShopAdminID",
            ClientName = "Multi Shop Admin User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes =
            {
                "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
            },
            AccessTokenLifetime = 600
        }
    };



    //public static IEnumerable<IdentityResource> IdentityResources =>
    //    new IdentityResource[]
    //    {
    //        new IdentityResources.OpenId(),
    //        new IdentityResources.Profile(),
    //    };

    //public static IEnumerable<ApiScope> ApiScopes =>
    //    new ApiScope[]
    //    {
    //        new ApiScope("scope1"),
    //        new ApiScope("scope2"),
    //    };

    //public static IEnumerable<Client> Clients =>
    //    new Client[]
    //    {
    //        // m2m client credentials flow client
    //        new Client
    //        {
    //            ClientId = "m2m.client",
    //            ClientName = "Client Credentials Client",

    //            AllowedGrantTypes = GrantTypes.ClientCredentials,
    //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

    //            AllowedScopes = { "scope1" }
    //        },

    //        // interactive client using code flow + pkce
    //        new Client
    //        {
    //            ClientId = "interactive",
    //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

    //            AllowedGrantTypes = GrantTypes.Code,

    //            RedirectUris = { "https://localhost:44300/signin-oidc" },
    //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
    //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

    //            AllowOfflineAccess = true,
    //            AllowedScopes = { "openid", "profile", "scope2" }
    //        },
    //    };
}

