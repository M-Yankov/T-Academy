namespace ArtistSystem.WebApi
{
    using System;
    using ArtistSystem.WebApi.Providers;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;
    using Owin;

    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }
        
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ArtistSystemContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),

                //// In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);

            ////  Uncomment the following lines to enable logging in with third party login providers
            //// app.UseMicrosoftAccountAuthentication(
            ////     clientId: "",
            ////     clientSecret: "");
                 
            //// app.UseTwitterAuthentication(
            ////     consumerKey: "",
            ////     consumerSecret: "");
                 
            //// app.UseFacebookAuthentication(
            ////     appId: "",
            ////     appSecret: "");
                 
            //// app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //// {
            ////     ClientId = "",
            ////     ClientSecret = ""
            //// });
        }
    }
}
