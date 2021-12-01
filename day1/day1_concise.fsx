System.IO.File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")
|> Array.map System.Int32.Parse
|> Array.pairwise
|> Array.filter (fun (prev, cur) -> cur > prev)
|> Array.length

// --- Part Two ---
System.IO.File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")
|> Array.map System.Int32.Parse
|> Array.windowed 3
|> Array.map Array.sum
|> Array.pairwise
|> Array.filter (fun (prev, cur) -> cur > prev)
|> Array.length