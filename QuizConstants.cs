namespace QuizMaker
{
    public static class QuizConstants
    {
        // Menu options
        public const int MENU_OPTION_ADD_QUESTIONS = 1;
        public const int MENU_OPTION_TAKE_QUIZ = 2;
        public const int MENU_OPTION_QUIT = 3;

        // Answer confirmation
        public const string THE_CORRECT_ANSWER = "y";

        // Answer limits
        public const int MIN_ANSWERS = 2;
        public const int MAX_ANSWERS = 10;

        // File path for quiz data
        public const string FILE_PATH = "questions.xml";
    }
}
