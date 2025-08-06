using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using CrastuArrustutu.Carnizzaro.Facade;
using NetArchTest.Rules;

namespace CrastuArrustutu.Carnizzaro.Tests;

[ExcludeFromCodeCoverage]
public class CarnizzaroArchitectureTests
{
    [Fact]
    public void Should_CarnizzaroArchitecture_BeCompliant()
    {
        var types = Types.InAssembly(typeof(CarnizzaroFacadeHelper).Assembly);

        var forbiddenAssemblies = new List<string>
        {
            "CrastuArrustutu.Tanura.Domain",
            "CrastuArrustutu.Tanura.Entities",
            "CrastuArrustutu.Tanura.Facade",
            "CrastuArrustutu.Tanura.Infrastructure",
            "CrastuArrustutu.Tanura.ReadModel",
            "CrastuArrustutu.Tanura.SharedKernel"
        };
        
        var result = types
            .ShouldNot()
            .HaveDependencyOnAny(forbiddenAssemblies.ToArray())
            .GetResult()
            .IsSuccessful;

        Assert.True(result);
    }
    
    [Fact]
    public void CarnizzaroProjects_Should_Having_Namespace_StartingWith_Carnizzaro()
    {
        var carnizzaroModulePath = Path.Combine(VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName, "Carnizzaro");
        var subFolders = Directory.GetDirectories(carnizzaroModulePath);

        var netVersion = Environment.Version;

        var carnizzaroAssemblies = (from folder in subFolders
            let binFolder = Path.Join(folder, "bin", "Debug", $"net{netVersion.Major}.{netVersion.Minor}")
            where Directory.Exists(binFolder)
            let files = Directory.GetFiles(binFolder)
            let folderArray = folder.Split(Path.DirectorySeparatorChar)
            select files.FirstOrDefault(f => f.EndsWith($"{folderArray[folderArray!.Length - 1]}.dll"))
            into assemblyFilename
            where assemblyFilename != null && !assemblyFilename.Contains("Test")
            select Assembly.LoadFile(assemblyFilename)).ToList();
        
        var carnizzaroTypes = Types.InAssemblies(carnizzaroAssemblies)
            .That()
            .DoNotHaveNameStartingWith("<>")
            .And()
            .AreNotNested()
            .GetTypes();
        
        var typesWithCorrectNamespace = Types.InAssemblies(carnizzaroAssemblies)
            .That()
            .ResideInNamespaceStartingWith("CrastuArrustutu.Cannizzaro")
            .And()
            .AreNotNested()
            .GetTypes();
        
        // Find types with incorrect namespace (difference between the two sets)
        var riskAnalysisTypeArray = carnizzaroTypes as Type[] ?? carnizzaroTypes.ToArray();
        var typesWithIncorrectNamespace = riskAnalysisTypeArray.Except(typesWithCorrectNamespace).ToList();

        foreach (var type in typesWithIncorrectNamespace)
        {
            if (type.Namespace != null)
                Assert.Fail(
                    $"Namespace violation detected: {type.FullName} in assembly {type.Assembly.GetName().Name} should start " +
                    $"with 'CrastuArrustutu.Carnizzaro' but is in namespace '{type.Namespace}'");
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