using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;

namespace GoogleDrivePictureRenamer
{
    public class Renamer
    {
        private const string m_strCertFileName = @"resources\GoogleDrivePictureRenamer-986492c56ea0.p12";
        private const string m_strServiceAccountEmail = "1080301477656-nmippa55unnlrhm8htsb6sk8768blk44@developer.gserviceaccount.com";

        private bool m_Connected;

        public bool Connected
        {
            get
            {
                if (!m_Connected)
                {
                    Connect();
                    m_Connected = true;
                }
                
                return TryConnect()
            }
        }

        public void Connect()
        {
            string strCertFilePath = Assembly.GetExecutingAssembly().Location + @"..\..\" + m_strCertFileName;
            string[] scopes = {DriveService.Scope.Drive}; // Full access

            X509Certificate2 certAuth = new X509Certificate2(strCertFilePath, "notasecret",
                X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential =
                new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(m_strServiceAccountEmail) {Scopes = scopes}.FromCertificate
                        (certAuth));
        }
    }
}
