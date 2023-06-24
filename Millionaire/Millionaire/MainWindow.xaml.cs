using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace Millionaire;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Questions? questions;
    private readonly string dataPath = "../../../data/questions.json";

    private const int amountOfQuestions = 15;

    private string questionText;
    private string firstAnswer;
    private string secondAnswer;
    private string thirdAnswer;
    private string fourthAnswer;

    private int currentQuestionIndex = 0;
    private int correctAnswerIndex;

    public string QuestionText 
    {
        get => questionText;
        set => this.PropertyChangeMethod(out questionText, value);
    }

    public string FirstAnswer
    {
        get => firstAnswer;
        set => this.PropertyChangeMethod(out firstAnswer, value);
    }

    public string SecondAnswer
    {
        get => secondAnswer;
        set => this.PropertyChangeMethod(out secondAnswer, value);
    }

    public string ThirdAnswer
    {
        get => thirdAnswer;
        set => this.PropertyChangeMethod(out thirdAnswer, value);
    }

    public string FourthAnswer
    {
        get => fourthAnswer;
        set => this.PropertyChangeMethod(out fourthAnswer, value);
    }

    private void PropertyChangeMethod<T>(out T field, T value, [CallerMemberName] string propName = "")
    {
        field = value;

        if (this.PropertyChanged != null)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public int CurrentQuestionIndex
    {
        get => currentQuestionIndex;
        set {
            if (value > amountOfQuestions)
                Environment.Exit(0);

            this.currentQuestionIndex = value;
        }
    }

    public void SetUpCurrentQuestion()
    {
        QuestionText = this.questions.QuestionList[currentQuestionIndex].Text;
        FirstAnswer = this.questions.QuestionList[currentQuestionIndex].Answers[0];
        SecondAnswer = this.questions.QuestionList[currentQuestionIndex].Answers[1];
        ThirdAnswer = this.questions.QuestionList[currentQuestionIndex].Answers[2];
        FourthAnswer = this.questions.QuestionList[currentQuestionIndex].Answers[3];
        this.correctAnswerIndex = this.questions.QuestionList[currentQuestionIndex].CorrectAnswerIndex;
    }

    public MainWindow()
    {
        InitializeComponent();
        string json = File.ReadAllText(this.dataPath);
        this.questions = JsonSerializer.Deserialize<Questions>(json);

        DataContext = this;
        SetUpCurrentQuestion();
    }

    private void AnswerButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button chosenAnswer)
        {
            string correctAnswer = this.questions.QuestionList[currentQuestionIndex].Answers[correctAnswerIndex];


            if (chosenAnswer.Content.ToString() == correctAnswer)
            {
                Console.WriteLine("Success!");
                currentQuestionIndex++;
                SetUpCurrentQuestion();
            }

            else
            {
                Environment.Exit(0);
            }
        }
    }
}
