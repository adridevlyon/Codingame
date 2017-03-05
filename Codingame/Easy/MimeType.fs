module MimeType

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let N = int(Console.In.ReadLine()) (* Number of elements which make up the association table. *)
let Q = int(Console.In.ReadLine()) (* Number Q of file names to be analyzed. *)

type mimeTypes = {Ext:string; Mime:string}

let rec getKnownMimes nbLeft mimes =
    if nbLeft = 0 then mimes
    else
        let token = (Console.In.ReadLine()).Split [|' '|]
        let EXT = token.[0]
        let MT = token.[1]
        getKnownMimes (nbLeft - 1) ({Ext=EXT.ToLower(); Mime=MT}::mimes)

let knownMimes = getKnownMimes N []

let rec getMime mimes ext =
    if ext = "" then "UNKNOWN"
    else
        match mimes with
        | [] -> "UNKNOWN"
        | a::b ->
            if ext = a.Ext then
                a.Mime
            else
                getMime b ext

for i in 0 .. Q - 1 do
    let FNAME = Console.In.ReadLine() (* One file name per line. *)
    let fileNameSplit = FNAME.Split [|'.'|]
    let ext = 
        if fileNameSplit.Length > 1 then
            fileNameSplit.[fileNameSplit.Length - 1].ToLower()
        else
            ""
    printfn "%s" (getMime knownMimes ext)