using layerEcommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace layerEcommerce.Permissions;

public class layerEcommercePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(layerEcommercePermissions.GroupName);

        var booksPermission = myGroup.AddPermission(layerEcommercePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(layerEcommercePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(layerEcommercePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(layerEcommercePermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(layerEcommercePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<layerEcommerceResource>(name);
    }
}
