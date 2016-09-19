using System;
using System.IO;

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

                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;

            }
        }
    }
}
