using System;
using Lykke.Common.Api.Contract.Responses;
using Refit;

namespace Lykke.Service.ResourceLocker.Client.Exceptions
{
    internal static class ExceptionFactories
    {
        public static Func<ErrorResponse, ApiException, DefaultErrorResponseException> CreateDefaultException =>
            (error, apiException) => new DefaultErrorResponseException(error, apiException);
    }
}
