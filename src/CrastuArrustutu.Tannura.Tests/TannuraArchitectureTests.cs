using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using CrastuArrustutu.Tannura.Facade;
using NetArchTest.Rules;

namespace CrastuArrustutu.Tannura.Tests;

[ExcludeFromCodeCoverage]
public class TannuraArchitectureTests
{
    [Fact]
    public void Should_CarnizzaroArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(TannuraFacadeHelper).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "CrastuArrustutu.Carnizzaro.Domain",
            "CrastuArrustutu.Carnizzaro.Entities",
            "CrastuArrustutu.Carnizzaro.Facade",
            "CrastuArrustutu.Carnizzaro.Infrastructure",
            "CrastuArrustutu.Carnizzaro.ReadModel",
            "CrastuArrustutu.Carnizzaro.SharedKernel"
        };
        
        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
    
    [Fact]
    public void TannuraProjects_Should_Having_Namespace_StartingWith_Tannura()
    {
        var tannuraModulePath = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "Tannura");
        var subFolders = Directory.GetDirectories(tannuraModulePath);

        var netVersion = Environment.Version;

        var tannuraAssemblies = (from folder in subFolders
            let binFolder = Path.Join(folder, "bin", "Debug", $"net{netVersion.Major}.{netVersion.Minor}")
            where Directory.Exists(binFolder)
            let files = Directory.GetFiles(binFolder)
            let folderArray = folder.Split(Path.DirectorySeparatorChar)
            select files.FirstOrDefault(f => f.EndsWith($"{folderArray[folderArray!.Length - 1]}.dll"))
            into assemblyFilename
            where assemblyFilename != null && !assemblyFilename.Contains("Test")
            select Assembly.LoadFile(assemblyFilename)).ToList();
        
        var tannuraTypes = Types.InAssemblies(tannuraAssemblies)
            .That()
            .DoNotHaveNameStartingWith("<>")
            .And()
            .AreNotNested()
            .GetTypes();
        
        var typesWithCorrectNamespace = Types.InAssemblies(tannuraAssemblies)
            .That()
            .ResideInNamespaceStartingWith("CrastuArrustutu.Tannura")
            .And()
            .AreNotNested()
            .GetTypes();
        
        // Find types with incorrect namespace (difference between the two sets)
        var riskAnalysisTypeArray = tannuraTypes as Type[] ?? tannuraTypes.ToArray();
        var typesWithIncorrectNamespace = riskAnalysisTypeArray.Except(typesWithCorrectNamespace).ToList();

        foreach (var type in typesWithIncorrectNamespace)
        {
            if (type.Namespace != null)
                Assert.Fail(
                    $"Namespace violation detected: {type.FullName} in assembly {type.Assembly.GetName().Name} should start " +
                    $"with 'CrastuArrustutu.Tannura' but is in namespace '{type.Namespace}'");
        }
    }
    
    private static class VisualStudioProvider
    {
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string? currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory!
                   ?? throw new DirectoryNotFoundException("Solution directory not found. Make sure to run this test from a solution folder.");
        }
    }
}