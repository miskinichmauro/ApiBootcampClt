namespace ApiBootcampClt.Api.Contracts.Common;

public sealed record ErrorResponse(
    int StatusCode,
    string Message
);
