let input = System.IO.File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")

let (|ParseInt|) = System.Int32.Parse

let applyCommand (pos, depth) (line: string) =
    match line.Split " " with
    | [| "forward" ; ParseInt dist   |] -> (pos + dist, depth) 
    | [| "down"    ; ParseInt amount |] -> (pos, depth + amount) 
    | [| "up"      ; ParseInt amount |] -> (pos, depth - amount) 
    | _ -> failwith $"unknown command {line}"

input
|> Array.fold applyCommand (0, 0)
||> (*)

// --- Part Two ---
let applyCommand2 (pos, depth, aim) (line: string) =
    match line.Split " " with
    | [| "forward" ; ParseInt dist   |] -> (pos + dist, depth + aim * dist, aim) 
    | [| "down"    ; ParseInt amount |] -> (pos, depth, aim + amount) 
    | [| "up"      ; ParseInt amount |] -> (pos, depth, aim - amount) 
    | _ -> failwith $"unknown command {line}"

input
|> Array.fold applyCommand2 (0, 0, 0)
|> (fun (pos, depth, _) -> pos * depth)