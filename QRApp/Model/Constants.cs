using System;
using System.Collections.Generic;
using System.Text;

namespace QRApp.Model
{
    public static class Constants
    {
        public static readonly string ClientId = "814fd394-e662-4722-94d0-9fd65fc8ac7b";
        public static readonly string[] Scopes = new string[] { "User.Read" };
        public static readonly string RedirectUri = "msal814fd394-e662-4722-94d0-9fd65fc8ac7b://auth";
        public static readonly string TenantId = "195770a6-80bf-4668-b85f-31a0fea07f7e";
        public static readonly string IosKeychainSecurityGroups = "com.microsoft.aadauthentication";
    }
}
