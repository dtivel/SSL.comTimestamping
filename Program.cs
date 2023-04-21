using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Test
{
    internal static class Program
    {
        // RFC 3280 "id-kp-timeStamping" https://datatracker.ietf.org/doc/html/rfc3280.html#section-4.2.1.13
        private const string TimeStampingEku = "1.3.6.1.5.5.7.3.8";

        private static void Main()
        {
            BuildCurrentChain();
            BuildNewChain();
        }

        private static void BuildCurrentChain()
        {
            using (X509Certificate2 leaf = Certificates.GetSSLcomTimestampingLeaf())
            using (X509Certificate2 timestampingIntermediate = Certificates.GetSSLcomTimestampingIntermediate())
            using (X509Certificate2 intermediate = Certificates.GetSSLcomIntermediate())
            using (X509Certificate2 root = Certificates.GetCertumRoot())
            {
                BuildChain("current", leaf, timestampingIntermediate, intermediate, root);
            }
        }

        private static void BuildNewChain()
        {
            using (X509Certificate2 leaf = Certificates.GetSSLcomTimestampingLeaf())
            using (X509Certificate2 timestampingIntermediate = Certificates.GetSSLcomTimestampingIntermediate())
            using (X509Certificate2 root = Certificates.GetSSLcomNewRoot())
            {
                BuildChain("new", leaf, timestampingIntermediate, root);
            }
        }

        private static void BuildChain(string which, X509Certificate2 leaf, params X509Certificate2[] extraCertificates)
        {
            using (X509Chain chain = new())
            {
                chain.ChainPolicy.ApplicationPolicy.Add(new Oid(TimeStampingEku));

                foreach (X509Certificate2 extraCertificate in extraCertificates)
                {
                    chain.ChainPolicy.ExtraStore.Add(extraCertificate);
                }

                string overallChainStatus;

                if (chain.Build(leaf))
                {
                    overallChainStatus = "OK";
                }
                else
                {
                    overallChainStatus = string.Join(",", chain.ChainStatus.Select(status => status.Status));
                }

                Console.WriteLine();
                Console.WriteLine($"The {which} certificate chain is (leaf -> root):");
                Console.WriteLine();

                for (var i = 0; i < chain.ChainElements.Count; ++i)
                {
                    X509ChainElement element = chain.ChainElements[i];
                    X509Certificate2 elementCertificate = element.Certificate;

                    Console.WriteLine($"  {i}: Subject:    {elementCertificate.Subject}");
                    Console.WriteLine($"     Issuer:     {elementCertificate.Issuer}");
                    Console.WriteLine($"     NotBefore:  {elementCertificate.NotBefore.ToUniversalTime():yyyy-MM-dd HH:mm:ss.fffZ}");
                    Console.WriteLine($"     NotAfter:   {elementCertificate.NotAfter.ToUniversalTime():yyyy-MM-dd HH:mm:ss.fffZ}");
                    Console.WriteLine($"     SHA-1:      {elementCertificate.GetCertHashString()}");
                    Console.WriteLine($"     SHA-256:    {elementCertificate.GetCertHashString(HashAlgorithmName.SHA256)}");
                    Console.WriteLine();
                }

                Console.WriteLine($"Overall chain status:  {overallChainStatus}");
                Console.WriteLine();
            }
        }
    }
}