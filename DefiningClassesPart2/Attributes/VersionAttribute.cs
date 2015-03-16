/*Problem 11. Version attribute

    Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds
    a version in the format major.minor (e.g. 2.11).
    Apply the version attribute to a sample class and display its version at runtime.
*/

namespace Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
    | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : System.Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }

        public int Minor { get; private set; }
    }
}
