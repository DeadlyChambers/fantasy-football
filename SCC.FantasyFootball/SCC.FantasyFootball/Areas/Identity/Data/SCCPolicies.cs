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
        /// Set the individual page, folders, or areas to have policies enforced for Auth
        /// </summary>
        /// <param name="options"></param>
        public static void AddPageSpecificAuth(RazorPagesOptions options)
        {
            ////Admin can delete and edit
            //options.Conventions.AuthorizePage("/Teams/Delete", SCCPolicies.Updaters);
            //options.Conventions.AuthorizePage("/Teams/Edit", SCCPolicies.Updaters);
            ////Trusted can create
            //options.Conventions.AuthorizePage("/Teams/Create", SCCPolicies.Creators);
            ////Account can view
            //options.Conventions.AuthorizePage("/Teams/Details", SCCPolicies.Readers);
            //Anonymous can view all indexes
            //options.Conventions.AllowAnonymousToPage("~/Index");
            //Execpt stats

            options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/AccessDenied");
        }


    }


}
