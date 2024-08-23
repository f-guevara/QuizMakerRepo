using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public static class QuizDataHandler
    {
        // File path to store the quiz data
        public const string FILE_PATH = "quiz_data.xml";

        // Method to save quiz questions to an XML file
        public static void SaveQuizQuestions(List<QuizQuestion> questions)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (StreamWriter writer = new StreamWriter(FILE_PATH))
            {
                serializer.Serialize(writer, questions);
            }
        }

        // Method to load quiz questions from an XML file
        public static List<QuizQuestion> LoadQuizQuestions()
        {
            if (!File.Exists(FILE_PATH))
                return new List<QuizQuestion>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (StreamReader reader = new StreamReader(FILE_PATH))
            {
                return (List<QuizQuestion>)serializer.Deserialize(reader);
            }
        }
    }
}
