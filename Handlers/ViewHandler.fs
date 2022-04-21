namespace giraffe_app.Handlers

open Giraffe
open giraffe_app.Views
open giraffe_app.Models

module ViewHandler =
    let render (viewName : string) : HttpHandler =
        let view = 
            match viewName with
            | "About" -> About.render
            | "Home" -> Index.partial
            | "CodeBlock" -> CodeBlock.render
            | _ -> Index.render
        htmlView view

    let mutable Messages =
        [
            { Id = 1; Text = "First Message" };
            { Id = 2; Text = "Second Message" };
            { Id = 3; Text = "Third Message" };
            { Id = 4; Text = "Fourth Message" }
        ]

    let findMessage id =
        let result = List.tryFind (fun message -> message.Id = id) Messages
        match result with
        | Some(message) -> negotiate message
        | None -> setStatusCode 404 >=> text "Message not found"