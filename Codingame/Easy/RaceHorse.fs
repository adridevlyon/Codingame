module RaceHorse

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let N = int(Console.In.ReadLine())

let rec getPowers nbLeft powers =
    if nbLeft = 0 then
        powers
    else
        let Pi = int(Console.In.ReadLine())
        getPowers (nbLeft - 1) (Pi::powers)
        
let sortedPowers = List.sortDescending (getPowers N [])

let rec getMinDiff diff sortedPowers =
    match sortedPowers with
    | [] -> diff
    | a::[] -> diff
    | a::b::c ->
        let newDiff = a - b
        if newDiff < diff then
            getMinDiff newDiff (b::c)
        else
            getMinDiff diff (b::c)

if N = 0 then printfn "0"
else printfn "%d" (getMinDiff sortedPowers.[0] sortedPowers)