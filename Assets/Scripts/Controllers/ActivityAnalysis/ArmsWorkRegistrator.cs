using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Forwarder.Controllers.ActivityAnalysis
{
    using Auxiliary;
    using System.Text;

    /// <summary>
    /// Unity components class for registration arm moving
    /// </summary>
    public class ArmsWorkRegistrator : MonoBehaviour
    {

        private Dictionary<string, List<string>> WorkTimeDictionary;
        private string localDirectory;

        private FileWorker fileWorker;

        // Use this for initialization
        void Awake()
        {
            fileWorker = new FileWorker();

            WorkTimeDictionary = new Dictionary<string, List<string>>();
            localDirectory = Application.persistentDataPath + @"/Registration results/";
        }

        private List<string> DataToList()
        {

            List<string> list = new List<string>();

            foreach (var pair in SortWorkDataByTime(WorkTimeDictionary))
            {

                StringBuilder builder = new StringBuilder();
                builder.AppendLine(pair.Key + ": ");

                foreach (var item in pair.Value)
                {
                    builder.Append(" " + item);
                }
                list.Add(builder.ToString());
                builder.Clear();
            }
            return list;
        }

        void OnApplicationQuit()
        {
            if (WorkTimeDictionary.Count != 0)
            {
                fileWorker.PrintData(DataToList(), localDirectory);
            }
        }



        SortedDictionary<string, List<string>> SortWorkDataByTime(Dictionary<string, List<string>> timeJournal)
        {
            SortedDictionary<string, List<string>> namesByTime = new SortedDictionary<string, List<string>>();

            foreach (var pair in timeJournal)
            {
                foreach (string time in pair.Value)
                {
                    if (!namesByTime.ContainsKey(time))
                    {
                        namesByTime.Add(time, new List<string> { pair.Key });
                    }
                    else
                    {
                        List<string> listToAdd;
                        if (namesByTime.TryGetValue(time, out listToAdd))
                        {
                            if (!listToAdd.Contains(pair.Key))
                            {
                                listToAdd.Add(pair.Key);
                            }
                        }
                    }
                }
            }
            return namesByTime;
        }

        public void RegistrateWorkTime(string armName)
        {
            string value = DateTime.Now.ToString();
            if (!WorkTimeDictionary.ContainsKey(armName))
            {
                WorkTimeDictionary.Add(armName, new List<string> { value });
            }
            else
            {
                List<string> listToAdd;
                if (WorkTimeDictionary.TryGetValue(armName, out listToAdd))
                {
                    if (!listToAdd.Contains(value))
                    {
                        listToAdd.Add(value);
                    }
                }
            }
        }
    }
}