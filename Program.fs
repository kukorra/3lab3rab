open System
open System.IO

let findfilepoalph directory =
    try
        directory
        |> Directory.EnumerateFiles
        |> Seq.map Path.GetFileName 
        |> Seq.sort 
        |> Seq.tryHead 
    with
    | :? DirectoryNotFoundException -> 
        printfn "Ошибка: Каталог не найден."
        None
    | ex -> 
        printfn "Ошибка: %s" ex.Message
        None

printf "Введите путь к каталогу: "
let directory = Console.ReadLine()

match findfilepoalph directory with
| Some file -> printfn "Первый по алфавиту файл: %s" file
| None -> printfn "Файлы не найдены или произошла ошибка."
