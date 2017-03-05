module Battle

(* Auto-generated code below aims at helping you parse *)
(* the standard input according to the problem statement. *)
open System

type card =
    Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace | Error with
    member this.Value =
        match this with
        | Two -> 2
        | Three -> 3
        | Four -> 4
        | Five -> 5
        | Six -> 6
        | Seven -> 7
        | Eight -> 8
        | Nine -> 9
        | Ten -> 10
        | Jack -> 11
        | Queen -> 12
        | King -> 13
        | Ace -> 14
        | Error -> -1
    member this.compare (otherCard:card) =
        if this.Value > otherCard.Value then 1
        else if this.Value < otherCard.Value then -1
        else 0

let getCard str =
    match str with
    | "2" -> Two
    | "3" -> Three
    | "4" -> Four
    | "5" -> Five
    | "6" -> Six
    | "7" -> Seven
    | "8" -> Eight
    | "9" -> Nine
    | "10" -> Ten
    | "J" -> Jack
    | "Q" -> Queen
    | "K" -> King
    | "A" -> Ace
    | _ -> Error

let n = int(Console.In.ReadLine()) (* the number of cards for player 1 *)

let rec getCards nbLeft cards =
    if nbLeft = 0 then cards
    else
        let cardRead = Console.In.ReadLine()
        let cardReadValue = cardRead.[0..cardRead.Length - 2]
        getCards (nbLeft - 1) (List.append cards [getCard cardReadValue])

let cards1 = getCards n []

let m = int(Console.In.ReadLine()) (* the number of cards for player 2 *)

let cards2 = getCards m []

let rec battle (cards1InGame:card list) (cards2InGame:card list) (cards1InDeck:card list) (cards2InDeck:card list) =
    let card1 = cards1InDeck.Head
    let cards1Tail = cards1InDeck.Tail
    let card2 = cards2InDeck.Head
    let cards2Tail = cards2InDeck.Tail

    let compare = card1.compare card2
    if compare > 0 then
        (false, List.concat [cards1Tail; cards1InGame; [card1]; cards2InGame; [card2]], cards2Tail)
    else if compare < 0 then
        (false, cards1Tail, List.concat [cards2Tail; cards1InGame; [card1]; cards2InGame; [card2]])
    else if cards1Tail.Length < 4 || cards2Tail.Length < 4 then
        (true, cards1InDeck, cards2InDeck)
    else
        battle 
            (List.concat [cards1InGame; [card1]; cards1Tail.[0..2]])
            (List.concat [cards2InGame; [card2]; cards2Tail.[0..2]])
            cards1Tail.[3..(cards1Tail.Length - 1)]
            cards2Tail.[3..(cards2Tail.Length - 1)]

let playHand (cards1:card list) (cards2:card list) =
    battle [] [] cards1 cards2

let rec playGame (cards1:card list) (cards2:card list) nbTurns =
    if cards1.Length = 0 then "2 " + string(nbTurns)
    else if cards2.Length = 0 then "1 " + string(nbTurns)
    else
        let (isPat, newCards1, newCards2) = playHand cards1 cards2
        if isPat then "PAT"
        else playGame newCards1 newCards2 (nbTurns + 1)
    
printfn "%s" (playGame cards1 cards2 0)