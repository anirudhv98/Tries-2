// Time Complexity : O(N * n^k) N = total number of words, n = number of words that start with a given prefix, k is the length of each word
// Space Complexity : O(N*k) N = total number of words, k is the length of each word - to store the words in a Trie
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach

/*
1. Store all words in a Trie, create StartsWith method which returns all words that begin with a particular prefix.
2. Initially loop through the words, add them one by one to temp list and call the helper function. Then backtrack(remove the word from the list) and add the next word and so on. 
This forms the first row of the square.
3. Helper method - Base Condition - if length of temp list = length of any of the word present in list, add it to resultant.
   Find prefix by appending the ith character of all words in temp list where i is the length of list at any point. 
   For each word that starts with the prefix, add it to temp list and recursively call Helper method. Then backtrack by removing the word and adding the next word
4. Return resultant list at the end.   
*/

public class TrieNode
{
    public TrieNode[] next;
    public List<string> words;

    public TrieNode()
    {
        this.next = new TrieNode[26];
        words = new();
    }
}

public class Trie
{
    public TrieNode root;

    public Trie()
    {
        this.root = new();
    }

    public void Insert(string word)
    {
        TrieNode temp = root;
        
        for(int i = 0; i < word.Length; i++)
        {
            int charIndex = word[i] - 'a';
            
            if(temp.next[charIndex]==null)
            {
                temp.next[charIndex] = new TrieNode();
            }
            temp = temp.next[charIndex];
            temp.words.Add(word);
        }
    }

    public List<string> StartsWith(string prefix)
    {
        TrieNode temp = root;
        
        for(int i = 0; i < prefix.Length; i++)
        {
            int charIndex = prefix[i] - 'a';

            if(temp.next[charIndex]==null)
            {
                return new List<string>();
            }

            temp = temp.next[charIndex];
        }

        return temp.words;
    }
}

public class Solution {
    public IList<IList<string>> WordSquares(string[] words) {
        Trie trie = new();
        
        foreach(string word in words)
        {
            trie.Insert(word);
        }

        List<IList<string>> result = new();
        List<string> temp = new();

        for(int i = 0; i < words.Length; i++)
        {
            // Action
            temp.Add(words[i]);

            // Recurse
            Helper(result, words, temp, trie);

            // Backtrack
            temp.RemoveAt(temp.Count - 1);
        }
        
        return result; 
    }

    public void Helper(List<IList<string>> result, string[] words, List<string> temp, Trie trie)
    {
        // Base Condition
        if (temp.Count == words[0].Length)
        {
            result.Add(new List<string>(temp));
            return;
        }

        // Logic

        StringBuilder prefix = new();
        int len = temp.Count;
        
        for(int i = 0; i < len; i++)
        {
            prefix.Append(temp[i][len]);
        }

        List<string> startsWith = trie.StartsWith(prefix.ToString());

        for(int j = 0; j < startsWith.Count; j++)
        {
            // Add
            temp.Add(startsWith[j]);

            // Recurse
            Helper(result, words, temp, trie);

            // Backtrack
            temp.RemoveAt(temp.Count - 1);
        }

    }
}