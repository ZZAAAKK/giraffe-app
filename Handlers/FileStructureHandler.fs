namespace giraffe_app.Handlers

open giraffe_app.Models

module FileStructureHandler =
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

    let GetFSOObjectByName name = 
        match name with
        | "root" | "Models" | "Views" | "Handlers" -> folders |> Seq.map (fun f -> f :> FSO)
        | _ -> files |> Seq.map (fun f -> f :> FSO)
        |> Seq.where (fun x -> x.name = name) 
        |> Seq.tryExactlyOne