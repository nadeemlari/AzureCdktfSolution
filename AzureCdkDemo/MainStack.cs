using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Azurerm.Provider;
using HashiCorp.Cdktf.Providers.Azurerm.ResourceGroup;
using HashiCorp.Cdktf.Providers.Azurerm.StorageAccount;
using HashiCorp.Cdktf.Providers.Azurerm.VirtualNetwork;
using HashiCorp.Cdktf.Providers.Azurerm.StorageContainer;


namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            new AzurermProvider(this, "AzureRm", new AzurermProviderConfig
            {
                Features = new AzurermProviderFeatures()
            });

            var rg = new ResourceGroup(this, "rgtemp", new ResourceGroupConfig
            {
                 Location = "South India",
                 Name="RG-CDKTF"
            });

            new VirtualNetwork(this, "TfVnet", new VirtualNetworkConfig
            {
                Location = rg.Location,
                AddressSpace = new[] { "10.0.0.0/24" },
                Name = "TerraformVNet",
                ResourceGroupName = rg.Name
            });
            var stg = new StorageAccount(this, "str", new StorageAccountConfig
            {
                Name = "examplae",
                Location = rg.Location,
                AccessTier = "Standard",
                AccountReplicationType = "GRS"

            });
            //new StorageContainer(this, "cont", new StorageContainerConfig
            //{
            //    Name="vdhs",
            //    StorageAccountName = stg.Name,
            //    ContainerAccessType ="private"
            //});
        }
    }
}