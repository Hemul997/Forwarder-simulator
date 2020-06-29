using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Forwarder.Controllers.Auxiliary
{
    public class FileWorker : MonoBehaviour
    {
        private string DirectoryPath;
        private string FileName;       

        public void PrintData(List<string> data, string localDirectory)
        {
            CreateFilePath(localDirectory);
            if (data.Count != 0)
            {
                StreamWriter sw = new StreamWriter(FileName);
                foreach (var str in FileName)
                {
                    sw.WriteLine(str);
                }
                sw.Flush();
            }
        } 

        private void CreateFilePath(string localDirectory)
        {
            DirectoryPath = Application.persistentDataPath + localDirectory;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            FileName = DirectoryPath + DateTime.Now.Day.ToString() + '_' + DateTime.Now.Month.ToString() + '_' + DateTime.Now.Hour.ToString() + '_' +
                DateTime.Now.Minute.ToString() + @".txt";
        }
    }
}
