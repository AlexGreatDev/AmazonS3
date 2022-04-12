using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonS3.Services.Minio.Model
{
    public class PutObjectRequest
    {
        public string bucket { get; set; }
        public byte[] data { get; set; }
    }
}
