Imports Microsoft.FSharp.Collections
Imports System.Runtime.CompilerServices

Public Module Intertop

    <Extension()>
    Public Function ToFSharpList(Of T)(input As List(Of T)) As FSharpList(Of T)
        Return CreateFSharpList(input, 0)
    End Function

    Private Function CreateFSharpList(Of T)(input As List(Of T), index As Integer) As FSharpList(Of T)
        If index >= input.Count Then
            Return FSharpList(Of T).Empty
        End If

        Return FSharpList(Of T).Cons(input(index), CreateFSharpList(input, index + 1))
    End Function

End Module
