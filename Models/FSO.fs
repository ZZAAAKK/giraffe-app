namespace giraffe_app.Models

type FSO (name, parent) =
    member this.name : string = name
    member this.parent : Folder option = parent 

and Folder (name, parent) =
    inherit FSO(name, parent)

and File(name, parent, path, language) =
    inherit FSO(name, parent)
    member this.path = path
    member this.language = language