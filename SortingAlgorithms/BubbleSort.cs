using System;
namespace SortingAlgorithms
{
    public class BubbleSort : BaseSort
    {
        public BubbleSort(int[] arr) :base(arr)
        {
            this.array = arr;
        }

        public override void Sort()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        Swap(i, j);
                    }
                }
            }
        }
	}
}
