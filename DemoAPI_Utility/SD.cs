﻿    namespace DemoAPI_Utility
{
    public static class SD
    {
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string SessionToke = "JWTToken";
        public static string CurrentAPIVersion = "v2";
    }
}