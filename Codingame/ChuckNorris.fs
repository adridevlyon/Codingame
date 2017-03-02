module ChuckNorris

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let MESSAGE = Console.In.ReadLine()

(* Write an action using printfn *)
(* To debug: Console.Error.WriteLine("Debug message") *)

let rec convertToBase b nb n =
    let u = n % b
    let rest = (n-u)/b
    match nb = 1 with
    | true -> string(u)
    | false -> (convertToBase b (nb-1) rest) + string(u)

let rec convertToString intList =
    match intList with
    | [] -> ""
    | a::b -> (convertToBase 2 7 a) + convertToString b

let messageAscii = MESSAGE |> Seq.map int |> Seq.toList |> convertToString |> Seq.map string |> Seq.toList

let rec convertToChuck previousChar strList =
    match strList with
    | [] -> ""
    | a::b when a = previousChar -> "0" + convertToChuck previousChar b
    | a::b when a = "1" -> (if previousChar = "" then "" else " ") + "0 0" + convertToChuck a b
    | a::b when a = "0" -> (if previousChar = "" then "" else " ") + "00 0" + convertToChuck a b
    | _ -> ""

let messageChuck = convertToChuck "" messageAscii

printfn "%s" messageChuck