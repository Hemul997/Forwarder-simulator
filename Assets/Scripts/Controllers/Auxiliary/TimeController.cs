using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Forwarder.Controllers.Auxiliary
{
    using ActivityAnalysis.Dynamics;

    /// <summary>
    /// Unity components class for work with timer.
    /// </summary>
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private Text BeforeCaptureText;
        [SerializeField]
        private Text AfterCaptureText;
        [SerializeField]
        private DynamicsController dynamicsController;

        [SerializeField]
        private FileWorker fileWorker;

        [SerializeField]
        private ErrorsCounter errorsCounter;

        private string directoryPath;
        private string fileName;

        Stopwatch stopwatch;
        private TimerState State;
        private List<string> Logs;
        private int TreesCount;

        //public int LastDroppingTime { get; private set; }

        public void Start()
        {
            stopwatch = new Stopwatch();


            //LastCapturingTime = 0;
            TreesCount = 0;
            Logs = new List<string>();
            State = TimerState.DROPPED;

            Record();

            AfterCaptureText.gameObject.SetActive(false);
        }

        public void OnCapture()
        {
            ++TreesCount;

            AfterCaptureText.gameObject.SetActive(true);
            BeforeCaptureText.gameObject.SetActive(false);
            State = TimerState.CAPTURED;
            Stop();

            Record();
        }

        public void OnDrop()
        {
            AfterCaptureText.gameObject.SetActive(false);
            BeforeCaptureText.gameObject.SetActive(true);
            State = TimerState.DROPPED;
            dynamicsController.OnDrop((int)stopwatch.Elapsed.TotalSeconds);
            Stop();
            Record();
        }

        private void Record()
        {
            stopwatch.Start();
        }

        public void FixedUpdate()
        {
            if (stopwatch.IsRunning)
            {
                if (State == TimerState.DROPPED)
                {
                    BeforeCaptureText.text = Mathf.Round((float)(stopwatch.Elapsed.TotalSeconds)).ToString();
                }
                else
                {
                    AfterCaptureText.text = Mathf.Round((float)(stopwatch.Elapsed.TotalSeconds)).ToString();
                }

            }
        }

        private void Stop()
        {
            stopwatch.Stop();
            if (State == TimerState.CAPTURED)
            {
                //Logs.Add("Захватил " + TreesCount.ToString() + "-е бревно за " + stopwatch.Elapsed.TotalSeconds.ToString() + " cекунд");
                //LastCapturingTime = (int)stopwatch.Elapsed.TotalSeconds;
                //Debug.Log(LastCapturingTime);            
            }
            else
            {
                Logs.Add("Положил " + TreesCount.ToString() + "-е бревно за " + ((int)stopwatch.Elapsed.TotalSeconds).ToString() + " cекунд");
            }

            stopwatch.Reset();
        }

        void OnApplicationQuit()
        {

            if (Logs.Count != 0)
            {
                Logs.Add(GetErrorsState());

                fileWorker.PrintData(Logs, "TimeWorkResults");
            }

        }

        private string GetErrorsState()
        {
            string state = "Уровень ошибок: ";
            switch (errorsCounter.Level)
            {
                case ErrorLevel.LOW:
                    state += "минимальное";
                    break;
                case ErrorLevel.MIDDLE:
                    state += "среднее";
                    break;
                case ErrorLevel.HIGH:
                    state += "максимальное";
                    break;
            }
            return state + "\n Всего ошибок: " + errorsCounter.Count.ToString();

        }

        enum TimerState
        {
            DROPPED = 1, CAPTURED = 2
        }
    }
}
