using System.Threading;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public static class ThreadProcess
    {
        private enum ThreadStatus { Running = 0, Stopped = 1 };
        private static ThreadStatus _currentStatus = ThreadStatus.Stopped;
        private static Thread _t;
        private static string _strMessage = "";
        private static int _intProgress = -1;
        private static bool _bringToFront;

        public static void Start()
        {
            _strMessage = "";
            _intProgress = -1;
            Start(_strMessage);
        }

        public static void Start(string strMessage)
        {
            _strMessage = strMessage;
            _intProgress = -1;
            Start(_strMessage, _intProgress);
        }

        public static void Start(int intProgress)
        {
            _strMessage = "";
            _intProgress = intProgress;
            Start(_strMessage, _intProgress);
        }

        public static void Start(string strMessage, int intProgress)
        {
            _strMessage = strMessage;
            _intProgress = intProgress;     

            ////this is to close and reopen new
            //if (t != null && t.ThreadState == ThreadState.Running)
            //{
            //    CurrentStatus = ThreadStatus.Stopped;
            //    Thread.Sleep(200);
            //}

            //t = new Thread(new ThreadStart(OpenFormAndWait));
            //CurrentStatus = ThreadStatus.Running;
            //t.Start();

            //this is to keep using same if already open
            if (_t != null && _t.ThreadState == ThreadState.Running)
            {
                _bringToFront = true;
            }
            else
            {
                _t = new Thread(OpenFormAndWait);
                _currentStatus = ThreadStatus.Running;
                _t.Start();
            }
        }

        public static void UpdateMessage(string strMessage)
        {
            _strMessage = strMessage;
        }

        public static void UpdateProgress(int intProgress)
        {
            _intProgress = intProgress;
        }

        public static void Stop()
        {
            _currentStatus = ThreadStatus.Stopped;

        }

        private static void OpenFormAndWait()
        {
            var tp = new FrmThreadProcess();
            tp.Show();
            tp.BringToFront();
            while (_currentStatus == ThreadStatus.Running)
            {
                Thread.Sleep(100);
                tp.UpdateProgress(_intProgress);
                tp.UpdateMessage(_strMessage);
                if (_bringToFront)
                {
                    tp.BringToFront();
                    _bringToFront = false;
                }
                tp.BringToFront();
                Application.DoEvents();
                tp.Refresh();
            }
            tp.Dispose();
        }

    }
}
