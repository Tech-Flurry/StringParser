using DFAParser.ParserModel.Exceptions;
using System;
using System.Collections.Generic;

namespace DFAParser.ParserModel
{
    /// <summary>
    /// Set of letters for the regular language used in a DFA
    /// </summary>
    public class LettersSet
    {
        //Declared a list of letters where all the letters will be stored
        private List<char> letters;
        public LettersSet()
        {
            //initialzed the list of letters
            letters = new List<char>();
        }
        /// <summary>
        /// This method is to add a single letter to the list
        /// </summary>
        /// <param name="letter">Letter to be added into the set</param>
        public void AddLetter(char letter)
        {
            foreach (var item in letters)
            {
                //check whether if the letter to be added is already present in the list, if so, then throw an exception
                if (item == letter)
                    throw new LetterAlreadyAddedException(letter);
            }
            //if the letter is unique for the list then add it
            letters.Add(letter);
        }
        /// <summary>
        /// This method is to add a set of letters to the list
        /// </summary>
        /// <param name="letters">Letters to be added into the set</param>
        public void AddLetters(char[] letters)
        {
            List<char> exLetters = new List<char>(); //initialzed a list to store the already present letters in the list
            bool flag = true;
            for (int i = 0; i < letters.Length; i++)
            {
                foreach (var item in this.letters)
                {
                    //check presence of each letter into the list
                    if (item == letters[i])
                    {
                        flag = false; //turn the flag to false if the letter is already present into the list
                        exLetters.Add(item); //add that letter to the list of already present letters
                        break; //breaks the foreach loop
                    }
                }
                if (flag) //if the letter is not present then add it to the list
                    this.letters.Add(letters[i]);
                else //otherwise set the flag again to true to check existance of a new letter
                    flag = true;

            }
            if (exLetters.Count > 0) //if something is present into the list then throws an exception
                throw new LettersAlreadyAddedException(exLetters);
        }
        /// <summary>
        /// Method to add a range of letters by entering the ASCII
        /// </summary>
        /// <param name="fromDec">Range from Decimal ASCII</param>
        /// <param name="toDec">Range to Decimal ASCII</param>
        public void AddLetters(int fromDec, int toDec)
        {
            List<char> letters = new List<char>();
            for (int i = fromDec; i <= toDec; i++)
            {
                letters.Add(Convert.ToChar(i));
            }
            List<char> exLetters = new List<char>(); //initialzed a list to store the already present letters in the list
            bool flag = true;
            for (int i = 0; i < letters.Count; i++)
            {
                foreach (var item in this.letters)
                {
                    //check presence of each letter into the list
                    if (item == letters[i])
                    {
                        flag = false; //turn the flag to false if the letter is already present into the list
                        exLetters.Add(item); //add that letter to the list of already present letters
                        break; //breaks the foreach loop
                    }
                }
                if (flag) //if the letter is not present then add it to the list
                    this.letters.Add(letters[i]);
                else //otherwise set the flag again to true to check existance of a new letter
                    flag = true;

            }
            if (exLetters.Count > 0) //if something is present into the list then throws an exception
                throw new LettersAlreadyAddedException(exLetters);
        }
        /// <summary>
        /// Method to add a range of letters by entering the character bounds itself
        /// </summary>
        /// <param name="from">Range from Letter</param>
        /// <param name="to">Range to Letter</param>
        public void AddLetters(char from, char to)
        {
            List<char> letters = new List<char>();
            for (int i = from; i <= to; i++)
            {
                letters.Add(Convert.ToChar(i));
            }
            List<char> exLetters = new List<char>(); //initialzed a list to store the already present letters in the list
            bool flag = true;
            for (int i = 0; i < letters.Count; i++)
            {
                foreach (var item in this.letters)
                {
                    //check presence of each letter into the list
                    if (item == letters[i])
                    {
                        flag = false; //turn the flag to false if the letter is already present into the list
                        exLetters.Add(item); //add that letter to the list of already present letters
                        break; //breaks the foreach loop
                    }
                }
                if (flag) //if the letter is not present then add it to the list
                    this.letters.Add(letters[i]);
                else //otherwise set the flag again to true to check existance of a new letter
                    flag = true;

            }
            if (exLetters.Count > 0) //if something is present into the list then throws an exception
                throw new LettersAlreadyAddedException(exLetters);
        }
        /// <summary>
        /// Gives position of the letter in the set
        /// </summary>
        /// <param name="letter">Letter to get its position</param>
        /// <returns>Index of the letter</returns>
        public int this[char letter]
        {
            get
            {
                int i = letters.IndexOf(letter);
                if (i >= 0)
                    return i;
                else
                    throw new NoSuchLetterFoundException(letter);
            }
        }
        /// <summary>
        /// Gives the Letter on a perticular position in the set
        /// </summary>
        /// <param name="i">Index to get letter</param>
        /// <returns>Letter on the given position in the letter-set</returns>
        public char this[int i]
        {
            get
            {
                if (i >= 0 && i<letters.Count)
                    return letters[i];
                else
                    throw new IndexOutOfRangeException();
            }
        }
        /// <summary>
        /// Method to get letters other than the letters present into the given list
        /// </summary>
        /// <param name="letters">Letters whose other would have been found</param>
        /// <returns>Set of Other Letters</returns>
        public char[] OtherLetters(char[] letters)
        {
            List<char> lstTemp = new List<char>();
            List<char> temp = new List<char>();
            foreach (var item in this.letters)
            {
                //copying the list of letters to the temp list
                lstTemp.Add(item);
            }
            for (int i = 0; i < lstTemp.Count; i++)
            {
                foreach (var item in letters)
                {
                    if (item == lstTemp[i])
                    {
                        lstTemp.RemoveAt(i); //if a char from the selected matches with a char in temp list then remove it
                        i--; //get a step back because an item is removed from the array
                    }
                }
            }
            return lstTemp.ToArray();
        }
        /// <summary>
        /// Method to remove a letter from the set
        /// </summary>
        /// <param name="letter">Letter to be removed</param>
        public void RemoveLetter(char letter)
        {
            bool flag = true;
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i] == letter)
                {
                    flag = false;
                    letters.RemoveAt(i); //if the letter is present in the list then remove the occurance of the letter
                    break; //breaks the loop after removing
                }
            }
            if (flag) //but if no letter is deleted then the method throws an exception
                throw new NoSuchLetterFoundException(letter);
        }
        /// <summary>
        /// To check whether if the letter is present in the set or not
        /// </summary>
        /// <param name="letter">Letter to be checked</param>
        /// <returns>true if present, false if not</returns>
        public bool IsLetter(char letter)
        {
            foreach (var item in letters)
            {
                if (item == letter)
                {
                    return true; //if the letter is present in the set then return true
                }
            }
            return false; //otherwise false
        }
        /// <summary>
        /// Set of Letters
        /// </summary>
        public char[] Letters
        {
            get
            {
                return letters.ToArray();
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in letters)
            {
                s += item;
            }
            return s;
        }
        /// <summary>
        /// This Method is used to get the letters in their respective ASCII numbers
        /// </summary>
        /// <returns>Set of ASCII numbers</returns>
        public short[] ToASCIIArray()
        {
            short[] asciiArray = new short[letters.Count];
            for (int i = 0; i < letters.Count; i++)
            {
                asciiArray[i] = Convert.ToInt16(letters[i]);
            }
            return asciiArray;
        }
    }
}
