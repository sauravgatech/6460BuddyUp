using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace GT.CS6460.BuddyUp.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "Security",
                routeTemplate: "api/Security/{action}",
                defaults: new { controller = "Security" }
            );

            config.Routes.MapHttpRoute(
                name: "Course",
                routeTemplate: "api/Course/{courseCode}",
                defaults: new { controller = "Course", courseCode = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "User",
                routeTemplate: "api/User/{emailId}",
                defaults: new { controller = "User", emailId = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CourseUser",
                routeTemplate: "api/CourseUser",
                defaults: new { controller = "CourseUser" }
            );

            config.Routes.MapHttpRoute(
                name: "Question",
                routeTemplate: "api/Question/{QuestionCode}",
                defaults: new { controller = "Question", QuestionCode = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Questionnaire",
                routeTemplate: "api/Questionnaire/{QuestionnaireCode}",
                defaults: new { controller = "Questionnaire", QuestionnaireCode = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Role",
                routeTemplate: "api/Role/{RoleCode}",
                defaults: new { controller = "Role", RoleCode = RouteParameter.Optional }
            );
        }
    }
}
