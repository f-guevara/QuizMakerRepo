using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public static class QuizMakerBusiness
    {
        // Constants
        public const int MIN_ANSWER_INDEX = 0;
        public const int MAX_ANSWER_INDEX = 3;

        // Method to check if the user's answer is correct
        public static bool IsAnswerCorrect(QuizQuestion question, int userAnswerIndex)
        {
            return question.CorrectAnswerIndex == userAnswerIndex;
        }

        // Method to generate a list of sample questions (for testing)
        public static List<QuizQuestion> GenerateSampleQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion("What color is the sky?", new List<string> { "Blue", "Red", "Green", "Yellow" }, 0),
                new QuizQuestion("What is the capital of France?", new List<string> { "Berlin", "Madrid", "Paris", "Rome" }, 2),
                new QuizQuestion("Which number is even?", new List<string> { "1", "3", "5", "6" }, 3)
            };
        }
    }
}
