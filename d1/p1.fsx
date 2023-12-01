let (>>) f g x = g (f (x))
let onlyNumbers = String.filter System.Char.IsNumber

let firstLast =
    function
    | "" -> ""
    | str -> sprintf "%c%c" str[0] str[str.Length - 1]

let toCode = onlyNumbers >> firstLast >> int

System.IO.File.ReadLines("p1_input.txt")
|> Seq.map toCode
|> Seq.fold (+) 0
|> printf "%d"
