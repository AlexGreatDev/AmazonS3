using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonS3_NetCore.Model
{
    public class UploadRequest
    {
        public UploadTypeList type { get; set; }
        public byte[] data { get; set; }
    }
}
