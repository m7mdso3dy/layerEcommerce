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

        //Categories
        var categoriesPermission = myGroup.AddPermission(layerEcommercePermissions.Categories.Default, L("Permission:Categories"));
        categoriesPermission.AddChild(layerEcommercePermissions.Categories.Create, L("Permission:Categories.Create"));
        categoriesPermission.AddChild(layerEcommercePermissions.Categories.Edit, L("Permission:Categories.Edit"));
        categoriesPermission.AddChild(layerEcommercePermissions.Categories.Delete, L("Permission:Categories.Delete"));

        //Products
        var productsPermission = myGroup.AddPermission(layerEcommercePermissions.Products.Default, L("Permission:Products"));
        productsPermission.AddChild(layerEcommercePermissions.Products.Create, L("Permission:Products.Create"));
        productsPermission.AddChild(layerEcommercePermissions.Products.Edit, L("Permission:Products.Edit"));
        productsPermission.AddChild(layerEcommercePermissions.Products.Delete, L("Permission:Products.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<layerEcommerceResource>(name);
    }
}
