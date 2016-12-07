using System;

namespace XamdroidCustomComponents.CustomComponents
{
    public class LengthPickerArgs : EventArgs
    {
        private int _numberInInches;

        public LengthPickerArgs(int numberInInches)
        {
            _numberInInches = numberInInches;
        }

        // This is a straightforward implementation for 
        // declaring a public field
        public int NumberInInches => _numberInInches;
    }
}