using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackHub.Payment.Domain
{
    public class ConfiguracaoApp
    {
        public Mercadopago MercadoPago { get; set; }
    }

    public class Mercadopago
    {
        public string BaseUrl { get; set; }
        public string PublicKey { get; set; }
        public string AccessToken { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

}
