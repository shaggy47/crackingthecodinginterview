using System;

namespace SortingAlgorithms
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Bubble sort.
            Console.WriteLine("Bubble sort");
            int[] arr = new int[] { 5, 4, 3, 2, 1 };
            BubbleSort bubbleSort = new BubbleSort(arr);
            bubbleSort.Sort();
            Console.WriteLine(bubbleSort.ToString());

            //Insertion sort
            Console.WriteLine("Insertion sort");
            InsertionSort insertionSort = new InsertionSort(new int[] { 5, 4, 3, 2, 1 });
            insertionSort.Sort();
            Console.WriteLine(insertionSort.ToString());


            //Selection sort
            Console.WriteLine("Selection sort");
            SelectionSort selectionSort = new SelectionSort(new int[] { 5, 4, 3, 2, 1 });
            selectionSort.Sort();
            Console.WriteLine(selectionSort.ToString());

            // Quicksort
            Console.WriteLine("Quick sort");
            QuickSort quickSort = new QuickSort(new int[] { 5, 4, 3, 2, 1 });
            quickSort.Sort();
            Console.WriteLine(quickSort.ToString());

            // Merge sort
            Console.WriteLine("Merge sort");
            MergeSortImpl mergeSortImpl = new MergeSortImpl(new int[] { 5, 4, 3, 2, 1 });
            mergeSortImpl.Sort();
            Console.WriteLine(mergeSortImpl.ToString());

            // Heap sort
            Console.WriteLine("Heap sort");
            HeapSortImpl heapSortImpl = new HeapSortImpl(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            heapSortImpl.Sort();
            Console.WriteLine(heapSortImpl.ToString());
            Console.Read();
        }
    }
}
