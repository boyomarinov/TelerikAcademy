﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TrieWordFinder
{
    /// <summary>
    /// Trie factory to create Trie instances.
    /// </summary>
    public static class TrieFactory
    {
        /// <summary>
        /// Get a new Trie instance.
        /// </summary>
        public static Trie GetTrie()
        {
            return new Trie(
                GetTrieNode(' ')
                );
        }

        /// <summary>
        /// Get a new TrieNode instance.
        /// </summary>
        /// <param name="character">Character of the TrieNode.</param>
        internal static TrieNode GetTrieNode(char character)
        {
            return new TrieNode(character,
                new Dictionary<char, TrieNode>(),
                false,
                0)
                ;
        }
    }
}
