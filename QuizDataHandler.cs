using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using System.Xml.Serialization;

namespace QuizMaker
{
    static class QuizDataHandler
    {
        private const string FilePath = "questions.xml";

        public static void SaveQuestions(List<Question> questions)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream stream = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, questions);
            }
        }

        public static List<Question> LoadQuestions()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Question>();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream stream = new FileStream(FilePath, FileMode.Open))
            {
                return (List<Question>)serializer.Deserialize(stream);
            }
        }
    }
}
