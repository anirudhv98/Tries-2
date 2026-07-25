// Time Complexity : O(nlogn)
// Space Complexity : O(2n) = O(n) - space for frequency map and min heap
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

/*
1. Create a frequency map for each element present in nums.
2. Add all distinct elements into maxHeap - priority of the maxHeap is based on the frequency of element
3. Remove k top-most elements in heap and return it in the form of an integer array
*/

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequencyMap = new();
        int[] result = new int[k];
        
        for(int i = 0; i < nums.Length; i++)
        {
            frequencyMap[nums[i]] = frequencyMap.GetValueOrDefault(nums[i], 0) + 1;
        }

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a,b) => 
            {
                return frequencyMap[b].CompareTo(frequencyMap[a]);
            })
        );

        foreach(int numbers in frequencyMap.Keys)
        {
            maxHeap.Enqueue(numbers, numbers);
        }

        for(int j = 0; j < k; j++)
        {
            result[j] = maxHeap.Dequeue();
        }

        return result;
    }
}