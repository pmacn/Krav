using System.Resources;
using System.Reflection;

#if DEBUG
[assembly: AssemblyProduct("RequireThat (Debug)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyProduct("RequireThat (Release)")]
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyTitle("RequireThat")]
[assembly: AssemblyDescription("Readable pre-conditions")]
[assembly: AssemblyCompany("Peter MacNaughton")]
[assembly: AssemblyCopyright("Copyright © Peter MacNaughton 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("1.1.0.*")]
[assembly: AssemblyFileVersion("1.1.0")]
