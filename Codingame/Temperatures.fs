module Temperatures

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let n = int(Console.In.ReadLine()) (* the number of temperatures to analyse *)
let temps = Console.In.ReadLine() (* the n temperatures expressed as integers ranging from -273 to 5526 *)

if n=0 then printfn "0"
else
    let tempsTable = temps.Split [|' '|]
    let tempsList = tempsTable |> Seq.map int |> Seq.toList

    let rec getTempCloserToZero (closer:Option<int>) tempTable =
        match tempTable with
        | [] ->
            match closer with
            | None -> printfn "0"
            | Some t -> printfn "%d" t
        | a::b ->
            match closer with
            | None -> getTempCloserToZero (Some a) b
            | Some c ->
                let absC = Math.Abs(c)
                let absA = Math.Abs(a)
                if absC > absA then
                    getTempCloserToZero (Some a) b
                else if absC < absA then
                    getTempCloserToZero (Some c) b
                else
                    if c > 0 || a > 0 then
                        getTempCloserToZero (Some absA) b
                    else
                        getTempCloserToZero closer b

    getTempCloserToZero None tempsList