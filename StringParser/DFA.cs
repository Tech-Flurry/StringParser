using DFAParser.ParserModel.Exceptions;
using System;
using System.Collections.Generic;

namespace DFAParser.ParserModel
{
    /// <summary>
    /// Deterministic Finite Automatun class recognize exactly the set of regular languages, which are, among other things, useful for doing lexical analysis and pattern matching.
    /// It is made up of 2 elements, Letter-set and States
    /// Letters from the letter-set goes to some state(s) of the DFA to make a valid word
    /// States will be counted from 0-n
    /// </summary>
    class DFA
    {
        LettersSet letterSet;
        List<State> lstStates = new List<State>();
        /// <summary>
        /// Initializes new instance of the DFA class
        /// </summary>
        /// <param name="letterSet">It is the list of letters which are included in the regular language</param>
        public DFA(LettersSet letterSet)
        {
            this.letterSet = letterSet;
        }
        /// <summary>
        /// Method to add a new state
        /// </summary>
        /// <param name="isFinal">boolean value to set the final or not</param>
        /// <param name="isStart">boolean value to set the start or not</param>
        public void AddState(bool isFinal = false, bool isStart = false)
        {
            State state = new State(letterSet, isFinal, isStart);
            if (lstStates.Count > 0)
            {
                foreach (var item in lstStates)
                {
                    if (item.IsStart && isStart)
                    {
                        throw new NoMoreStartStateException(); //A DFA has not more than one start state
                    }
                }
            }
            lstStates.Add(state);
        }
        /// <summary>
        /// Method to add transition between states according to the language
        /// </summary>
        /// <param name="stateIndex">0-based index of the state from which DFA is reading the letter</param>
        /// <param name="letter">Letter (included in the letter-set of this DFA) which is being read by the DFA on this state</param>
        /// <param name="nextState">0-based index of the state to which DFA is shift after reading the letter</param>
        public void AddTransition(int stateIndex, char letter, int nextState)
        {
            if (stateIndex >= 0 && stateIndex < lstStates.Count)
            {
                lstStates[stateIndex].AddTransition(letter, lstStates[nextState]); //will throw an exception if next state will not be present
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        /// <summary>
        /// Method to verify the words of the language
        /// </summary>
        /// <param name="s">A string to check whether it is a valid word according to the DFA or not</param>
        /// <returns></returns>
        public bool VerifyWord(string s)
        {
            bool flag = false; //flag is the return value of this method, by default it is false
            State state = InitialState; //starting from the initial state
            foreach (var item in s.ToCharArray())
            {
                int i = lstStates.IndexOf(state);
                state = state[item]; //returns the next state according to the transition table
                if (state == null)
                    throw new MissingEdgeException(i+1, item);
            }
            if (state.IsFinal)
            {
                //if the last state is a final state then the method will return true
                flag = true;
            }
            return flag;
        }
        /// <summary>
        /// Starting State of the DFA
        /// </summary>
        public State InitialState
        {
            get
            {
                foreach (var item in lstStates)
                {
                    if (item.IsStart)
                        return item;
                }
                throw new NoInitialStateFoundException();
            }
        }
        /// <summary>
        /// Letter-set defined for this DFA
        /// </summary>
        public LettersSet LetterSet
        {
            get
            {
                return letterSet;
            }
        }
    }
}
