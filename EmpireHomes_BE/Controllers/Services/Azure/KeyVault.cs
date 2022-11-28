using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace EmpireHomes_BE.Controllers.Services.Azure
{
    public class KeyVault
    {

        private readonly ClientSecretCredential credential;
        private readonly string kvURL;
        public KeyVault(IConfiguration iConfig) 
        {
            kvURL = iConfig.GetValue<string>("KeyVaultConfig:KvURL");
            string tenantId = iConfig.GetValue<string>("KeyVaultConfig:TenantID");
            string clientId = iConfig.GetValue<string>("KeyVaultConfig:ClientID");
            string clientSecret = iConfig.GetValue<string>("KeyVaultConfig:ClientSecret");

            credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        }

        public SecretClient GetKeyVaultClient()
        {
            return new SecretClient(new Uri(kvURL), credential);
        }
    }
}
