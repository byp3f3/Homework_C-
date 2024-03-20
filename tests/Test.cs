using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }

        public CorrectAnswer RightAnswer {  get; set; }


        public enum CorrectAnswer
        {
            FirstAnswer,
            SecondAnswer,
            ThirdAnswer
        }

    }
}
