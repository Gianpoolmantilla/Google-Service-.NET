using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

namespace GoogleService
{
     class CredencialUser
    {
        public static string[] _Scopes = { DriveService.Scope.Drive };
        public static UserCredential GetUserCredential(string pathCredencial, string fileCredentialName)
        {

            using (var stream = new FileStream(pathCredencial + fileCredentialName, FileMode.Open, FileAccess.Read))
            {
                string creadPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //string filePath = Path.Combine(creadPath, "driverApiCredentials", "drive-credentials.json"); // linea original - la direccion de ruta de esta linea es en c:/documento (por defecto),
                string filePath = Path.Combine(creadPath, pathCredencial);
                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _Scopes,
                    "User",
                    CancellationToken.None,
                    new FileDataStore(filePath, true)).Result;
            }
        }
    }
}
