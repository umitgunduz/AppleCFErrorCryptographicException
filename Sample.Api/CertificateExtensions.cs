using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;

namespace Sample.Api
{
    public static class CertificateExtensions
    {
        public static X509Certificate2 GetRSACertificate(this IWebHostEnvironment env)
        {
            X509Certificate2 result = null;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Sample.Api.rsaCert.pfx";
            using var resFilestream = assembly.GetManifestResourceStream(resourceName);
            if (resFilestream == null) return null;
            var ba = new byte[resFilestream.Length];
            resFilestream.Read(ba, 0, ba.Length);
            result = new X509Certificate2(ba, "secret");
            return result;
        }
    }
}