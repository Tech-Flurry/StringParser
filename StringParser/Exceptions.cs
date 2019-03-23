using System;
using System.Collections.Generic;

namespace DFAParser.ParserModel.Exceptions
{
    /// <summary>
    /// The Letter which a user wants to add is already present in the set
    /// </summary>
    public class LetterAlreadyAddedException : Exception
    {
        public LetterAlreadyAddedException(char letter) : base(letter + " is already present in the list. The DFA couldn't contain duplicate letters.")
        {

        }

    }
    /// <summary>
    /// More than one Letter which a user wants to add is already present in the set
    /// </summary>
    public class LettersAlreadyAddedException : Exception
    {
        string message = "";
        public LettersAlreadyAddedException(List<char> letters)
        {
            foreach (var item in letters)
            {
                message = message + item + " ";
            }
            message += "is/are already present in the list. The DFA couldn't contain duplicate letters.";
        }
        public override string Message
        {
            get
            {
                return message;
            }
        }
    }
    /// <summary>
    /// No such letter is found in the set
    /// </summary>
    public class NoSuchLetterFoundException : Exception
    {
        public NoSuchLetterFoundException(char letter) : base("No such letter found. " + letter + " is not present in the set of defined letters.")
        {

        }
    }
    /// <summary>
    /// This exception is thowrn if the user is trying to add more than one start state
    /// </summary>
    public class NoMoreStartStateException : Exception
    {
        public NoMoreStartStateException() : base("A DFA cannot have more than one start state.")
        {

        }
    }
    /// <summary>
    /// This exception is thrown if there is no initial state in a DFA
    /// </summary>
    public class NoInitialStateFoundException : Exception
    {
        public NoInitialStateFoundException() : base("A DFA must have an Initial State.")
        {

        }
    }
    /// <summary>
    /// This Exception is thrown if there is a missing edge of letter from a perticular state
    /// </summary>
    public class MissingEdgeException : Exception
    {
        public MissingEdgeException(int stateIndex, char letter) : base("There is a missing edge on " + stateIndex + " state for " + letter + ". A DFA cannot have a missing edge.")
        {

        }
    }
}
