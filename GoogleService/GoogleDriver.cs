using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleService
{
   public class GoogleDriver
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="_pathCredencial"></param>
       /// <param name="_ApplicationName"></param>
       /// <param name="nombreZip"></param>
       /// <param name="rutaDestino"></param>
       /// <param name="_contentType"></param>
       /// <param name="_FolderId"></param>
        public static void UploadFile(string _pathCredencial, string _ApplicationName, string nombreZip, string rutaDestino, string _contentType, string _FolderId)
        {

            var credencial = CredencialUser.GetUserCredential(_pathCredencial, "client_secret.json");
            //Get service
            var getService = DriverService.GetDriverService(credencial, _ApplicationName);
            //subo drive      
            UploadFileToDriver.UploadFile(getService, nombreZip, rutaDestino, _contentType, _FolderId);
        }
    }
}
