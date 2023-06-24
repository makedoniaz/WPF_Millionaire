using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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

    private string? questionText;
    private string? firstAnswer;
    private string? secondAnswer;
    private string? thirdAnswer;
    private string? fourthAnswer;
    private int? currentPrize;

    private int currentQuestionIndex = 0;
    private int? correctAnswerIndex;

    public string? QuestionText 
    {
        get => this.questionText;
        set => this.PropertyChangeMethod(out this.questionText, value);
    }

    public string? FirstAnswer
    {
        get => this.firstAnswer;
        set => this.PropertyChangeMethod(out this.firstAnswer, value);
    }

    public string? SecondAnswer
    {
        get => this.secondAnswer;
        set => this.PropertyChangeMethod(out this.secondAnswer, value);
    }

    public string? ThirdAnswer
    {
        get => this.thirdAnswer;
        set => this.PropertyChangeMethod(out this.thirdAnswer, value);
    }

    public string? FourthAnswer
    {
        get => this.fourthAnswer; 
        set => this.PropertyChangeMethod(out this.fourthAnswer, value);
    }

    public int? CurrentPrize
    {
        get => this.currentPrize; 
        set => this.PropertyChangeMethod(out this.currentPrize, value);
    }

    private void PropertyChangeMethod<T>(out T field, T value, [CallerMemberName] string propName = "")
    {
        field = value;

        if (this.PropertyChanged != null)
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public int CurrentQuestionIndex
    {
        get => this.currentQuestionIndex;
        set {
            if (value >= amountOfQuestions)
                Environment.Exit(0);

            this.currentQuestionIndex = value;
        }
    }

    public void SetUpCurrentQuestion()
    {
        
        this.QuestionText = this.questions?.QuestionList[currentQuestionIndex].Text;
        this.FirstAnswer = this.questions?.QuestionList[currentQuestionIndex].Answers[0];
        this.SecondAnswer = this.questions?.QuestionList[currentQuestionIndex].Answers[1];
        this.ThirdAnswer = this.questions?.QuestionList[currentQuestionIndex].Answers[2];
        this.FourthAnswer = this.questions?.QuestionList[currentQuestionIndex].Answers[3];
        this.CurrentPrize = this.questions?.QuestionList[currentQuestionIndex].Prize;
        this.correctAnswerIndex = this.questions?.QuestionList[currentQuestionIndex].CorrectAnswerIndex;
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
            string? correctAnswer = this.questions?.QuestionList[currentQuestionIndex].Answers[correctAnswerIndex ?? 0];

            if (chosenAnswer.Content.ToString() == correctAnswer)
            {
                this.CurrentQuestionIndex++;
                SetUpCurrentQuestion();

                return;
            }

                Thread.Sleep(1000);
                Environment.Exit(0);
            }
    }
}
