using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    static class QuizDataHandler
    {
        

        // Declare the XmlSerializer as a static, readonly field
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

        public static void SaveQuestions(List<Question> questions)
        {
            using (FileStream stream = new FileStream(QuizConstants.FILE_PATH, FileMode.Create))
            {
                serializer.Serialize(stream, questions);
            }
        }

        public static List<Question> LoadQuestions()
        {
            if (!File.Exists(QuizConstants.FILE_PATH))
            {
                return new List<Question>();
            }

            using (FileStream stream = new FileStream(QuizConstants.FILE_PATH, FileMode.Open))
            {
                return (List<Question>)serializer.Deserialize(stream);
            }
        }
    }
}

