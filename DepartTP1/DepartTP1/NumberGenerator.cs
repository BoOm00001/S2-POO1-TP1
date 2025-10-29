using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTP1
{
	/* Code fait par François Gagnon et adapté par Karine Filiatreault */
    public class NumberGenerator
    {
        private int nextValue;
        private bool isSequential;
        private bool isConstant;

        public bool IsConstant
        {
            get { return isConstant; }
            set { isConstant = value; }
        }


        public bool IsSequential
        {
            get { return isSequential; }
            set { isSequential = value; }
        }


        public int NextValue
        {
            get { return nextValue; }
            set { nextValue = value; }
        }

                private Random random;

		/**
		 * Instantiate a sequential number generator that will start a 1 and increment by one each time.
		 */
		public NumberGenerator()
		{
			//sequential  mode
			this.IsSequential = true;
			this.NextValue = 1;
			this.IsConstant = false;
		}

		/**
		 * Instantiate a constant number generator that will always provide the same value (the one given as parameter).
		 */

		/**
		 * Instantiate a constant number generator that will always provide the same value (the one given as parameter).
		 * @param val the value to generate constantly. must be >0 and <1000 (otherwise an exception is thrown)
		 *
		 */
		public NumberGenerator(int val)
		{	
			//constant mode
			if (val <= 0 || val >= 1000)
			{
				throw new InvalidOperationException("The constant Number Generator cannot be initialized with a value of 0 (or less) nor a value of 1000 (or more).");
			}
			this.IsConstant = true;
			this.NextValue = val;
			this.IsSequential = false;
		}

		/**
		 * Instantiate a constant number generator that will provide pseudo-random numbers.
		 * @param seed a long value used as the seed for the pseudo random generation sequence. The same seed will always generate the same sequence.
		 */
		public NumberGenerator(long seed)
		{
			this.random = new Random((int)seed);
			this.NextValue = 1;
			this.IsSequential = false;
			this.isConstant = false;
		}

		/**
		 * Obtain the next number from this generator. Will throw an exception if the only number that can be generated is <= 0 or >= 1000  
		 * @return the next number
		 */
		public int Next()
		{
			if (isSequential)
			{
				int val = this.NextValue;
				if (val >= 1000)
				{
					throw new InvalidOperationException("The sequential Number Generator reached the limit.");
				}
				this.NextValue++;
				return val;
			}
			else if (this.isConstant)
			{
				return this.NextValue;
			}
			else
			{
				return this.random.Next(1, 1000); // max 999
			}
		}

	}
}
