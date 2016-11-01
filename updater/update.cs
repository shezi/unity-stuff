// https://msdn.microsoft.com/de-de/library/7a2f3ay4(v=vs.90).aspx
// https://msdn.microsoft.com/de-de/library/0yd65esw.aspx
// https://msdn.microsoft.com/en-us/library/s3bf0xb2(v=vs.110).aspx
using System;
using System.Threading;
using System.Net;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class update : MonoBehaviour {
    [Tooltip("If empty: use the unity version system")]
    public string versionString = "";
    [Tooltip("The URL to check for Updates")]
    public string versionUrl = "";
    public Text autoUpdateTextField = null;
    private Worker workerObject = new Worker();
    private Thread workerThread = null;
    private bool lastBusyState = false;
    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (workerObject.isBusy())
        {
            //Debug.Log("BUSY");
        }
        else if (autoUpdateTextField != null)
        {
            autoUpdateTextField.text = workerObject.getInfoText();
        }

        if (lastBusyState && !this.isBusy())
        {
            lastBusyState = false;
            finished();
        }
	}

    /*
     bind this function to the UI
    */
    public void startCheckUi()
    {
        startCheck();
    }

    /*
     * starts the update thread if not already running
     */
    public bool startCheck()
    {
        if (this.isBusy())
        {
            Debug.Log("can't start, busy!");
            return false;
        }

        Debug.Log("start");
        if (versionString == "")
        {
            workerObject.currentVersion = Application.version.ToString();
        }
        else
        {
            workerObject.currentVersion = versionString;
        }
        workerObject._versionUrl = versionUrl;
        Debug.Log(workerObject.currentVersion);
        workerThread = new Thread(workerObject.DoWork);
        lastBusyState = true;
        // Start the worker thread.
        workerThread.Start();
        return true;
    }

    /*
     * this function is called when a check finishes
     * put your finis logic here
     * (IF needed)
     */
    private void finished()
    {
        Debug.Log("finished()");
    }

    public bool isBusy()
    {
        return workerObject.isBusy() || (workerThread != null && workerThread.IsAlive);
    }

    public bool getStatus()
    {
        return workerObject.isBusy();
    }

    public string getInfoString()
    {
        return workerObject.getInfoText();
    }
}

public class Worker
{
    public updateStates lastCheck = updateStates.update_not_checked;
    public enum updateStates
    {
        update_not_checked,
        update_none,
        update_newer,
        update_older,  // shouldnt be possible! (except for indev)
        update_error
    }

    public string currentVersion = "";

    // Volatile is used as hint to the compiler that this data
    // member will be accessed by multiple threads.
    private volatile bool _shouldStop;
    private volatile bool _isBusy;
    private volatile string _infoText;
    public volatile string _versionUrl;

    // This method will be called when the thread is started.
    public void DoWork()
    {
        _isBusy = true;
        /*
        while (!_shouldStop)
        {
            Console.WriteLine("worker thread: working...");
        }
        Console.WriteLine("worker thread: terminating gracefully.");
         */
        try
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString(_versionUrl);
            downloadString = downloadString.Trim();

            Version versionApp = new Version(currentVersion);
            Version versionWeb = new Version(downloadString);

            int result = versionApp.CompareTo(versionWeb);
            if (result > 0)
            {
                _infoText = "current version is newer (this shouldnt be possible!)";
                lastCheck = updateStates.update_newer;
            }
            else if (result < 0)
            {
                _infoText = "new version available";
                lastCheck = updateStates.update_older;
            }
            else
            {
                _infoText = "up to date";
                lastCheck = updateStates.update_none;
            }
            Console.WriteLine(_infoText);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
            _infoText = e.ToString();
            lastCheck = updateStates.update_error;
        }

        _isBusy = false;
    }

    public string getInfoText()
    {
        return _infoText;
    }

    /*
     * does nothing, but could become useful
     */
    /*public void RequestStop()
    {
        _shouldStop = true;
    }*/

    public bool isBusy()
    {
        return _isBusy;
    }
}