namespace DFAParser.ParserModel
{
    /// <summary>
    /// State of a Deterministic Finite Automata
    /// </summary>
    class State
    {
        bool isStart, isFinal;
        State[] transitionStates;
        LettersSet letterSet;
        /// <summary>
        /// Initialzes new instance for a state
        /// </summary>
        /// <param name="letterSet">Set of letters belongs to the DFA</param>
        /// <param name="isFinal">Set as true for the final state</param>
        /// <param name="isStart">Set as true for the initial/start state</param>
        public State(LettersSet letterSet, bool isFinal = false, bool isStart = false)
        {
            this.isStart = isStart;
            this.isFinal = isFinal;
            this.letterSet = letterSet;
            transitionStates = new State[letterSet.Letters.Length];
        }
        /// <summary>
        /// Method to add transitions to a state
        /// </summary>
        /// <param name="letter">Letter which reads from this state</param>
        /// <param name="nextState">Next State to which this state transit after reading the letter</param>
        public void AddTransition(char letter, State nextState)
        {
            transitionStates[letterSet[letter]] = nextState; //the logic is to get the index of the letter and on the same index store the next state
        }
        /// <summary>
        /// Method to remove a transition at a certain letter
        /// </summary>
        /// <param name="letter">Letter of the transition</param>
        public void RemoveTransitionAt(char letter)
        {
            transitionStates[letterSet[letter]] = null;
        }
        public bool IsStart
        {
            get
            {
                return isStart;
            }
        }
        public bool IsFinal
        {
            get
            {
                return isFinal;
            }
        }
        /// <summary>
        /// This will return a new state to which this state transit after reading a letter 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>this indexer will return the next state on the given letter</returns>
        public State this[char letter]
        {
            get
            {
                return transitionStates[letterSet[letter]];
            }
        }
    }
}
