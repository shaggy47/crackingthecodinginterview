using System;
namespace SortingAlgorithms
{
    public class InsertionSort : BaseSort
    {
        public InsertionSort(int[] arr) : base(arr)
        {
        }

		public override void Sort()
		{
			for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j+1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
		}
	}
}
