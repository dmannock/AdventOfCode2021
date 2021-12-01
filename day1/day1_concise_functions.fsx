let depths = 
    (__SOURCE_DIRECTORY__ + "/input1.txt")
    |> System.IO.File.ReadAllLines
    |> Array.map System.Int32.Parse

let numOfIncreased =
    Array.pairwise
    >> Array.filter (fun (prev, cur) -> cur > prev)
    >> Array.length 

// --- Part One ---
depths |> numOfIncreased

// --- Part Two ---
depths
|> Array.windowed 3
|> Array.map Array.sum
|> numOfIncreased