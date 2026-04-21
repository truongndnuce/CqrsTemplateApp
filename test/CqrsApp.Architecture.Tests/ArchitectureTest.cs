using FluentAssertions;
using NetArchTest.Rules;

namespace CqrsApp.Architecture.Tests;

public class Tests
{
    private const string ApplicationNameSpace = "CqrsApp.Application";
    private const string ApiNameSpace = "CqrsApp.API";
    private const string InfrastructureNameSpace = "CqrsApp.Infrastructure";
    private const string PersistenceNameSpace = "CqrsApp.Persistence";
    private const string PresentationNameSpace = "CqrsApp.Presentation";
        
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DomainShouldNotHasDependencyOnOtherProjects()
    {
        // Arrage
        var assembly = Domain.AssemblyReferences.Assembly;

        var otherProjects = new[]
        {
            ApplicationNameSpace,
            InfrastructureNameSpace,
            PresentationNameSpace,
            PersistenceNameSpace,
            ApiNameSpace,
        };
        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();
        // Assert
        
        result.IsSuccessful.Should().BeTrue();
    }
    [Test]
    public void ApplicationShouldNotHasDependencyOnOtherProjects()
    {
        // Arrage
        var assembly = Application.AssemblyReferences.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNameSpace,
            PresentationNameSpace,
            PersistenceNameSpace,
            ApiNameSpace,
        };
        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();
        // Assert
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Test]
    public void PersistenceShouldNotHasDependencyOnOtherProjects()
    {
        // Arrage
        var assembly = Application.AssemblyReferences.Assembly;

        var otherProjects = new[]
        {
            PresentationNameSpace,
            ApiNameSpace,
            ApplicationNameSpace,
            InfrastructureNameSpace,
        };
        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();
        // Assert
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Test]
    public void InfrastructureShouldNotHasDependencyOnOtherProjects()
    {
        // Arrage
        var assembly = Application.AssemblyReferences.Assembly;

        var otherProjects = new[]
        {
            PresentationNameSpace,
            ApiNameSpace,
        };
        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();
        // Assert
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Test]
    public void PresentationShouldNotHasDependencyOnOtherProjects()
    {
        // Arrage
        var assembly = Application.AssemblyReferences.Assembly;

        var otherProjects = new[]
        {
            InfrastructureNameSpace,
            ApiNameSpace,
        };
        // Act
        var result = Types.InAssembly(assembly).ShouldNot().HaveDependencyOnAny(otherProjects).GetResult();
        // Assert
        
        result.IsSuccessful.Should().BeTrue();
    }
}