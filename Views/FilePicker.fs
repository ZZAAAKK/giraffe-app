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
            root;
            models;
            views;
            handlers
        ]

    let files = 
        [
            File ("Folder.fs", Some models, "", "F#");
            File ("File.fs", Some models, "", "F#");
            File ("FSO.fs", Some models, "", "F#");
            File ("CodeLine.fs", Some models, "", "F#");
            File ("Message.fs", Some models, "", "F#");
            File ("FilePicker.fs", Some views, "", "F#");
            File ("TopNav.fs", Some views, "", "F#");
            File ("CodeBlock.fs", Some views, "", "F#");
            File ("Index.fs", Some views, "", "F#");
            File ("About.fs", Some views, "", "F#");
            File ("FileStructureHandler.fs", Some handlers, "", "F#");
            File ("ViewHandler.fs", Some handlers, "", "F#");
            File ("ErrorHandler.fs", Some handlers, "", "F#")
        ]

    let (|GetChildren|) parent =
        files |> Seq.filter (fun f -> f.parent = parent)

    let GetFiles (files : FSO list) =
        ul [] [
            yield! 
                files 
                |> Seq.filter (fun fso -> fso :? File)
                |> Seq.map (fun file -> li [] [ 
                    match file.parent with
                    | GetChildren a -> li [] [ ul [] [ yield! a |> Seq.map (fun f -> li [] [ encodedText f.name ]) ] ]])
        ] 

    let render =
        (folders |> List.map(fun x -> x :> FSO)) @ (files |> List.map (fun x -> x :> FSO)) |> GetFiles