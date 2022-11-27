using System.Runtime.Serialization;

namespace api.engine_v2.Models.Engine.Enums
{
    public enum TransferMethod
    {
        [EnumMember(Value = "mc")]mc,
        [EnumMember(Value = "ftp")]ftp,
        [EnumMember(Value = "sftp")]sftp,
        [EnumMember(Value = "ftpes")]ftpes,
        [EnumMember(Value = "http")]http,
        [EnumMember(Value = "https")]https,
        [EnumMember(Value = "s3")]s3,
        [EnumMember(Value = "other")]other,
        [EnumMember(Value = "fido")]fido
    }
}

