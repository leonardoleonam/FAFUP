Criar pacote nuget
 
1 - Incrementar assemblerversion 
2 - Compilar o PrevisulLogger.sln
3 - Rodar no console como administrador : 
    1 - cd "Caminho do projeto", Exemplo: C:\Previsul\Previsul.Logger
    2 - nuget.exe pack C:\Previsul\Previsul.Logger\Previsul.Components.Logging\Previsul.Components.Logging.csproj -Symbol -Prop Configuration=Debug -IncludeReferencedProjects
4 - Copiar os arquivos D:\Work\PrevisulLogger.*.*.*.*.nupkg e D:\Work\PrevisulLogger.*.*.*.*.symbols.nupkg para repositório nuget local, Exemplo: "D:\Work\NugetLocal"
5 - No Package Manager Console da aplicação Web rodar comando : update-package Previsul.Components.Logging

* OBS: No VisualStudio precisaremos adicionar o novo respositório de pacotes local.
Tools >> Options >> Nuget package Manager >> +

Name: PrevisulLocalPackageManager
Source: D:\Work\NugetLocal

Via Visual Studio
https://docs.microsoft.com/pt-br/nuget/quickstart/create-and-publish-a-package-using-visual-studio