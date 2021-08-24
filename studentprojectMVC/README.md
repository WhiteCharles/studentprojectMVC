# webapplication
- 2nd web app for Software Security course
- School: Erasmus University College, Brussels
- Author: Charles D. White
- Instructor: Mr. Johan Peeters

#webapplication URL: www.studentproject.be  -  studentproject.be
- GitHub repository current project: https://github.com/WhiteCharles/studentprojectMVC
- Github Repository previous project attempts:
--> RecRepository - webapplication - HomeFarm - MusicRepo

#Major issues: 
- - did not succeed website to go live, site runs properly on localhost and local IIS server
- - during development multiple Internal Server Errors, generic 500, 500.19, 502.5 
possibly indicating .Net Core Windows Server Hosting Bundle not installed on hosting server
- not found solution nor cause -- however problems could originate from web.config
- - awaiting response from hosting company to request on disabling TLSv1.0 & TLSv1.1
- - several project requirements not completed 
- lack of time due to difficulty and inability to successfully troubleshoot

web.config
rule name="CSP">
          match serverVariable="RESPONSE_Content-Security-Policy" pattern=".*" />
          action type="Rewrite" value="style-src 'self'; font-src https:/fonts.googleapis.com/css?family=Source+Sans+Pro; frame-src 'self'; frame-ancestors 'self'; upgrade-insecure-requests" />
        /rule>

#Success:
- HSTS preloaded - Https
- SecurityHeaders.io --> A+
- SslLabs: capped at score B --> requested hosting company to disable TLSv1.0 and TLSv1.1
- populated remote server database manually
- login/registration capability
- forgot password / remember user capability
- shopping cart available to all users -- order capability restricted to registered/logged in users
- cookie
- privacy consent complete / however --> consent revocation incomplete
- 

# just a fraction of sources consulted for development and troubleshooting:
- Pluralsight - Building Web Applications with ASP.NET Core MVC, Gill Cleeren
- PluralSight - Introduction to Browser Security Headers, Troy Hunt
- PluralSight - Implementing HTTPS in ASP.NET and ASP.NET Core, Matt Milner
- PluralSight - Configuring Security Headers in ASP.NET and ASP.NET Core Applications, Roland Guijt

- Permissions-Policy - https:/ w3c.github.io/webappsec-permissions-policy/
- Permissions-Policy - https:/ www.w3.org/TR/permissions-policy-1/

- Feature-Policy - https:/ scotthelme.co.uk/a-new-security-header-feature-policy/

- Security-Headers - https:/ jonathancrozier.com/blog/stepping-up-the-security-of-asp-net-core-web-apps-with-security-headers
- Security-Headers - https:/ www.hanselman.com/blog/easily-adding-security-headers-to-your-aspnet-core-web-app-and-getting-an-a-grade
- Security-Headers - https:/ /blog.elmah.io/the-asp-net-core-security-headers-guide/

- Content-Security-Policy - https:/ report-uri.com/home/generate
- Content-Security-Policy - https:/ www.npmjs.com/package/seespee/v/2.0.0
- Response-Headers - https:/ tomssl.com/how-to-fix-the-http-response-headers-on-azure-web-apps-to-get-an-a-plus-on-securityheaders-io/
- HSTS - Check HSTS preload status and eligibility - https:/ hstspreload.org/
- HTTPS Strict-Transport-Security - chrome://net-internals/#hsts
- Security-Headers - https:/ blog.elmah.io/the-asp-net-core-security-headers-guide/
- Strict-Transport-Security - https:/ developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Strict-Transport-Security
- Security-Headers - https:/ www.meziantou.net/security-headers-in-asp-net-core.htm
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio
- HTTPS - https:/ docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.0&tabs=visual-studio#http-strict-transport-security-protocol-hsts
- HSTS header - https:/ stackoverflow.com/questions/58338166/asp-net-core-no-hsts-header-in-response-headers
- Security-Headers - Can I Use - https:/ caniuse.com/mdn-http_headers_csp_content-security-policy_default-src
- HTTPS - https:/ docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio
- Security-Headers - https:/ scotthelme.co.uk/security-headers-updates/

- CAA records - https:/ caatest.co.uk/about-caa-records

