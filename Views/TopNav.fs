namespace giraffe_app.Views

open Giraffe.ViewEngine

module TopNav =
    let render =
        div [] [
            link [ _rel "stylesheet"; _href "CSS/TopNav.css" ]
            link [ _rel "stylesheet"; _href "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" ]
            script [ _type "application/javascript"; _src "Scripts/TopNav.js" ] []
            div [ _class "topnav"; _id "topnav" ] [
                a [ _onclick "refreshContent('Home')"; _id "topnav-Home"; _class "nav-active" ] [ encodedText "Home" ]
                a [ _onclick "refreshContent('About')"; _id "topnav-About" ] [ encodedText "About" ]
                a [ _onclick "refreshContent('CodeBlock')"; _id "topnav-CodeBlock" ] [ encodedText "Code Block" ]
                a [ _onclick "refreshContent('API')"; _id "topnav-API" ] [ encodedText "Test API" ]
                a [ _class "icon"; _onclick "toggleTopNavModel()" ] [
                    i [ _class "fa fa-bars" ] []
                ]    
            ]
        ]
