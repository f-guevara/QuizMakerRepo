namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = ConsoleUI.ShowMainMenu();

                switch (choice)
                {
                    case ConsoleUI.MENU_OPTION_ADD_QUESTIONS:
                        ConsoleUI.EnterQuestions();
                        break;
                    case ConsoleUI.MENU_OPTION_TAKE_QUIZ:
                        TakeQuiz();
                        break;
                    case ConsoleUI.MENU_OPTION_QUIT:
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



