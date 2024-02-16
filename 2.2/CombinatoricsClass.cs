using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal static class EnumerableExtension
    {

         public static IEnumerable<IEnumerable<int>> GetCombinations(this IEnumerable<int> enumList, int k, EqulityComparerRealizate comparer)
        {
            int n = enumList.Count();
            if (k>n || k<0) throw new ArgumentException($"Incorrect argument: {nameof(k)}");
            if (enumList is null) throw new ArgumentNullException();
            if (comparer.Equals(enumList, enumList)) throw new ArgumentException("Items cant be equal inside array");
            List<List<int>> list = new List<List<int>>();
            if (k == 0)
            {
                list.Add(new List<int>());
                return list;
            }
            if (k == 1)
            {
                foreach (int num in enumList) { list.Add(new List<int>() { num }); }
                return list;
            }

           
            int[] indexes = new int[k];
            for (int i = 0; i < k; i++) indexes[i] = 0;


            while (indexes[0]<n)
            {
                for (int i = k-1; i>0; i--)
                {
                    if (indexes[i] == n)
                    {
                        indexes[i-1]++; 
                        indexes[i] = indexes[i-1];
                       
                    }
                    if (i < k - 1 && indexes[i + 1] == n) indexes[i + 1] = indexes[i];
                }
                if (indexes[0] == n) break;


                List<int> listUnder = new List<int>();
                for (int i = 0; i < k; i++) { listUnder.Add(enumList.ElementAt(indexes[i])); }
                list.Add(listUnder);


                indexes[k - 1]++;
            }

            return list.AsEnumerable(); 
        }
        
        

        public static IEnumerable<IEnumerable<int>> GetCombinationsNoRepetitions(this IEnumerable<int> enumList, int k, EqulityComparerRealizate comparer)
        {
            int n = enumList.Count();
            if (k > n || k < 0) throw new ArgumentException($"Incorrect argument: {nameof(k)}");
            if (enumList is null) throw new ArgumentNullException();
            if (comparer.Equals(enumList, enumList)) throw new ArgumentException("Items cant be equality inside array");
            List<List<int>> list = new List<List<int>>();
            if (k == 0)
            {
                list.Add(new List<int>());
                return list;
            }
            if (k == 1)
            { 
                foreach(int num in enumList) { list.Add(new List<int>() { num }); }
                return list;
            }

            

            int[] indexes = new int[k];
            for (int i = 0; i < k; i++) indexes[i] = i;

            while (indexes[0] < n)
            {
                for (int i = k - 1; i > 0; i--)
                {
                    if (indexes[i] >= n)
                    {
                        indexes[i - 1]++;
                        indexes[i] = indexes[i - 1]+1;
                    }
                    if (i < k - 1 && indexes[i + 1] >= n) indexes[i + 1] = indexes[i]+1;
                }
                if (indexes[k - 1] >= n) continue;
                if (indexes[0] >= n) break;


                List<int> listUnder = new List<int>();
                for (int i = 0; i < k; i++) {
                    listUnder.Add(enumList.ElementAt(indexes[i]));
                }
                list.Add(listUnder);

                indexes[k - 1]++;
            }

            return list.AsEnumerable();
        }
        
        public static IEnumerable<IEnumerable<int>> GetSubsets(this IEnumerable<int> enumList, EqulityComparerRealizate comparer)
        {
            if (comparer.Equals(enumList, enumList)) throw new ArgumentException("Items cant be equality inside array");
            if (enumList is null) throw new ArgumentNullException();
            List<List<int>> list = new List<List<int>>();

            for(int i=0; i < n+1; i++)
            {
                foreach (IEnumerable<int> arr in enumList.GetCombinationsNoRepetitions(i, comparer)) list.Add(arr.ToList());
            }

            return list.AsEnumerable();
        }

        public static IEnumerable<IEnumerable<int>> GetRearrangements(this IEnumerable<int> enumList, EqulityComparerRealizate comparer)
        {
            if (enumList is null) throw new ArgumentNullException();
            if (comparer.Equals(enumList, enumList)) throw new ArgumentException("Items cant be equality inside array");
            List<List<int>> list = new List<List<int>>();
            GetRearrangements_Search(enumList.ToArray(), 0, enumList.Count() - 1, list);
            return list.AsEnumerable();
        }

        private static List<List<int>> GetRearrangements_Search(int[] nums, int start, int end, List<List<int>> list)
        {
            if (start == end)
            {
                List<int> newlist = new List<int>();
                foreach (int n in nums) newlist.Add(n);
                list.Add(newlist);
            }
            else
            {
                for (var i = start; i <= end; i++)
                {
                    int buf = nums[start];
                    nums[start] = nums[i];
                    nums[i]= buf;

                    GetRearrangements_Search(nums, start + 1, end, list);

                    buf = nums[start];
                    nums[start] = nums[i];
                    nums[i] = buf;
                }
            }

            return list;
        }


    }







}
