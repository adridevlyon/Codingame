module AsciiArt

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System
open System.Collections.Generic


type asciiArtLetter = {Lines:string list}

let L = int(Console.In.ReadLine())
let H = int(Console.In.ReadLine())
let T = Console.In.ReadLine()

let asciiAlphabet = new Dictionary<char, asciiArtLetter>()
let letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?"
letters |> Seq.iter (fun c -> asciiAlphabet.Add(c, {Lines=[]}))

let getLetter i = (List.ofSeq letters).[i]

for i in 0 .. H - 1 do
    let ROW = Console.In.ReadLine()
    for l in 0..26 do
        let c = getLetter l
        asciiAlphabet.[c] <- {asciiAlphabet.[c] with Lines = List.concat [asciiAlphabet.[c].Lines; [ROW.[L*l .. L*l + L - 1]]]}

let getAsciiArtLetter c =
    let cUpper = Char.ToUpper(c)
    if letters |> List.ofSeq |> (List.exists (fun e -> e = cUpper)) then
        asciiAlphabet.[cUpper]
    else
        asciiAlphabet.['?']

let output = new Dictionary<int, string>()
for i in 0..H-1 do
    output.Add(i, "")

T |> Seq.iter (fun c -> 
    let asciiLetter = getAsciiArtLetter c
    for i in 0..H - 1 do
        output.[i] <- output.[i] + asciiLetter.Lines.[i]
    )

for i in 0..H-1 do
    printfn "%s" output.[i]