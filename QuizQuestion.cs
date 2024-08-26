using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        // Parameterless constructor for serialization
        public Question() { }

        public Question(string questionText, List<string> answers, int correctAnswerIndex)
        {
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}

