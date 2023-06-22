using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Millionaire;

class Questions
{
    private List<Question> questionList = new List<Question>();

    public List<Question> QuestionList
    {
        get => questionList;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            questionList = value;
        }
    }
}
