﻿let rec swap a b =
  if a > b then (b, a) else (a, b)
// проходит по массиву с начала и сортирует его пузырьком
let rec bubbleSort arr =
  match arr with
  | [] | [_] -> arr // eсли массив пустой или состоит из одного элемента, то он уже отсортирован
  | x :: y :: rest -> // eсли массив состоит из двух или более элементов, то
    let (x', y') = swap x y // cравниваем и меняем местами первые два элемента
    x' :: bubbleSort (y' :: rest) // cоединяем первый элемент с отсортированной оставшейся частью
// повторяет процесс сортировки пузырьком до тех пор, пока массив не будет полностью отсортирован
let rec BubbleSortFunc arr =
  let sortedArr = bubbleSort arr // cортируем массив с начала
  if sortedArr = arr then arr // eсли массив не изменился, то он уже полностью отсортирован
  else BubbleSortFunc sortedArr // иначе повторяем процесс с новым массивом

let rec InsertionSortFunc (arr: int list) =
  let rec insert (x: int) (sorted: int list) = // функция для вставки элемента в отсортированный список
    match sorted with
    | [] -> [x] // если список пустой, то возвращаем список из одного элемента
    | y :: rest -> // если список не пустой, то сравниваем элементы
      if x < y then // если вставляемый элемент меньше первого, то ставим его в начало
        x :: sorted // возвращаем новый список
      else // иначе оставляем первый элемент на своем месте
        y :: insert x rest // рекурсивно вставляем элемент в оставшийся список
  match arr with
  | [] -> [] // пустой список уже отсортирован
  | x :: rest -> // список из одного или более элементов
    insert x (InsertionSortFunc rest) // рекурсивно сортируем оставшийся список и вставляем первый элемент

let rec SelectionSortFunc (arr: int list) =
  let rec findMinAndRemove (lst: int list) = // функция для поиска минимального элемента и его удаления из списка
    match lst with
    | [] -> failwith "Empty list" // если список пустой, то выбрасываем исключение
    | [x] -> (x, []) // если список из одного элемента, то он сам является минимальным, а остаток пустой
    | x :: rest -> // если список из двух или более элементов, то сравниваем первый с минимальным из остальных
      let (min, rem) = findMinAndRemove rest // рекурсивно находим минимальный элемент и остаток списка
      if x < min then // если первый элемент меньше минимального, то он сам является минимальным
        (x, rest) // возвращаем его и остаток списка без него
      else // иначе минимальный элемент находится в остатке списка
        (min, x :: rem) // возвращаем его и остаток списка с добавлением первого элемента
  match arr with
  | [] -> [] // пустой список уже отсортирован
  | _ -> // список из одного или более элементов
    let (min, rem) = findMinAndRemove arr // находим минимальный элемент и остаток списка
    min :: SelectionSortFunc rem // рекурсивно сортируем остаток списка и добавляем минимальный элемент в начало


let list = [ -5; 16; 87; 0; -33; 25; -11 ]

let sortedByBubble = BubbleSortFunc list
printfn "пузырьковая сортировка | функциональный стиль: %A" sortedByBubble

let sortedByInsertion = InsertionSortFunc list
printfn "сортировка вставками | функциональный стиль: %A" sortedByInsertion

let sortedBySelection = SelectionSortFunc list
printfn "сортировка выбором | функциональный стиль: %A" sortedBySelection