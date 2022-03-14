using System;

namespace UnluCoFinalProject.Domain.Enum
{
    public enum Roles
    {
        ADMIN,
        BASIC
    }

    public static class Constants
    {
        public static readonly string ADMIN = Guid.NewGuid().ToString();
        public static readonly string BASIC = Guid.NewGuid().ToString();
    }


}
