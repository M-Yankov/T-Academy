namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Sorry I can do it only with indexes. So just lose more memory :(. Missing videos from this lectures.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            // Emi taka shte e ...
            IList<T> result = this.MergeSort(collection);

            if (result.Count != collection.Count)
            {
                throw new InvalidProgramException();
            }

            for (int i = 0; i < result.Count; i++)
            {
                collection[i] = result[i];   
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middleIndex = collection.Count / 2;
            IList<T> leftList = new List<T>(middleIndex);
            IList<T> rightList = new List<T>(middleIndex + 1);

            for (int i = 0; i < middleIndex; i++)
            {
                leftList.Add(collection[i]);
            }

            for (int i = middleIndex; i < collection.Count; i++)
            {
                rightList.Add(collection[i]);
            }

            leftList = this.MergeSort(leftList);
            rightList = this.MergeSort(rightList);

            collection = this.Merge(leftList, rightList);
            return collection;
        }

        private IList<T> Merge(IList<T> leftList, IList<T> rightList)
        {
            int countOfNewList = leftList.Count + rightList.Count;

            bool hasLeftDone = false;
            bool hasRightDone = false;

            var result = new List<T>(countOfNewList);

            for (int i = 0, j = 0; true;)
            {
                if (hasLeftDone && hasRightDone)
                {
                    break;
                }
                else if (hasRightDone)
                {
                    result.Add(leftList[i]);
                    i++;
                }
                else if (hasLeftDone)
                {
                    result.Add(rightList[j]);
                    j++;
                }
                else
                {
                    if (leftList[i].CompareTo(rightList[j]) < 0)
                    {
                        result.Add(leftList[i]);
                        i++;
                    }
                    else
                    {
                        result.Add(rightList[j]);
                        j++;
                    }
                }

                if (i >= leftList.Count && !hasLeftDone)
                {
                    hasLeftDone = true;
                }

                if (j >= rightList.Count && !hasRightDone)
                {
                    hasRightDone = true;
                }
            }

            return result;
        }
    }
}
