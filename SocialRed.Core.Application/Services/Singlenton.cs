using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialRed.Core.Application.Services
{
    public class Singlenton
    {
        private static Singlenton instance;
        private int value;

        private Singlenton() { }

        public static Singlenton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singlenton();
                }
                return instance;
            }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
