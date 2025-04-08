
Write-Host "🔧 Cleaning previous build artifacts..."
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue `
    "src\**\bin", "src\**\obj", "tests\**\bin", "tests\**\obj"

Write-Host "🏗️ Building solution..."
dotnet build Krav.sln --configuration Release

Write-Host "🧪 Running tests..."
dotnet test Krav.sln --no-build --configuration Release

Write-Host "📦 Packing NuGet packages..."
dotnet pack src\Krav\Krav.csproj --configuration Release --output dist
dotnet pack src\Krav.Simple\Krav.Simple.csproj --configuration Release --output dist
dotnet pack src\Krav.Messages\Krav.Messages.csproj --configuration Release --output dist

Write-Host "✅ Build complete. Packages are in the 'dist' folder."
