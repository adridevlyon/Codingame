module Skynet1

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System
open System.Collections.Generic

(* N: the total number of nodes in the level, including the gateways *)
(* L: the number of links *)
(* E: the number of exit gateways *)
let token = (Console.In.ReadLine()).Split [|' '|]
let N = int(token.[0])
let L = int(token.[1])
let E = int(token.[2])

type node = {Name:int; mutable IsPlatform:bool; LinkWithDistanceToExit: Dictionary<int, int>}
let nodes = List.init N (fun i -> {Name=i; IsPlatform=false; LinkWithDistanceToExit=new Dictionary<int, int>()})

let addLink node1Index node2Index (nodes: node list) =
    let node1 = nodes.[node1Index]
    let node2 = nodes.[node2Index]
    node1.LinkWithDistanceToExit.[node2Index] <- -1
    node2.LinkWithDistanceToExit.[node1Index] <- -1

for i in 0 .. L - 1 do
    (* N1: N1 and N2 defines a link between these nodes *)
    let token1 = (Console.In.ReadLine()).Split [|' '|]
    let N1 = int(token1.[0])
    let N2 = int(token1.[1])
    addLink N1 N2 nodes

let addPlatform index (nodes:node list) =
    let nodePlatform = nodes.[index]
    nodePlatform.IsPlatform <- true

for i in 0 .. E - 1 do
    let EI = int(Console.In.ReadLine()) (* the index of a gateway node *)
    addPlatform EI nodes

let computeDistances (nodes:node list) =
    

(* game loop *)
while true do
    let SI = int(Console.In.ReadLine()) (* The index of the node on which the Skynet agent is positioned this turn *)
    
    (* Example: 0 1 are the indices of the nodes you wish to sever the link between *)
    printfn "0 1"
    ()
