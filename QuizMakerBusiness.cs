using System;
using System.Collections.Generic;

namespace QuizMaker
{
    static class QuizMakerBusiness
    {
        public static bool IsAnswerCorrect(Question question, int userAnswerIndex)
        {
            return question.CorrectAnswerIndex == userAnswerIndex;
        }

        public static List<Question> GenerateSampleQuestions()
        {
            return new List<Question>
            {
                new Question("Color of the sky?", new List<string> { "Blue", "Red", "Black" }, 0),
                new Question("Color of the forest?", new List<string> { "Red", "Green", "Blue" }, 1),
                new Question("Capital of USA?", new List<string> { "NY", "CA", "Washington" }, 2)
            };
        }
    }
}

