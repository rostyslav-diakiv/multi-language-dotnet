using System;
using System.Linq;
using System.Text;
using FSharpClassLibrary;

namespace CSharpConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                @"Please select type of sorting(Write 0 or 1): 
                  0) Quick
                  1) Merge"
            );
            var sortingType = Console.ReadLine();

            bool isMergeSort = false;
            try
            {
                isMergeSort = Convert.ToBoolean(int.Parse(sortingType));
            }
            catch (Exception)
            {
                WinAPI.callBeep((uint)BeepTypes.Error);
                WinAPI.openMessageBox(0u, "Invalid type of sorting", "Error", 0u);
                return;
            }

            Console.WriteLine(
                @"Please input a sequence of integers you want to sort in the next format:
                  2 4 6 8 1 3 6 10"
            );
            var inputItems = Console.ReadLine().Split(' ');

            try
            {
                var arrayItems = inputItems.Select(item => int.Parse(item)).ToList();
                var fsharpList = arrayItems.ToFSharpList();

                var sortedList = isMergeSort ? Sorter.mergeSort(fsharpList) : Sorter.quickSort(fsharpList);
                var sb = new StringBuilder(sortedList.Length);

                foreach (var item in sortedList)
                {
                    sb.Append($"{item} ");
                }

                WinAPI.callBeep((uint)BeepTypes.Ok);
                WinAPI.openMessageBox(0u, sb.ToString(), "Sorted array", 0u);
            }
            catch (Exception)
            {
                WinAPI.callBeep((uint)BeepTypes.Error);
                WinAPI.openMessageBox(0u, "Invalid sequence of integers", "Error", 0u);
            }
        }
    }
}
