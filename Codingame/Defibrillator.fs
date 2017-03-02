module Defibrillator

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

let LON = Console.In.ReadLine()
let LAT = Console.In.ReadLine()
let N = int(Console.In.ReadLine())

type pointDeg = {LongDeg:float; LatDeg:float}
type pointRad = {LongRad:float; LatRad:float}
type defib = {Number:int; Name:string; Adress:string; Tel:string; PointR:pointRad}

let getRad deg = Math.PI * deg / float(180)

let getPointRad pDeg = {LongRad=getRad pDeg.LongDeg; LatRad=getRad pDeg.LatDeg}
let getPointDeg (lon:string) (lat:string) = {LongDeg=float(lon.Replace(",", ".")); LatDeg=float(lat.Replace(",", "."))}

let rec getDefibs nbLeft =
    match nbLeft with
    | 0 -> []
    | a ->
        let defib = Console.In.ReadLine()
        let defibSplit = defib.Split [|';'|]
        let pDeg = getPointDeg defibSplit.[4] defibSplit.[5]
        let pRad = {Number=int(defibSplit.[0]); Name=defibSplit.[1]; Adress=defibSplit.[2]; Tel=defibSplit.[3]; PointR=getPointRad pDeg}
        pRad::(getDefibs (a-1))

let defibs = getDefibs N

let persPointRad = getPointRad (getPointDeg LON LAT)

let sqr x = x * x
let getDistX pointA pointB = (pointB.LongRad - pointA.LongRad) * Math.Cos((pointA.LatRad + pointB.LatRad) / float(2))
let getDistY pointA pointB = pointB.LatRad - pointA.LatRad
let getDist pointA pointB = float(6371) * Math.Sqrt(sqr (getDistX pointA pointB) + sqr (getDistY pointA pointB))

let rec getCloser (defib, minDist) point defibList =
    match defibList with
    | [] -> (defib, minDist)
    | a::b ->
        let dist = getDist point a.PointR
        if minDist < float(0) then
            getCloser (Some a, dist) point b
        else
            if minDist - dist > float(0) then
                getCloser (Some a, dist) point b
            else
                getCloser (defib, minDist) point b

let (closerDefib, dist) = getCloser (None, float(-1)) persPointRad defibs

(* Write an action using printfn *)
(* To debug: Console.Error.WriteLine("Debug message") *)

printfn "%s" closerDefib.Value.Name