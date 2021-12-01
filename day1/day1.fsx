open System
open System.IO

let measureIncreased (depths: int array) =
    depths
    |> Array.pairwise
    |> Array.filter (fun (prev, cur) -> cur > prev)
    |> Array.length

File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")
|> Array.map Int32.Parse
|> measureIncreased

//ans with input1.txt: 1288

// --- Part Two ---
System.IO.File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")
|> Array.map System.Int32.Parse
|> Array.windowed 3
|> Array.map Array.sum
|> Array.pairwise
|> Array.filter (fun (prev, cur) -> cur > prev)
|> Array.length