// Time Complexity : O(N * (m+n)) where N is the total number of queries and n is the average length of each word and m is the length of the pattern string
// Space Complexity : O(1)
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

/*
1. Traverse through each query in queries, maintain flag = true, i and j pointer at 0th index of query and pattern respectively.
2. While i is less than length of query, if query[i] and pattern[j] are identical, increment both i and j. Else if query[i] is a lower case character just increment i, else set flag to false and exit out of the loop.
3. If j is less than length of pattern set flag to false else check all characters from ith index to the end of the query string to see if any upper case characters are present. If yes set flag to false.
4. Add flag value to result and perform the check for all query in queries
*/

public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        List<bool> result = new();

        foreach(string query in queries)
        {
            bool flag = true;
            int i = 0, j = 0;   

            while(i<query.Length)
            {
                if(j<pattern.Length && query[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                else if(char.IsLower(query[i]))
                {
                    i++;
                }

                else
                {
                    flag = false;
                    break;
                }
            }

            if(j<pattern.Length)
            {
                flag = false;
            }

            while(i<query.Length)
            {
                if(char.IsUpper(query[i]))
                {
                    flag = false;
                    break;
                }
                i++;
            }

            result.Add(flag);
        }
                

        return result;
    }
}