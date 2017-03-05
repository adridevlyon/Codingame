module PowerOfThor1

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
(* --- *)
(* Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders. *)
open System

(* lightX: the X position of the light of power *)
(* lightY: the Y position of the light of power *)
(* initialTX: Thor's starting X position *)
(* initialTY: Thor's starting Y position *)
let token = (Console.In.ReadLine()).Split [|' '|]
let lightX = int(token.[0])
let lightY = int(token.[1])
let initialTX = int(token.[2])
let initialTY = int(token.[3])

let mutable currentX = initialTX
let mutable currentY = initialTY

let getSouthNorth curY goalY =
    match curY - goalY with
    | pos when pos > 0 && curY > 0 -> ("N", curY - 1)
    | neg when neg < 0 && curY < 17 -> ("S", curY + 1)
    | _ -> ("", curY)

let getEastWest curX goalX =
    match curX - goalX with
    | pos when pos > 0 && curX > 0 -> ("W", curX - 1)
    | neg when neg < 0 && curX < 39 -> ("E", curX + 1)
    | _ -> ("", curX)

while true do
    // let remainingTurns = int(Console.In.ReadLine()) (* The remaining amount of turns Thor can move. Do not remove this line. *)
    let (southNorth, newY) = getSouthNorth currentY lightY
    let (eastWest, newX) = getEastWest currentX lightX
    currentX <- newX
    currentY <- newY
    printfn "%s%s" southNorth eastWest
