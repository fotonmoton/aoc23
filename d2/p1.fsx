let (>>) f g x = g (f (x))

let debug v =
    printf "%A\n" v
    v


let totalReds = 12
let totalGreens = 13
let totalBlues = 14

type Play = { Reds: int; Greens: int; Blues: int }

type Game = { Round: int; Plays: Play [] }

type AddMoves = Play -> string -> Play

let addMoves: AddMoves =
    fun play move ->

        match move.Trim().Split(" ") with
        | [| num; color |] when color = "green" -> { play with Greens = play.Greens + int num }
        | [| num; color |] when color = "blue" -> { play with Blues = play.Blues + int num }
        | [| num; color |] when color = "red" -> { play with Reds = play.Reds + int num }
        | _ -> failwith "can't parse move"


let toPlay (play: string) =
    play.Trim().Split(",")
    |> Array.fold addMoves { Reds = 0; Greens = 0; Blues = 0 }

let getPlays (plays: string) =
    plays.Trim().Split(";") |> Array.map toPlay

let getRound (round: string) : int = round.Trim().Split(" ")[1] |> int

let toGame (line: string) : Game =
    match line.Split(":") with
    | [| round; plays |] ->
        { Round = getRound round
          Plays = getPlays plays }
    | _ -> failwith "can't get game"


let possible (game: Game) =
    Array.exists
        (fun play ->
            play.Blues > totalBlues
            || play.Reds > totalReds
            || play.Greens > totalGreens)
        game.Plays

let filepath =
    function
    | [| _; __; path |] -> path
    | _ -> failwith "go get some input"

System.Environment.GetCommandLineArgs()
|> filepath
|> System.IO.File.ReadLines
|> Seq.map toGame
|> Seq.filter (possible >> not)
|> Seq.map _.Round
|> Seq.sum
|> debug
