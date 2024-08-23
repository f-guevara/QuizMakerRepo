using System;
using System.Collections.Generic;

namespace QuizMaker
{
	public class QuizQuestion
	{
		public string QuestionText { get; set; }
		public List<string> Answers { get; set; }
		public int CorrectAnswerIndex { get; set; }

		// Parameterless constructor required for XML serialization
		public QuizQuestion()
		{
			Answers = new List<string>(); // Initialize the Answers list
		}

		// Constructor with parameters
		public QuizQuestion(string questionText, List<string> answers, int correctAnswerIndex)
		{
			QuestionText = questionText;
			Answers = answers;
			CorrectAnswerIndex = correctAnswerIndex;
		}
	}
}

