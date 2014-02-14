#r "tools/FAKE/tools/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

RestorePackages()

// Properties
let version = "1.1.0"
let buildDir = "./build/"
let mainBuildDir = buildDir + "Krav/"
let simpleBuildDir = buildDir + "Krav.Simple/"
let testResultsDir = "./testresults/"
let buildMode = getBuildParamOrDefault "buildMode" "Release"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [ buildDir
                testResultsDir ]
)

Target "BuildMain" (fun _ ->
  CreateCSharpAssemblyInfo "./src/Krav/Properties/AssemblyInfo.cs"
    [ Attribute.Title "Krav"
      Attribute.Description "Readable preconditions"
      Attribute.Product "Krav"
      Attribute.Version version
      Attribute.FileVersion version ]

  !! "src/Krav/**/*.csproj"
    |> MSBuildRelease mainBuildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildSimple" (fun _ ->
  CreateCSharpAssemblyInfo "./src/Krav.Simple/Properties/AssemblyInfo.cs"
    [ Attribute.Title "Krav.Simple"
      Attribute.Description "Snappy and readable preconditions"
      Attribute.Product "Krav.Simple"
      Attribute.Version version
      Attribute.FileVersion version ]

  !! "src/Krav.Simple/**/*.csproj"
    |> MSBuildRelease simpleBuildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "UnitTests" (fun _ ->
    !! (sprintf "src/Tests/Krav.Tests/bin/%s/**/Krav.Tests*.dll" buildMode)
    |> xUnit (fun p -> 
            {p with 
               Verbose = false
               OutputDir = testResultsDir })
)

Target "Default" DoNothing

// Dependencies
"Clean"
  ==> "BuildMain"
  ==> "BuildSimple"
  ==> "UnitTests"
  ==> "Default"

// Start
RunTargetOrDefault "Default"
