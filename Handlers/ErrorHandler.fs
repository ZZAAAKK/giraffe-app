namespace giraffe_app.Handlers
open Giraffe
open System
open Microsoft.Extensions.Logging

module ErrorHandler =
    let render (ex : Exception) (logger : ILogger) =
        logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
        clearResponse >=> setStatusCode 500 >=> text ex.Message