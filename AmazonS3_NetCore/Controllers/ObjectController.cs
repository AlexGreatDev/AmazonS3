using AmazonS3_NetCore.Model;
using AmazonS3_NetCore.Services.Minio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonS3_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjectController : ControllerBase
    {
    

        private readonly ILogger<ObjectController> _logger;
        private readonly MinioObject _minio;

        public ObjectController(ILogger<ObjectController> logger, MinioObject minio)
        {
            _logger = logger;
            _minio = minio;
        }

    
        [HttpGet]
        public async Task<ActionResult> Get(string objectname, UploadTypeList bucket)
        {
            
            var result = await _minio.GetObject(bucket.ToString(), objectname);

            return File(result.data, result.objectstat.ContentType);
        }

        [HttpPost]
        public async Task<ActionResult> Post(UploadRequest request)
        {

            var result = await _minio.PutObj(new Services.Minio.Model.PutObjectRequest()
            {
                bucket = request.type.ToString(),
                data = request.data

            });

            return Ok(new { filename = result });
        }

    }
}
