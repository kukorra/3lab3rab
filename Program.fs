open System
open System.IO

// Функция для поиска первого по алфавиту файла в указанной директории
let findFirstFileAlphabetically directory =
    try
        directory
        |> Directory.EnumerateFiles // Получаем последовательность файлов
        |> Seq.map Path.GetFileName // Извлекаем только имена файлов
        |> Seq.sort // Сортируем по алфавиту
        |> Seq.tryHead // Берём первый элемент (если есть)
    with
    | :? DirectoryNotFoundException -> 
        printfn "Ошибка: Каталог не найден."
        None
    | ex -> 
        printfn "Ошибка: %s" ex.Message
        None

// Основная программа
printf "Введите путь к каталогу: "
let directory = Console.ReadLine()

match findFirstFileAlphabetically directory with
| Some file -> printfn "Первый по алфавиту файл: %s" file
| None -> printfn "Файлы не найдены или произошла ошибка."