- HTTP redirect-rewrite - https:/ weblog.west-wind.com/posts/2020/Mar/13/Back-to-Basics-Rewriting-a-URL-in-ASPNET-Core
- HTTP Redirect - https:/ laimis.medium.com/couple-issues-with-https-redirect-asp-net-core-7021cf383e00
- rewrite - https:/ blog.elmah.io/web-config-redirects-with-rewrite-rules-https-www-and-more/
- SSL - https: /neelbhatt.com/2018/02/04/enforce-ssl-and-use-hsts-in-net-core-net-core-security-part-i/
- HTTPS Redirection - https:/ www.iambacon.co.uk/blog/https-redirection-not-working-after-migrating-to-asp-net-core-2-1
- Rewriting URL in ASP.NET Core - https:/ weblog.west-wind.com/posts/2020/Mar/13/Back-to-Basics-Rewriting-a-URL-in-ASPNET-Core
- URL Rewriting Middleware in ASP.NET Core - https:/ docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting?view=aspnetcore-5.0
- HTTPS required - https:/ jonathancrozier.com/blog/how-to-configure-your-asp-net-web-apps-and-apis-to-require-https
- 
- YouTube: Deploy Asp.net Core 3.0 application on IIS https:/ /www.youtube.com/watch?v=ZG-6z4BQmRI
- youTube: How to publish ASP.Net MVC 5 with SQL database to IIS https:/ /www.youtube.com/watch?v=vM5VlBFfNNc
- YouTube: HTTP Error 500.19 Internal Server Error web.config 0x8007000d - https:/ /www.youtube.com/watch?v=1ZRVCJamj-c

- Asp.Net - https:/ /www.tutorialspoint.com/asp.net_core/asp.net_core_dbcontext.htm
- https:/ /forums.asp.net/t/2121840.aspx?ASP+Net+Core+Publish+HTTP+Error+500+19+Internal+Server+Error
- https:/ /forums.iis.net/t/1237997.aspx
- https:/ /stackoverflow.com/questions/54984884/error-500-19-with-0x8007000d-when-running-asp-net-core-app-in-iis-despite-aspnet
- https:/ /www.codeproject.com/Questions/1210117/Publishing-aspnet-core-project-to-IIS
- 
- .NET Core application publishing overview https:/ /docs.microsoft.com/en-us/dotnet/core/deploying/
- Publishing and Running ASP.NET Core Applications with IIS - https:/ /weblog.west-wind.com/posts/2016/jun/06/publishing-and-running-aspnet-core-applications-with-iis
- http:/ /www.techtutorhub.com/article/How-to-Publish-dot-net-core-3-app-to-iis-10/79
- https:/ /wakeupandcode.com/iis-hosting-for-asp-net-core-3-1-web-apps/
- https:/ /jakeydocs.readthedocs.io/en/latest/publishing/iis.html
- https:/ /damienbod.com/2018/09/21/deploying-an-asp-net-core-application-to-windows-iis/
- https:/ /weisong0908.medium.com/deploy-and-host-asp-net-core-2-0-web-api-app-on-iis-e9f3b14bf47f
- https:/ /stackoverflow.com/questions/59640455/how-to-deploy-asp-net-core-web-api-with-connectionstring-to-iis
- https:/ /karthiktechblog.com/aspnetcore/how-to-use-tls-1-2-in-asp-net-core-2-0-and-above
- https:/ /tomssl.com/how-to-fix-the-http-response-headers-on-azure-web-apps-to-get-an-a-plus-on-securityheaders-io/
- 
- https:/ /www.joeaudette.com/blog/2018/08/28/gdpr---adding-a-revoke-consent-button-in-aspnet-core
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/gdpr?view=aspnetcore-2.2
- https:/ /kenhaggerty.com/articles/article/aspnet-core-31-cookie-consent
- https:/ /gunnarpeipman.com/aspnet-core-gdpr/
- https:/ /github.com/dotnet/AspNetCore.Docs/blob/master/aspnetcore/security/gdpr.md
- https:/ /www.c-sharpcorner.com/blogs/inbuild-consent-feature-by-asp-net-core

