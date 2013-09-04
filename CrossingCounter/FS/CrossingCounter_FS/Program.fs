open System
open System.IO

module Program =

    // データファイルを読み込み数値のシーケンスを作成する
    let readNumbers filePath =
        File.ReadLines(filePath)
        |> Seq.cast<string>
        |> Seq.map (fun s -> Int32.Parse(s))

    [<EntryPoint>]
    let main argv =
        let numbers = readNumbers argv.[0]

        for number in numbers do
            printfn "%d" number

        0 // 整数の終了コードを返します
