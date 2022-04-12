using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minio;
using Minio.DataModel;

namespace AmazonS3.Services.Minio.Model
{
    public class GetObjectReply
    {
        public  ObjectStat  objectstat { get; set; }
        public byte[] data { get; set; }
    }
}