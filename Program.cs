namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleUI.DisplayMainMenu();

                int choice = ConsoleUI.GetUserMenuChoice();

                switch (choice)
                {
                    case QuizConstants.MENU_OPTION_ADD_QUESTIONS:
                        ConsoleUI.EnterQuestions();
                        break;
                    case QuizConstants.MENU_OPTION_TAKE_QUIZ:
                        TakeQuiz();
                        break;
                    case QuizConstants.MENU_OPTION_QUIT:
                        ConsoleUI.ShowExitMessage();
                        return;
                    default:
                        ConsoleUI.ShowInvalidOptionMessage();
                        break;
                }
            }
        }

        static void TakeQuiz()
        {
            List<Question> questions = QuizDataHandler.LoadQuestions();
            if (questions.Count == 0)
            {
                ConsoleUI.ShowNoQuestionsMessage();
                return;
            }

            // Shuffle the questions
            questions.Shuffle();

            int correctAnswers = 0;

            foreach (var question in questions)
            {
                // Shuffle the answers for each question before asking
                question.ShuffleAnswers();

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



