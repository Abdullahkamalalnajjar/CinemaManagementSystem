﻿namespace CinemaManagementSystem.Data.AppMetaData
{
    public static class Router
    {
        private const string SingleRoute = "{id}";
        private const string ListRoute = "List";


        private const string root = "Api";
        private const string version = "V1";
        private const string Rule = root + "/" + version;



        public static class MovieRouting
        {
            private const string Prefix = Rule + "/" + "Movie/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
        public static class TheaterRouting
        {
            private const string Prefix = Rule + "/" + "Theater/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class ShowtimeRouting
        {
            private const string Prefix = Rule + "/" + "Showtime/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class ReservationRouting
        {
            private const string Prefix = Rule + "/" + "Reservation/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }

        public static class ReservedSeatRouting
        {
            private const string Prefix = Rule + "/" + "ReservedSeat/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }


        public static class EmailRouting
        {
            private const string Prefix = Rule + "/" + "Email/";
            public const string SendEmail = Prefix + "SendEmail";

        }
        public static class UserRouting
        {
            private const string Prefix = Rule + "/" + "AppUser/";
            public const string List = Prefix + ListRoute;
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
        }
        public static class AuthenticationRouting
        {
            private const string Prefix = Rule + "/" + "Authentication/";
            public const string SginIn = Prefix + "SginIn";
            public const string ConfirmEmail = Prefix + "ConfirmEmail";
        }
        public static class AuthorizationRouting
        {
            private const string Prefix = Rule + "/" + "Authorization/";
            public const string CreateRole = Prefix + "CreateRole";
            public const string MangeUserRoles = Prefix + "mange-user-roles/{userId}";
            public const string GetRolesList = Prefix + "GetRolesList";
            public const string GetClimsList = Prefix + "GetClaimsList";
            public const string MangeUserClaims = Prefix + "mange-user-calims/{userId}";
            public const string UpdateRole = Prefix + "UpdateRole";
            public const string UpdateClaims = Prefix + "UpdateClaims";

        }
    }
}
