using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TaskTracker.Core.Model;

namespace TaskTracker.Core.DL
{
    static class XmlDataStore
    {
        private static readonly string xmlFilePath;

        static string DataStoreFilePath
        {
            get
            {
                const string xmlFileName = "TaskDataStore.xml";

                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                return Path.Combine(libraryPath, xmlFileName);

            }
        }

        static XmlDataStore()
        {
            xmlFilePath = DataStoreFilePath;
        }

        internal static List<Task> ReadFromDataStore()
        {
            var tasks = new List<Task>();

            if(File.Exists(xmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(List<Task>));

                using (var streamReader = new FileStream(xmlFilePath, FileMode.Open))
                {
                    tasks = (List<Task>)serializer.Deserialize(streamReader);
                }
            }

            return tasks;
        }

        internal static void WriteToDataStore(List<Task> tasks)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));

            using (var streamWriter = new StreamWriter(xmlFilePath))
            {
                serializer.Serialize(streamWriter, tasks);
            }
        }
    }
}
