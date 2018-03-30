using System;
namespace SortingAlgorithms
{
    public class HeapSortImpl : BaseSort
    {
        public HeapSortImpl(int[] arr) : base(arr)
        {
        }

        Func<int, int> Left = (i) => { return (2 * i) + 1; };

        Func<int, int> Right = (i) => { return (2 * i) + 2; };

        private void Heapify(int n, int i)
        {
            int largest = i;
            int left = Left(i);
            int right = Right(i);

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;
            
            if (largest != i)
            {
                Swap(largest, i);

                Heapify(n,largest);
            }
                
        }

		public override void Sort()
		{
            // Build heap
            for (int i = (array.Length / 2)-1; i >=0; i--)
            {
                Heapify(array.Length, i);
            }

            for (int i = array.Length-1; i>=0; i--)
            {
                Swap(0, i);
                Heapify(i, 0);
            }
        }
	}
}
