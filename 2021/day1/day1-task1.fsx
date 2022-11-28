#!/usr/bin/env dotnet fsi

open System.IO

let readlines (filePath: string) = seq {
    use streamReader = new StreamReader(filePath)
    while not streamReader.EndOfStream do
        yield streamReader.ReadLine()
}

let measurements = readlines("input") |> Seq.map(fun n -> n |> int) |> Seq.toList

let filter(list: list<int>) = seq {
    for i = 1 to (list |> List.length) - 1 do
        if list[i] > list[i-1] then
            yield i
}

printfn "%d measurements are larger than the previous ones." (filter(measurements) |> Seq.length)
