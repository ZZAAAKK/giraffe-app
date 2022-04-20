namespace giraffe_app.Views

open Giraffe.ViewEngine

module Index =
    let partial = 
        div [] [
            h1 [] [ encodedText "Giraffe SPA Example"]
            p [] [ encodedText "This is a website created using F# and Giraffe, to show a basic example of how to make a single page application using this framework." ]
            p [] [ encodedText "The file structure can be seen below. Click on a file to view the source code." ]
            FilePicker.render
        ]

    let render =
        html [ _lang "en-UK" ] [
            head [] [
                title []  [ encodedText "Home" ]
                link [ _rel "stylesheet"; _type "text/css"; _href "/CSS/main.css" ]
            ]
            header [] [
                TopNav.render
            ]                
            body [] [
                div [ _id "content" ] [
                    partial
                ]
            ]
        ]