using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Areas.Identity.Data
{
    /// <summary>
    /// COntainers logic for Policies and Auth
    /// </summary>
    public static class SCCPolicies
    {
        public const string Readers = "Readers";
        public const string Creators = "Creators";
        public const string Updaters = "Updaters";

        /// <summary>
        /// Create various Policies that can be used for Auth on the site
        /// </summary>
        /// <param name="options"></param>
        public static void AddOveralPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(SCCPolicies.Readers, policy => policy.RequireRole(SCCRoles.Admin.ToString(), SCCRoles.Contributor.ToString(), SCCRoles.Reader.ToString()));
            options.AddPolicy(SCCPolicies.Creators, policy => policy.RequireRole(SCCRoles.Admin.ToString(), SCCRoles.Contributor.ToString()));
            options.AddPolicy(SCCPolicies.Updaters, policy => policy.RequireRole(SCCRoles.Admin.ToString()));
        }

        /// <summary>
        /// Set the individual page, folders, or areas to have policies enforced for Auth
        /// </summary>
        /// <param name="options"></param>
        public static void AddPageSpecificAuth(RazorPagesOptions options)
        {
            //Admin can delete and edit
            options.Conventions.AuthorizePage("/Teams/Delete", SCCPolicies.Updaters);
            options.Conventions.AuthorizePage("/Teams/Edit", SCCPolicies.Updaters);
            //Trusted can create
            options.Conventions.AuthorizePage("/Teams/Create", SCCPolicies.Creators);
            //Account can view
            options.Conventions.AuthorizePage("/Teams/Details", SCCPolicies.Readers);
            //Anonymous can view all indexes
            //options.Conventions.AllowAnonymousToPage("~/Index");
            //Execpt stats
            options.Conventions.AuthorizePage("/Stats/Index", SCCPolicies.Readers);

            options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/AccessDenied");
        }


    }


}
