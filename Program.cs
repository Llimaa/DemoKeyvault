using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration.AddAzureKeyVault(
new Uri("https://demowebkeyvault.vault.azure.net/"),
new DefaultAzureCredential(new DefaultAzureCredentialOptions
{
    TenantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
}));

var app = builder.Build();

var result = configuration["MySecret"];

app.MapGet("/", () => result);

app.Run();