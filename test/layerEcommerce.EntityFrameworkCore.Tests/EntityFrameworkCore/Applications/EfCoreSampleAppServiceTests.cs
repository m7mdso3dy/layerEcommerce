using layerEcommerce.Samples;
using Xunit;

namespace layerEcommerce.EntityFrameworkCore.Applications;

[Collection(layerEcommerceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<layerEcommerceEntityFrameworkCoreTestModule>
{

}
