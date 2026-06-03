using System.Reflection;
using System.Reflection.Metadata ;

namespace CqrsApp.Persistence;

public class AssemblyReferences
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

}