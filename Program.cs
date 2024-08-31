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
                        ConsoleUI.TakeQuiz();
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
    }
}



