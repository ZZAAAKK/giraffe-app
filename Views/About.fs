namespace giraffe_app.Views

open Giraffe.ViewEngine
open giraffe_app.Models

module About =
    let render = 
        let home = "/"
        let pageCode = 
            seq {
                { Content = "html [] ["; Indentation = 0 }
                { Content = "body [ _class \"about-body\" ] ["; Indentation = 1 }
                { Content = "h1 [] [ encodedText \"This is the about page.\" ]"; Indentation = 2 }
                { Content = "a [ _href home ] [ encodedText \"Go Home!\" ]"; Indentation = 2 }
                { Content = "]"; Indentation = 1 }
                { Content = "]"; Indentation = 0 }
            }

        div [] [
            link [ _rel "stylesheet"; _type "text/css"; _href "CSS/about.css" ]
            body [ _class "about-body" ] [
                h1 [] [ encodedText "This is the about page." ]
                p [] [ encodedText "This page is written using the following code:"]
                CodeBlock.render pageCode (Some "About.fs") (Some "F#")
                a [ _href home ] [ encodedText "Go Home!" ]
            ]
        ]