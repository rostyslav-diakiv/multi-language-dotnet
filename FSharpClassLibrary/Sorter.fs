namespace FSharpClassLibrary

module Sorter = 
    let quickSort (lst : int list)= 
      let rec QuickSortCont l cont =
        match l with
        | [] -> cont []
        | pivot::rest -> 
          let left, right = rest |> List.partition(fun i -> i < pivot)
          QuickSortCont left (fun accLeft -> 
          QuickSortCont right (fun accRight -> cont(accLeft@pivot::accRight)))
      QuickSortCont lst (fun x -> x)
    
    let splitList divSize lst = 
      let rec splitAcc divSize cont = function
        | [] -> cont([],[])
        | l when divSize = 0 -> cont([], l)
        | h::t -> splitAcc (divSize-1) (fun acc -> cont(h::fst acc, snd acc)) t
      splitAcc divSize (fun x -> x) lst
    
    let merge l r =
      let rec mergeCont cont l r = 
        match l, r with
        | l, [] -> cont l
        | [], r -> cont r
        | hl::tl, hr::tr ->
          if hl<hr then mergeCont (fun acc -> cont(hl::acc)) tl r
          else mergeCont (fun acc -> cont(hr::acc)) l tr
      mergeCont (fun x -> x) l r
    
    let mergeSort (lst : int list) = 
      let rec mergeSortCont lst cont =
        match lst with
        | [] -> cont([])
        | [x] -> cont([x])
        | l -> let left, right = splitList (l.Length/2) l
               mergeSortCont left  (fun accLeft ->
               mergeSortCont right (fun accRight -> cont(merge accLeft accRight)))
      mergeSortCont lst (fun x -> x)