- https:/ /docs.microsoft.com/en-US/troubleshoot/iis/http-error-500-19-webpage
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-5.0
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/hosting-bundle?view=aspnetcore-5.0&viewFallbackFrom=aspnetcore-3.1
- https:/ /github.com/dotnet/core/issues/5123
- https:/ /forums.asp.net/t/2132912.aspx?Problems+Installing+NET+Core+Windows+Server+Hosting+2+0+3+bundle
- https:/ /stackoverflow.com/questions/51336791/asp-net-core-hosting-error-internal-server-error-handler-aspnetcore-has-a-ba
- https:/ /stackoverflow.com/questions/40805402/http-error-500-19-when-publish-net-core-project-into-iis-with-0x80070005
- 
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/transform-webconfig?view=aspnetcore-5.0
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/transform-webconfig?view=aspnetcore-3.1
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/web-config?view=aspnetcore-5.0&viewFallbackFrom=aspnetcore-3.1
- 
- https:/ /stackoverflow.com/questions/47718566/entity-framework-the-object-pk-aspnetusertokens-is-dependent-on-column-user
- https:/ /stackoverflow.com/questions/38192450/how-to-unapply-a-migration-in-asp-net-core-with-ef-core
-
- https:/ /stackoverflow.com/questions/61271703/signinmanager-issignedinuser-returns-false
- https:/ /stackoverflow.com/questions/48307099/signinmanager-issignedinuser-versus-user-identity-isauthenticated/48307158
- https:/ /github.com/alexandre-spieser/AspNetCore.Identity.MongoDbCore/issues/8
- https:/ /docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x&view=aspnetcore-5.0
- https:/ /github.com/dotnet/AspNetCore.Docs/issues/5172
- https:/ /www.programmersought.com/article/96714157378/
- https:/ /docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-5.0#fhmo
- https:/ /docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
-
- https:/ /developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Set-Cookie
- https:/ /owasp.org/www-community/HttpOnly
- 
- https:/ /forums.asp.net/t/2158068.aspx?forcing+the+use+of+Tls1+2
- https:/ /docs.microsoft.com/en-us/dotnet/framework/network-programming/tls
- https:/ /docs.microsoft.com/en-us/answers/questions/200549/web-request-not-going-through-with-tls-12-enabled.html
- https:/ /docs.microsoft.com/en-us/mem/configmgr/core/plan-design/security/enable-tls-1-2-client
- https:/ /docs.microsoft.com/en-us/dotnet/framework/network-programming/tls
- https:/ /stackoverflow.com/questions/34920429/is-tls-1-1-and-tls-1-2-enabled-by-default-for-net-4-5-and-net-4-5-1/45692875
- https:/ /stackoverflow.com/questions/45382254/update-net-web-service-to-use-tls-1-2
- https:/ /forums.asp.net/t/2069611.aspx?I+need+to+disable+TLS+1+0+via+code+Is+it+possible+
- https:/ /docs.microsoft.com/en-us/microsoft-365/compliance/tls-1.0-and-1.1-deprecation-for-office-365?view=o365-worldwide
- https:/ /stackoverflow.com/questions/46832384/any-way-to-restrict-asp-net-core-2-0-https-to-tls-1-2
- https:/ /docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
- https:/ /stackoverflow.com/questions/62728467/middleware-ordering
- https:/ /github.com/alexandre-spieser/AspNetCore.Identity.MongoDbCore/issues/8
- https:/ /www.y2mate.com/download-youtube/BfEjDD8mWYg
- https:/ /owasp.org/www-community/HttpOnly

# Response Headers
- https:/ /docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.headers.responseheaders.setcookie?view=aspnetcore-5.0
- https:/ /docs.microsoft.com/en-us/answers/questions/281549/gettypedheaderssetcookie-in-net-core.html
- https:/ /stackoverflow.com/questions/63557338/how-add-cookies-to-http-request-header-in-asp-net-core-mvc

#Password Reuse - HIBP locally ok - online inactive???
- https:/ /blog.elmah.io/avoid-password-reuse-with-pwned-passwords-and-asp-net-core/
- https:/ /haveibeenpwned.com/Passwords
- https:/ /www.youtube.com/watch?v=Up5AxHjdS2o
- https:/ /github.com/topics/haveibeenpwned?l=c%23
- https:/ /github.com/MatrixsoftIN/PwnedPasswords/
- https:/ /github.com/sadphi/PwnedPasswords
- 
#Lockout Configuration
- https:/ /stackoverflow.com/questions/39825634/how-override-asp-net-core-identitys-password-policy
- https:/ /code-maze.com/user-lockout-aspnet-core-identity/
- https:/ /docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.lockoutoptions.defaultlockouttimespan?view=aspnetcore-5.0
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-5.0
-
#Cookies
- Cookies in ASP.NET - https:/ /www.youtube.com/watch?v=KE2jLFz85aw
- https:/ /www.c-sharpcorner.com/blogs/inbuild-consent-feature-by-asp-net-core
- https:/ /www.joeaudette.com/blog/2018/08/28/gdpr---adding-a-revoke-consent-button-in-aspnet-core
- https:/ /docs.microsoft.com/en-us/aspnet/core/security/gdpr?view=aspnetcore-3.0
- https:/ /wakeupandcode.com/cookies-and-consent-in-asp-net-core-3-1/
- .NET cookies securityheaders middleware: https:/ /docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-5.0
- https:/ /blog.elmah.io/the-ultimate-guide-to-secure-cookies-with-web-config-in-net/
- https:/ /www.jardinesoftware.net/tag/web-config/
- https:/ /scotthelme.co.uk/tough-cookies/
- https:/ /developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Set-Cookie

- https:/ /dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro

