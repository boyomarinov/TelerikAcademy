using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Forum.Model
{
    public class Vote
    {
        private int _value;
        public int VoteId { get; set; }

        public int Value
        {
            get { return this._value; }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("Vote must be between 0 and 5 inclusive!");
                }

                this._value = value;
            }
        }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
