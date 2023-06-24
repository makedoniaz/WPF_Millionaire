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
            get => this.text;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(this.text));

                this.text = value;
            }
        }

        public List<string> Answers
        {
            get => this.answers;
            set { 
                if (value == null)
                    throw new ArgumentNullException(nameof(this.answers));

                this.answers = value;
            }
        }

        public int Prize
        {
            get => this.prize;
            set {
                if (value == 0)
                    throw new ArgumentNullException(nameof(this.prize));

                this.prize = value;
            }
        }

        public int CorrectAnswerIndex 
        {
            get => correctAnswerIndex;
            set
            {
                if (value < 0) 
                    throw new ArgumentOutOfRangeException(nameof(this.correctAnswerIndex));

                this.correctAnswerIndex = value;
            }
        }

        public Question(string text, List<string> answers, int prize, int correctAnswerIndex)
        {
            this.Text = text;
            this.Answers = answers;
            this.Prize = prize;
            this.CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
