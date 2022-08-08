using AuthGuard.Infrastructure.Exceptions.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace AuthGuard.Infrastructure.Exceptions
{
    /// <summary>
    /// Global Exception Handler
    /// </summary>
    public static class Program
    {
        private static JsonSerializerSettings JsonSerializerSettings { get; set; }

        /// <summary>
        /// Exception Middleware for Global Exception Handler
        /// </summary>
        /// <param name="app">
        /// IApplicationBuilder interface. <see cref="IApplicationBuilder"/>
        /// </param>
        /// <param name="logger">
        /// Represents a type used to perform logging. Aggregates most logging patterns to a single method. <see cref="ILogger"/>
        /// </param>
        /// <param name="localizer">
        /// String Localizer interface. <see cref="IStringLocalizer"/>
        /// </param>
        public static void UseEasyExceptionHandler(this IApplicationBuilder app, ILogger logger = null,
            IStringLocalizer localizer = null)
        {
            JsonSerializerSettings = app.ApplicationServices.GetService<JsonSerializerSettings>();
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception != null)
                    {
                        var message = string.Empty;
                        var key = string.Empty;
                        object[] parameters = null;

                        var logLevel = (exception as ILeveledException)?.Level ?? LogLevel.Error;

                        if (exception is IKeyException keyException)
                        {
                            key = keyException.Key;
                            parameters = keyException.Params;

                            message = localizer?.GetString(keyException.Key, keyException.Params);
                        }

                        logger?.Log(logLevel, exception, exception.Message, parameters);

                        if (exception is IStatusCodeException sException)
                        {
                            // Gets BaseException's Status Code and set to response
                            context.Response.StatusCode = (int)sException.StatusCode;

                            var isUserFriendlyMessage = !string.IsNullOrEmpty(message) && message != key;

                            var useExMessage = string.IsNullOrEmpty(message) || message == key;

                            // Finishes Request and Write Response. IsUserFriendly depends on value is null or not
                            await ResponseAsync(context, useExMessage ? exception.Message : message, key,
                                isUserFriendlyMessage);
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            await ResponseAsync(context, exception.Message, "systemException", message != null);
                        }
                    }
                    else
                    {
                        await ResponseAsync(context, "Unhandled Exception!", "Unhandled");
                    }
                });
            });
        }

        private static Task ResponseAsync(HttpContext context, string message, string key = null,
            bool? friendlyMessage = null)
        {
            // Set Content-Type header.
            context.Response.ContentType = "application/json";

            // Body of response.
            var body = new { Message = message, IsUserFriendlyMessage = friendlyMessage, Key = key };

            // Json format of body.
            var json = JsonConvert.SerializeObject(body, JsonSerializerSettings);

            // Write all response and finish request.
            return context.Response.WriteAsync(json);
        }
    }
}
