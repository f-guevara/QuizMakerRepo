using System;
using System.Collections.Generic;

namespace QuizMaker
{
    static class ConsoleUI
    {
        

        public static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine($"{QuizConstants.MENU_OPTION_ADD_QUESTIONS}. Enter New Questions");
            Console.WriteLine($"{QuizConstants.MENU_OPTION_TAKE_QUIZ}. Take the Quiz");
            Console.WriteLine($"{QuizConstants.MENU_OPTION_QUIT}. Quit");
        }

        public static int GetUserMenuChoice()
        {
            while (true)
            {
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= QuizConstants.MENU_OPTION_ADD_QUESTIONS && choice <= QuizConstants.MENU_OPTION_QUIT)
                {
                    return choice;
                }
                else
                {
                    ShowInvalidOptionMessage();
                }
            }
        }


        public static void ShowInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option. Please try again.");
        }

        public static void ShowExitMessage()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
        }

        public static void ShowNoQuestionsMessage()
        {
            Console.WriteLine("No questions available. Please add some questions first.");
        }

        public static void EnterQuestions()
        {
            List<Question> questions = new List<Question>();

            while (true)
            {
                string questionText = HandleQuestionText();
                if (string.IsNullOrWhiteSpace(questionText))
                {
                    Console.WriteLine("No questions were added.");
                    break;
                }

                List<string> answers = HandleAnswers(out int correctAnswerIndex);
                if (correctAnswerIndex == -1)
                {
                    Console.WriteLine("No correct answer selected. Please try again.");
                    continue;
                }

                questions.Add(new Question(questionText, answers, correctAnswerIndex));
                Console.WriteLine("Question added successfully!");

                // Check if the user wants to add another question or exit
                if (!AskIfContinue())
                {
                    break;
                }
            }

            if (questions.Count > 0)
            {
                QuizDataHandler.SaveQuestions(questions);
                Console.WriteLine($"{questions.Count} questions saved successfully.");
            }
        }

        private static string HandleQuestionText()
        {
            Console.Write("Enter the question (or leave empty and press Enter to quit): ");
            return Console.ReadLine();
        }

        private static List<string> HandleAnswers(out int correctAnswerIndex)
        {
            correctAnswerIndex = -1;
            int numberOfAnswers = GetNumberOfAnswers(); // Ask user for the number of possible answers
            List<string> answers = new List<string>();

            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Write($"Enter answer {i + 1}: ");
                string answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("Answer cannot be empty. Please enter a valid answer.");
                    i--; // Repeat this iteration
                    continue;
                }

                answers.Add(answer);

                // Adjusted this line to no longer pass an argument
                if (correctAnswerIndex == -1 && ConfirmCorrectAnswer())
                {
                    correctAnswerIndex = i;
                }
            }

            return answers;
        }


        private static int GetNumberOfAnswers()
        {
          
            int numberOfAnswers = 0;

            while (true)
            {
                Console.Write($"Enter the number of possible answers (between {QuizConstants.MIN_ANSWERS} and {QuizConstants.MAX_ANSWERS}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out numberOfAnswers))
                {
                    if (numberOfAnswers >= QuizConstants.MIN_ANSWERS && numberOfAnswers <= QuizConstants.MAX_ANSWERS)
                    {
                        break; // Valid input, break the loop
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number between {QuizConstants.MIN_ANSWERS} and {QuizConstants.MAX_ANSWERS}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }

            return numberOfAnswers;
        }

        private static bool ConfirmCorrectAnswer()
        {
            Console.Write($"Is this the correct answer? ({QuizConstants.THE_CORRECT_ANSWER}/n): ");
            return Console.ReadLine().Trim().ToLower() == QuizConstants.THE_CORRECT_ANSWER;
        }


        private static bool AskIfContinue()
        {
            Console.WriteLine("Enter next question or press ESC to quit.");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.Key != ConsoleKey.Escape;
        }
    


    public static int AskQuestion(Question question)
        {
            Console.WriteLine(question.QuestionText);

            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i]}");
            }

            while (true)
            {
                Console.Write("Select the correct answer: ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice > 0 && choice <= question.Answers.Count)
                {
                    return choice - 1;  // Convert to zero-based index
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the answers.");
                }
            }
        }

        public static void DisplayScore(int correctAnswers, int totalQuestions)
        {
            Console.WriteLine($"You answered {correctAnswers} out of {totalQuestions} questions correctly!");
        }
    }
}

