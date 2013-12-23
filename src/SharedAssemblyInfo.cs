using System.Runtime.InteropServices;
﻿using System.Reflection;

#if DEBUG
[assembly: AssemblyProduct("Require.That (Debug)")]
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyProduct("Require.That (Release)")]
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyDescription("A simple guard clause library")]
[assembly: AssemblyCompany("Peter MacNaughton")]
[assembly: AssemblyCopyright("Copyright © Peter MacNaughton")]
[assembly: AssemblyTrademark("")]

[assembly: AssemblyVersion("0.9.1.*")]
[assembly: AssemblyFileVersion("0.9.1")]