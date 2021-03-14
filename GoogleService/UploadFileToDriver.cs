using System.Collections.Generic;
using System.IO;
using Google.Apis.Drive.v3;


namespace GoogleService
{
     class UploadFileToDriver
    {   
        public static string UploadFile(DriveService service, string fileName, string filePath, string contentType, string FolderId)
        {

            var fileMatadata = new Google.Apis.Drive.v3.Data.File();
            fileMatadata.Name = fileName;
            fileMatadata.Parents = new List<string> { FolderId };

            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = service.Files.Create(fileMatadata, stream, contentType);
                request.Upload();
            }

            var file = request.ResponseBody;
            return file.Id;
        }
    }
}
