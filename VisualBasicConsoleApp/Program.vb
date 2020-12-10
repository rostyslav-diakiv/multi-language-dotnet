Imports System.Text
Imports FSharpClassLibrary

Module Program
    Sub Main(args As String())
        Console.WriteLine(
                "Please select type of sorting(Write 0 or 1): 
                  0) Quick
                  1) Merge"
            )

        Dim sortingType = Console.ReadLine()

        Dim isMergeSort = False

        Try
            isMergeSort = Convert.ToBoolean(Integer.Parse(sortingType))
            Exit Try
        Catch exception As Exception
            WinAPI.callBeep(BeepTypes.Error)
            WinAPI.openMessageBox(0, "Invalid type of sorting", "Error", 0)
            Return
        End Try

        Console.WriteLine(
                "Please input a sequence of integers you want to sort in the next format:
                  2 4 6 8 1 3 6 10"
            )
        Dim inputItems = Console.ReadLine().Split(" ").ToList()

        Try
            Dim arrayItems = inputItems.Select(Function(w) Integer.Parse(w)).ToList()
            Dim fsharpList = arrayItems.ToFSharpList()

            Dim SortedList = If(isMergeSort, Sorter.mergeSort(fsharpList), Sorter.quickSort(fsharpList))
            Dim sb = New StringBuilder(SortedList.Length)

            For Each item As String In SortedList
                sb.Append($"{item} ")
            Next

            WinAPI.callBeep(BeepTypes.Ok)
            WinAPI.openMessageBox(0, sb.ToString(), "Sorted array", 0)
        Catch ex As Exception
            WinAPI.callBeep(BeepTypes.Error)
            WinAPI.openMessageBox(0, "Invalid sequence of integers", "Error", 0)
        End Try
    End Sub
End Module
