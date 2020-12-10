namespace FSharpClassLibrary

module WinAPI =
    open System
    open System.Runtime.InteropServices
 
    [<DllImport("user32.dll")>]
    extern int MessageBox(UInt32 hWnd, String lpText, String lpCaption, UInt32 uType)

    [<DllImport("user32.dll")>]
    extern bool MessageBeep(UInt32 beepType)

    let openMessageBox(hWnd : UInt32)(lpText : String)(lpCaption : String)(uType : UInt32): Int32 =
        let messageBoxResult = MessageBox(hWnd, lpText, lpCaption, uType)
        messageBoxResult

    let callBeep(beepType : UInt32) : Boolean =
        let messageBeepResult = MessageBeep(beepType);
        messageBeepResult