#r "tools/FAKE/tools/FakeLib.dll"
open Fake

RestorePackages()

// Properties
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
    !! "src/Krav/**/*.csproj"
      |> MSBuildRelease mainBuildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "BuildSimple" (fun _ ->
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
