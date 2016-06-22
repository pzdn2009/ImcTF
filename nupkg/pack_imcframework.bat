"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework\ImcFramework.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Infrastructure\ImcFramework.Infrastructure.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.WcfInterface\ImcFramework.WcfInterface.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Core\ImcFramework.Core.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.WinServiceLib\ImcFramework.WinServiceLib.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Winform\ImcFramework.Winform.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Core.SignalRExt\ImcFramework.Core.SignalRExt.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Core.RedisExt\ImcFramework.Core.RedisExt.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol
"..\ImcFramework\Nuget\NuGet.exe" "pack" "..\ImcFramework\ImcFramework.Core.LuceneNetExt\ImcFramework.Core.LuceneNetExt.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbol


pause