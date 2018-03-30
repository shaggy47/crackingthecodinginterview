using System;
namespace SortingAlgorithms
{
    public abstract class BaseSort
    {
        protected int[] array;

        public BaseSort(int[] arr)
        {
            this.array = arr;
        }

        public abstract void Sort();

        public override string ToString()
        {
            string representation = string.Empty;
            representation = "{";
            foreach (var a in array)
            {
                representation += a + ", ";
            }
            representation += "]";

            return representation;
        }

        protected void Swap(int i, int j)
        {
            int t = this.array[i];
            array[i] = array[j];
            array[j] = t;
        }
	}
}
