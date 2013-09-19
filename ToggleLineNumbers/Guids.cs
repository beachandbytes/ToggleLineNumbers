// Guids.cs
// MUST match guids.h
using System;

namespace BeachAndBytes.ToggleLineNumbers
{
    static class GuidList
    {
        public const string guidToggleLineNumbersPkgString = "0d51db24-b042-4403-b5dc-97d193ca0a45";
        public const string guidToggleLineNumbersCmdSetString = "3299446f-eb0f-4b28-b106-b2e231243930";

        public static readonly Guid guidToggleLineNumbersCmdSet = new Guid(guidToggleLineNumbersCmdSetString);
    };
}