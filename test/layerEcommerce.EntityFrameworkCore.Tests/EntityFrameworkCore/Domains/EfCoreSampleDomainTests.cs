using layerEcommerce.Samples;
using Xunit;

namespace layerEcommerce.EntityFrameworkCore.Domains;

[Collection(layerEcommerceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<layerEcommerceEntityFrameworkCoreTestModule>
{

}
