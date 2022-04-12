# AmazonS3
Minio using .NET 5.0 API and  .Net CORE.MinIO Client SDK provides higher level APIs for MinIO and Amazon S3 compatible cloud storage services
# MinIO REST API Using  Client SDK for .NET 
The project is based on SDK Minio and is a REST API in .NET Core and .NET 5 versions.

## Target
 * .NET CORE | .NET 5.0
 

## MinIO Api Example
The following examples in AmazonS3.Controllers > ObjectController 

### Get Object

```cs
[HttpGet]
public async Task<ActionResult> Get(string objectname, UploadTypeList bucket)
 {
    var result = await _minio.GetObject(bucket.ToString(), objectname);

    return File(result.data, result.objectstat.ContentType);
 }
```

### Upload Object

```cs
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
```
## 1. AmazonS3_Services_Minio
To connect to an Amazon S3 compatible cloud storage service, you will need to specify the following parameters.

| Parameter  | Description|
| :---         |     :---     |
| endpoint   | URL to object storage service.   |
| accessKey | Access key is the user ID that uniquely identifies your account. |
| secretKey | Secret key is the password to your account. |
| secure | Enable/Disable HTTPS support. |

This example program connects to an object storage server in Project AmazonS3 based .Net 5 .

```cs
  public MinioObject()
        {
            _minio = new MinioClient()
                                     .WithEndpoint("Address")
                                     .WithCredentials("YOUR-ACCESSKEYID",
                                              "YOUR-SECRETACCESSKEY")
                                     .WithSSL()//if Domain is SSL
                                     .Build();
        }
```
## 2. AmazonS3_NetCore_Services_Minio
To connect to an Amazon S3 compatible cloud storage service, you will need to specify the following parameters.

| Parameter  | Description|
| :---         |     :---     |
| endpoint   | URL to object storage service.   |
| accessKey | Access key is the user ID that uniquely identifies your account. |
| secretKey | Secret key is the password to your account. |
| secure | Enable/Disable HTTPS support. |

This example program connects to an object storage server in Project AmazonS3 based .Net 5 .

```cs
  private MinioClient _minio;
        public MinioObject()
        {
            _minio = new MinioClient("Address",
                 "YOUR-ACCESSKEYID",
                 "YOUR-SECRETACCESSKEY"
                 )
                 .WithSSL();//if Domain is SSL
        }
```
## Running MinIO Api Examples


### Get object
```
  https://localhost:44333/Object?objectname=@objname&bucket=@idfromenum
```

### upload object
```
  https://localhost:44333/Object
```
Method : post

### Body

```
 "request": {
    "data": "", //byte[]
    "type": 0 // id from enum 
  }
```
##### Clone Project 

```
$ git clone https://github.com/AlexGreatDev/AmazonS3 && cd minio-AmazonS3
```

## Explore Further
* [Complete Documentation](https://docs.min.io)
* [MinIO .NET SDK API Reference](https://docs.min.io/docs/dotnet-client-api-reference)
