let reportAsBits =
    System.IO.File.ReadAllLines (__SOURCE_DIRECTORY__ + "/input1.txt")
    |> Array.map (Seq.toArray >> Array.map ((=) '1'))

let mostCommon report = 
    [|for pos in 0..(report |> Array.head |> Array.length) - 1 -> 
        report
        |> Array.map (Array.item pos)
        |> Array.partition id
        ||> (fun set unset -> Array.length set >= Array.length unset)
    |]

let boolsToInt (bools: bool array) =
    let bits = bools |> Array.rev |> System.Collections.BitArray
    let output = Array.create 1 0
    bits.CopyTo(output, 0)
    output[0]
    
let calcPowerConsumption report =
    let mostCommon = mostCommon report
    let gammaRate = mostCommon |> boolsToInt
    let epsilonRate = mostCommon |> Array.map (not) |> boolsToInt
    gammaRate * epsilonRate

reportAsBits 
|> calcPowerConsumption

// --- Part Two ---
let calcScrubberRating report =
    let binRange = [|0..(report |> Array.head |> Array.length) - 1|]
    let filterRemaining compareOp remaining idx  = 
        if Array.length remaining > 1 
        then remaining |> Array.filter (Array.item idx >> compareOp (mostCommon remaining |> Array.item idx))
        else remaining
    let calcRating compareOp =
        binRange
        |> Array.fold (filterRemaining compareOp) report
        |> Array.head
        |> boolsToInt
    calcRating (=) * calcRating (<>)

reportAsBits
|> calcScrubberRating