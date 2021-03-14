using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
namespace GoogleService
{
    class DriverService
    {
        public static DriveService GetDriverService(UserCredential Credential, string nombreAplicacion)
        {
            return new DriveService(

                new BaseClientService.Initializer
                {
                    HttpClientInitializer = Credential,
                    ApplicationName = nombreAplicacion
                }
                );
        }
    }
}
