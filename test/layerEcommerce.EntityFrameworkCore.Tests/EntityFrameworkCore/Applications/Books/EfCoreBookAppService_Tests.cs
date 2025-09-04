using layerEcommerce.Books;
using Xunit;

namespace layerEcommerce.EntityFrameworkCore.Applications.Books;

[Collection(layerEcommerceTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<layerEcommerceEntityFrameworkCoreTestModule>
{

}