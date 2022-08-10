using System.Net;
using AuthGuard.Infrastructure.Exceptions.Abstractions;
using Microsoft.Extensions.Logging;

namespace AuthGuard.Infrastructure.Exceptions.Core
{
    /// <summary>
    /// This is a base exception for all exceptions. Also this has implementation of <see cref="IKeyException"/>, <see cref="IStatusCodeException"/> and <see cref="ILeveledException"/>.
    /// </summary>
    [Serializable]
    public class BaseException : Exception, IKeyException, IStatusCodeException, ILeveledException
    {
        private string _key;
        private LogLevel? _level;
        private int _code;
        private string _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        public BaseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Passes message to base constructor.</param>
        public BaseException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Passes message to base constructor.</param>
        /// <param name="innerException">Passes innerExcetion to base constructor.</param>
        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="statusCode">Status code to return.</param>
        public BaseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="statusCode">Status code to return.</param>
        /// <param name="message">Message of exception.</param>
        public BaseException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="statusCode">Status code to return.</param>
        /// <param name="message">Message of exception.</param>
        /// <param name="innerException">InnerException can be attached.</param>
        public BaseException(HttpStatusCode statusCode, string message, Exception innerException) : base(message,
            innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="message">Message of Exception.</param>
        /// <param name="instance">Instance of Exception.</param>
        /// <param name="innerException">Inner Exception can be attached.</param>
        public BaseException(string message, string instance, Exception innerException) : base(message, innerException)
        {
            Instance = instance;
        }

        public BaseException(string message, string instance) : base(message)
        {
            Instance = instance;
        }

        /// <summary>
        /// Gets status code to return as ApiResponse.
        /// </summary>
        public virtual HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets resources key for localization.
        /// </summary>
        public virtual string Key
        {
            get => _key ?? StatusCode.ToString();
            set => _key = value;
        }

        /// <inheritdoc/>
        public object[] Params { get; set; } = Array.Empty<object>();

        /// <inheritdoc/>
        public virtual LogLevel Level
        {
            get => _level ?? LogLevel.Error;
            set => _level = value;
        }

        public virtual int Code
        {
            get => _code == 0 ? (int)StatusCode : _code;
            set => _code = value;
        }

        public string Instance
        {
            get => _instance ?? Guid.NewGuid().ToString();
            set => _instance = value;
        }
    }
}