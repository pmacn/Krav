#r "tools/FAKE/tools/FakeLib.dll"
open Fake

RestorePackages()

// Properties
let buildDir = "./build/"
let mainBuildDir = buildDir + "RequireThat/"
let simpleBuildDir = buildDir + "RequireThat.Simple/"
let testResultsDir = "./testresults/"
let buildMode = getBuildParamOrDefault "buildMode" "Release"

// Targets
Target "Clean" (fun _ ->
    CleanDirs [ buildDir
                testResultsDir ]
)

Target "BuildMain" (fun _ ->
    !! "src/RequireThat/**/*.csproj"
      |> MSBuildRelease mainBuildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "BuildSimple" (fun _ ->
    !! "src/RequireThat.Simple/**/*.csproj"
      |> MSBuildRelease simpleBuildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "UnitTests" (fun _ ->
    !! (sprintf "src/Tests/RequireThat.Tests/bin/%s/**/RequireThat.Tests*.dll" buildMode)
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
