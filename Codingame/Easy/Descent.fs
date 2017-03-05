﻿module Descent

(* The while loop represents the game. *)
(* Each iteration represents a turn of the game *)
(* where you are given inputs (the heights of the mountains) *)
(* and where you have to print an output (the index of the mountain to fire on) *)
(* The inputs you are given are automatically updated according to your last actions. *)
open System

(* game loop *)
while true do
    let mutable maxHeight = -1
    let mutable indexMaxHeight = -1
    for i in 0 .. 8 - 1 do
        let mountainH = int(Console.In.ReadLine()) (* represents the height of one mountain. *)
        if mountainH > maxHeight then
            indexMaxHeight <- i
            maxHeight <- mountainH

    printfn "%d" indexMaxHeight
