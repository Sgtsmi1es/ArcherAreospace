using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Argus")]
[assembly: AssemblyDescription("KSP Orbital Triad Deployment System")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Archer Aerospace")]
[assembly: AssemblyProduct("Argus")]
[assembly: AssemblyCopyright("Copyright © 2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a8b7c6d5-e4f3-2a1b-9c8d-7e6f5a4b3c2d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// ToolbarControl dependency
[assembly: KSPAssemblyDependency("ToolbarController", 1, 0)]

// ClickThroughBlocker dependency (required by ToolbarControl)
[assembly: KSPAssemblyDependency("ClickThroughBlocker", 1, 0)]
