using Xunit;

namespace layerEcommerce.EntityFrameworkCore;

[CollectionDefinition(layerEcommerceTestConsts.CollectionDefinitionName)]
public class layerEcommerceEntityFrameworkCoreCollection : ICollectionFixture<layerEcommerceEntityFrameworkCoreFixture>
{

}
