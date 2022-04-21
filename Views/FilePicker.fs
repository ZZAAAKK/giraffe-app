namespace giraffe_app.Views

open Giraffe.ViewEngine
open giraffe_app.Models

module FilePicker =
    let root = Folder ("root", None)
    let models = Folder ("Models", Some root)
    let views = Folder ("Views", Some root)
    let handlers = Folder ("Handlers", Some root)

    let folders = 
        [
            models;
            views;
            handlers
        ]

    let files = 
        [
            File ("FSO.fs", Some models, "", "F#");
            File ("CodeLine.fs", Some models, "", "F#");
            File ("Message.fs", Some models, "", "F#");
            File ("FilePicker.fs", Some views, "", "F#");
            File ("TopNav.fs", Some views, "", "F#");
            File ("CodeBlock.fs", Some views, "WebRoot/Source/CodeBlock.txt", "F#");
            File ("Index.fs", Some views, "", "F#");
            File ("About.fs", Some views, "WebRoot/Source/about.txt", "F#");
            File ("FileStructureHandler.fs", Some handlers, "", "F#");
            File ("ViewHandler.fs", Some handlers, "", "F#");
            File ("ErrorHandler.fs", Some handlers, "", "F#")
        ]

    let (|GetChildren|) parent =
        files |> Seq.filter (fun f -> f.parent.Value = parent)

    let GetFiles (files : FSO list) =
        ul [ _class "file-picker" ] [
            yield! 
                files 
                |> Seq.filter (fun fso -> fso :? Folder)
                |> Seq.map (fun file -> 
                    file :?> Folder
                    |> function
                    | GetChildren a -> li [] [ encodedText file.name; ul [] [ yield! a |> Seq.map (fun f -> li [] [ encodedText f.name ]) ] ])
        ] 

    let render =
        (folders |> List.map(fun x -> x :> FSO)) @ (files |> List.map (fun x -> x :> FSO)) |> GetFiles