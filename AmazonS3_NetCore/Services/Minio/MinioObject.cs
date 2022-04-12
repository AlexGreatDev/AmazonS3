
using AmazonS3_NetCore.Services.Minio.Model;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AmazonS3_NetCore.Services.Minio
{

    public class MinioObject
    {

        private MinioClient _minio;
        public MinioObject()
        {
            _minio = new MinioClient("Address",
                 "YOUR-ACCESSKEYID",
                 "YOUR-SECRETACCESSKEY"
                 )
                 .WithSSL();//if Domain is SSL
        }
        public async Task<string> PutObj(PutObjectRequest request)
        {

            var bucketName = request.bucket;
            // Check Exists bucket
            bool found = await _minio.BucketExistsAsync(bucketName);
            if (!found)
            {
                // if bucket not Exists,make bucket
                await _minio.MakeBucketAsync(bucketName);
            }

            System.IO.MemoryStream filestream = new System.IO.MemoryStream(request.data);

            var filename = Guid.NewGuid();
            // upload object
            await _minio.PutObjectAsync(bucketName,
                                        filename.ToString(),
                                        filestream,
                                        filestream.Length
                                       );

            return await Task.FromResult<string>(filename.ToString());
        }
        public async Task<GetObjectReply> GetObject(string bucket, string objectname)
        {


            MemoryStream destination = new MemoryStream();
            // Check Exists object
            var objstatreply = await _minio.StatObjectAsync(bucket, objectname);


            if (objstatreply == null)
                throw new Exception("object not found or Deleted");

            // Get object
            await _minio.GetObjectAsync(bucket, objectname,
                                        (stream) =>
                                        {
                                            stream.CopyTo(destination);
                                        });

            return await Task.FromResult<GetObjectReply>(new GetObjectReply()
            {
                data = destination.ToArray(),
                objectstat = objstatreply

            });
        }
    }
}
