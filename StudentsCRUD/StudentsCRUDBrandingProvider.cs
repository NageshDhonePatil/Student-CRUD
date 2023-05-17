using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace StudentsCRUD;

[Dependency(ReplaceServices = true)]
public class StudentsCRUDBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StudentsCRUD";
}
