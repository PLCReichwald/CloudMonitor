namespace CloudMonitor.Data.Enums;

public enum EStatusCodes
{
    None = 0,
    CertificateExpired = 1,
    PageNotAvailable = 2,
    Timeout = 3,
    Success = 200,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    InternalServerError = 500
}