namespace giraffe_app.Views

open Giraffe.ViewEngine
open giraffe_app.Models

module CodeBlock =
    let indent = "&nbsp;&nbsp;&nbsp;&nbsp;"

    let indentText n = 
        [1..n] 
        |> Seq.map (fun _ -> indent) 
        |> Seq.fold (+) ""

    let render code (title : string option) (lang : string option) = 
        let result = 
            html [] [
                head [] [
                    link [ _rel "stylesheet"; _type "text/css"; _href "/CSS/CodeBlock.css" ]
                ]
                div [ _class "code-block" ] [ 
                    div [ _class "code-title-bar" ] [
                        div [ _class "code-title" ] [ encodedText (title |> function | Some s -> s | None -> "<Title>") ]
                        div [ _class "code-lang" ] [ encodedText (lang |> function | Some s -> s | None -> "<Language>") ]
                    ]
                    yield! code |> Seq.map (fun line -> p [] [ rawText $"{indentText line.Indentation}{line.Content}" ])
                ]
            ]
        result