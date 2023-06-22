using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Millionaire
{
    public class Question
    {
        private string text;
        private List<string> answers;
        private int prize;
        private int correctAnswerIndex;

        public string Text
        {
            get => text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(text));

                text = value;
            }
        }

        public List<string> Answers
        {
            get => answers;
            set { 
                if (value == null)
                    throw new ArgumentNullException(nameof(answers));
                
                answers = value;
            }
        }

        public int Prize
        {
            get => prize;
            set {
                if (value == 0)
                    throw new ArgumentNullException(nameof(prize));
                
                prize = value;
            }
        }

        public int CorrectAnswerIndex 
        {
            get => correctAnswerIndex;
            set
            {
                if (value < 0) 
                    throw new ArgumentOutOfRangeException(nameof(correctAnswerIndex));

                this.correctAnswerIndex = value;
            }
        }

        public Question(string text, List<string> answers, int prize, int correctAnswerIndex)
        {
            Text = text;
            Answers = answers;
            Prize = prize;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
