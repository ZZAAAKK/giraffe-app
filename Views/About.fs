﻿namespace giraffe_app.Views

open Giraffe.ViewEngine

module About =
    let render = 
        div [] [
            body [ _class "about-body" ] [
                h1 [] [ encodedText "This is the about page." ]
                p [] [ encodedText "This page is written using the following code:"]
                CodeBlock.partial (FilePicker.files |> List.filter(fun f -> f.name = "About.fs") |> List.exactlyOne)
            ]
        ]