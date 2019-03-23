using System.Collections.Generic;

namespace DFAParser.ParserModel
{
    /// <summary>
    /// This class is used to generate tokens by parsing a string by using DFA
    /// </summary>
    class TokenParser
    {
        protected LettersSet letterSet;
        protected DFA dfa;
        /// <summary>
        /// Initializes new instance of Token Parser. Mainly used when this class is inherited to some other and the new class uses all letters into their regular language
        /// </summary>
        protected TokenParser()
        {
            letterSet = new LettersSet();
            letterSet.AddLetters(0, 127); //add all ascii characters to the letter set
            dfa = new DFA(letterSet); //add the letter set to the DFA
        }
        /// <summary>
        /// Initializes new instance of Token Parser.
        /// </summary>
        /// <param name="dfa">DFA according to which this parser will parse the string</param>
        public TokenParser(DFA dfa)
        {
            letterSet = dfa.LetterSet;
            this.dfa = dfa;
        }
        /// <summary>
        /// Method to verify a word according to the class DFA
        /// </summary>
        /// <param name="word">A Word to be accepted by the Parser</param>
        /// <returns>True if the word is accepted, otherwise false</returns>
        public bool VerifyWord(string word)
        {
            return dfa.VerifyWord(word);
        }
        /// <summary>
        /// Method to parse the string and generate the tokens according to the provided DFA
        /// </summary>
        /// <param name="s">Any string</param>
        /// <returns>List of Tokens parsed by the parser from the given string</returns>
        public List<string> GenerateTokens(string s)
        {
            List<string> lstTokens = new List<string>();
            //removes the white space
            s = s.Replace(" ", string.Empty);
            char[] charATemp = s.ToCharArray(); //taking a temporary char array to store the converted string to char array
            //index is a variable which will store the position to read from the char array
            for (int index = 0; index < charATemp.Length; index++)
            {
                string sTemp = string.Empty; //taking a temporary string to make and verify words
                string lastValidWord = null;
                for (int i = index; i < charATemp.Length; i++) //this loop will iterate from a specified position to the end of the temp array
                {
                    sTemp += charATemp[i]; //adding each char to the string to make a whole word and then verify it
                    if (VerifyWord(sTemp))
                    {
                        //the word is verified then store it as the last valid and procceed to check further
                        //whether it could be some other valid word
                        //every single valid word in this proccess will overwrite the last valid word
                        lastValidWord = sTemp;
                        index = i; //set the new position to iterate at the end of the verified word
                    }
                }
                if (lastValidWord != null)
                {
                    lstTokens.Add(lastValidWord); //eventually the last valid word will be added to tokens list
                }
            }
            return lstTokens;
        }
    }
}