#InvalidOperationException: No service for type 'Microsoft.AspNetCore.Identity.SignInManager`1[Microsoft.AspNetCore.Identity.IdentityUser]' has been registered
- https:/ /stackoverflow.com/questions/52568264/no-service-for-type-microsoft-aspnetcore-identity-usermanager1microsoft-aspne
- https:/ /stackoverflow.com/questions/52089864/unable-to-resolve-service-for-type-iemailsender-while-attempting-to-activate-reg
- https:/ /forums.asp.net/t/2154504.aspx?InvalidOperationException+Unable+to+resolve+service+for+type+Microsoft+AspNetCore+Identity+UserManager+1+Microsoft+AspNetCore+Identity+IdentityUser+while+attempting+to+activate+Mobile+Areas+Identity+Pages+Account+RegisterModel+
- https:/ /www.codegrepper.com/code-examples/csharp/Unable+to+resolve+service+for+type+%27Microsoft.AspNetCore.Identity.UI.Services.IEmailSender

# Database - insert data in asp.net core
- https:/ /www.youtube.com/watch?v=0ERoJNLN83o&list=PL4MXv1SELZmzA1BvYnnPvQgvEqHGn22ny&index=2

# InvalidOperationException: The AuthorizationPolicy named: 'CountryLocationRequirement' was not found.
- https:/ /stackoverflow.com/questions/49717239/invalidoperationexception-the-authorizationpolicy-named-bearer-was-not-found
- https:/ /www.hkvforums.com/viewtopic.php?t=50072
- https:/ /newbedev.com/invalidoperationexception-the-authorizationpolicy-named-bearer-was-not-found

# NotSupportedException: No IUserTwoFactorTokenProvider<TUser> named 'Default' is registered
- https:/ /mattferderer.com/NotSupportedException-No-IUserTwoFactorTokenProvider-tuser-named-default-registered
- https:/ /stackoverflow.com/questions/59303760/no-iusertwofactortokenprovider-named-default-is-registered-problem-is-adddefa

# An unhandled exception occurred while processing the request. InvalidOperationException: The AuthorizationPolicy named: 'CountryLocationRequirement' was not found. Microsoft.AspNetCore.Authorization.AuthorizationPolicy.CombineAsync(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)

# Claims - TUserClaim missing from assembly IdentityUser
- https:/ /www.youtube.com/watch?v=LJQBBvJ6tL0
- https:/ /docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser-4.claims?view=aspnetcore-1.1#Microsoft_AspNetCore_Identity_EntityFrameworkCore_IdentityUser_4_Claims
- https:/ /docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser?view=aspnetcore-1.1
- https:/ /stackoverflow.com/questions/53292286/is-there-a-way-to-add-claims-in-an-asp-net-core-middleware-after-authentication
- https:/ /gunnarpeipman.com/aspnet-core-adding-claims-to-existing-identity/
- https:/ /www.youtube.com/watch?v=5XA4Z-SOif8 - Manage User Claims in Asp.Net Core
- https:/ /www.youtube.com/watch?v=LJQBBvJ6tL0 = Claims-based Authorization in Asp.Net Core

# InvalidOperationException: There is already an open DataReader associated with this Connection which must be closed first.
- https:/ /stackoverflow.com/questions/6062192/there-is-already-an-open-datareader-associated-with-this-command-which-must-be-c
- https:/ /stackoverflow.com/questions/18475195/error-there-is-already-an-open-datareader-associated-with-this-command-which-mu/18475525
- https:/ /www.codeproject.com/Questions/616154/There-is-already-an-open-DataReader-associated-wit

# API - Could not load assembly '\'. Ensure it is referenced by the startup project '.API'.
- https:/ /stackoverflow.com/questions/16678724/add-migration-causing-a-could-not-load-assembly-error
- https:/ /github.com/dotnet/efcore/issues/22594
- 
# the type or namespace 'ApplicationInsights' does not exist in the namespace 'Microsoft'
- https:/ /stackoverflow.com/questions/46380474/applicationinsight-does-not-exist-in-the-namespace-microsoft
- https:/ /www.stevefenton.co.uk/2020/08/the-type-or-namespace-name-applicationinsights-does-not-exist-in-the-namespace-microsoft/
- https:/ /github.com/Windows-XAML/Template10/issues/426

# image references
- carousel1.png - https:/ /dlpng.com/png/6922573
- carousel3.png - https:/ /www.vhv.rs/viewpic/iRRxohb_transparent-music-emoji-png-transparent-background-music-notes/
- carousel5.png - https:/ /pngimg.com/download/22012
- borntorun (LP record in own collection)
- colourbynumbers (LP record in own collection)
- cottonclubdays (LP record in own collection)
- musiclogo.jpeg
- musiclogo.png
- pattern.png
