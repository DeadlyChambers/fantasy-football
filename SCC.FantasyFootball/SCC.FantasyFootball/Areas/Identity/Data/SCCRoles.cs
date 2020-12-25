using Microsoft.AspNetCore.Identity;

namespace SCC.FantasyFootball.Areas.Identity.Data
{
    /// <summary>
    /// Types of potential roles to be used for the website
    /// </summary>
    public enum SCCRoles
    {
        /// <summary>
        /// Default user
        /// </summary>
        Anoynomous = 0,

        /// <summary>
        /// Full Read, Write, Modify, Delete, also manages roles
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Read, Write
        /// </summary>
        Contributor = 2,

        /// <summary>
        /// Read
        /// </summary>
        Reader = 3
    }

    public static class SCCRoleConst
    {
        public const string Anoynomous = "Anoynomous";
        public const string Admin = "Admin";
        public const string CreateRoles = "Admin,Contributor";
        public const string Contributor = "Contributor";
        public const string ReadRoles = "Admin,Contributor,Reader";
        public const string Reader = "Reader";
    }

    public static class SCCRoleExtensions
    {
        /// <summary>
        /// Make sure the Identity retrieve is always the same Id, and String
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public static IdentityRole AsIdentityRole(this SCCRoles role)
        {

            return new IdentityRole(role.ToString()) {
                Id = ((int)role).ToString(),
                NormalizedName = role.ToString().ToUpper()
            };
        }
    }
}
