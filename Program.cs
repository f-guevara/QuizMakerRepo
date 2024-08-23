using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<QuizQuestion> questions = QuizDataHandler.LoadQuizQuestions();
            if (questions.Count == 0)
            {
                questions = QuizMakerBusiness.GenerateSampleQuestions();
                QuizDataHandler.SaveQuizQuestions(questions);
            }

            int correctAnswers = 0;

            foreach (var question in questions)
            {
                int userAnswerIndex = ConsoleUI.AskQuestion(question);
                if (QuizMakerBusiness.IsAnswerCorrect(question, userAnswerIndex))
                {
                    correctAnswers++;
                }
            }

            ConsoleUI.DisplayScore(correctAnswers, questions.Count);
        }
    }
}

