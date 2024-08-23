using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public static class ConsoleUI
    {
        // Method to display a question and get the user's answer
        public static int AskQuestion(QuizQuestion question)
        {
            Console.WriteLine(question.QuestionText);
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i]}");
            }

            int userAnswerIndex = GetUserAnswerIndex(question.Answers.Count);
            return userAnswerIndex - 1;
        }

        // Method to get and validate the user's answer
        private static int GetUserAnswerIndex(int maxOptions)
        {
            int answerIndex;
            while (true)
            {
                Console.Write("Your answer (1 to 4): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out answerIndex) && answerIndex >= 1 && answerIndex <= maxOptions)
                {
                    return answerIndex;
                }
                Console.WriteLine($"Please enter a number between 1 and {maxOptions}.");
            }
        }

        // Method to display the final score
        public static void DisplayScore(int correctAnswers, int totalQuestions)
        {
            Console.WriteLine($"You got {correctAnswers} out of {totalQuestions} correct!");
        }
    }
}
