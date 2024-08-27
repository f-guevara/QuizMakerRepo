# QuizMaker

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [How to Use](#how-to-use)
- [Input Validation](#input-validation)
- [Contributing](#contributing)
- [License](#license)

## Introduction
QuizMaker is a console-based application written in C#. It allows users to create quizzes with multiple-choice questions and then take those quizzes. The program focuses on ease of use, providing options to either enter new quiz questions or take an existing quiz.

## Features
- **Create Quizzes**: Add multiple-choice questions and specify the correct answers.
- **Take Quizzes**: Answer randomly selected questions from the stored quiz data.
- **Score Tracking**: Keep track of correct answers and display the score at the end of the quiz.
- **Data Persistence**: Quiz questions are saved and loaded from an XML file, enabling persistent data storage.
- **Input Validation**: Ensures that user inputs are within expected ranges and formats.

## Installation
To run the QuizMaker program, you’ll need:

- .NET SDK installed on your machine.

### Steps:
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/quiz-maker.git
    ```
2. Navigate to the project directory:
    ```bash
    cd quiz-maker
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the program:
    ```bash
    dotnet run
    ```

## How to Use
### Creating a Quiz
1. Start the program, and choose the option to **Enter Questions**.
2. Follow the prompts to enter the question, multiple-choice answers, and specify the correct answer.
3. The quiz data will be saved automatically.

### Taking a Quiz
1. Start the program, and choose the option to **Take the Quiz**.
2. The program will display questions one by one.
3. Select the answer by entering the corresponding number.
4. At the end of the quiz, your score will be displayed.

## Input Validation
The program ensures that all user inputs are valid:
- **Menu Selection**: Only allows numbers corresponding to available menu options.
- **Answer Selection**: Validates that the user selects an answer within the range of provided options.
- **Question Entry**: Ensures questions and answers are non-empty and correctly formatted.

## Contributing
Contributions are welcome! If you'd like to improve the QuizMaker program, please fork the repository and submit a pull request. Before contributing, please consider the following:
- Follow the existing code structure and style.
- Write clear and concise commit messages.
- Test your changes thoroughly before submitting.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.
