using System.Reflection;
using System.Resources;

#if DEBUG
[assembly: AssemblyProduct("RequireThat.Simple (Debug)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyProduct("RequireThat.Simple (Release)")]
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyTitle("RequireThat.Simple")]
[assembly: AssemblyDescription("Snappy and readable pre-conditions")]
[assembly: AssemblyCompany("Peter MacNaughton")]
[assembly: AssemblyCopyright("Copyright © Peter MacNaughton 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.1.0.*")]
[assembly: AssemblyFileVersion("0.1.0")]
