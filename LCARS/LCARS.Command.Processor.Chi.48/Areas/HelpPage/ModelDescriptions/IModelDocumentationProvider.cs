using System;
using System.Reflection;

namespace LCARS.Command.Processor.Chi._48.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}