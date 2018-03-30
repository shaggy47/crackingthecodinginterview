using System;
namespace SortingAlgorithms
{
    public class SelectionSort : BaseSort
    {
        public SelectionSort(int[] arr) : base(arr)
        {
        }

		public override void Sort()
		{
            int j;
			for (int i = 0; i < array.Length; i++)
            {
                int min = i;

                for (j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                Swap(i, min);
            }
		}
	}
}
