using System.Reflection;
using System.Resources;

#if DEBUG
[assembly: AssemblyProduct("Krav.Simple (Debug)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyProduct("Krav.Simple (Release)")]
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyTitle("Krav.Simple")]
[assembly: AssemblyDescription("Snappy and readable pre-conditions")]
[assembly: AssemblyCompany("Peter MacNaughton")]
[assembly: AssemblyCopyright("Copyright © Peter MacNaughton 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.1.0.*")]
[assembly: AssemblyFileVersion("0.1.0")]
