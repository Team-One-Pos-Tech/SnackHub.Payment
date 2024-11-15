using Microsoft.Extensions.Options;

namespace SnackHub.Payment.Domain
{
    public class ConfiguracaoAppOptions : IOptions<ConfiguracaoApp>
    {
        public required ConfiguracaoApp Value { get; set; }
}
}
