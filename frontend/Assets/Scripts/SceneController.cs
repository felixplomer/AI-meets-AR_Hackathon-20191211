using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;


#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class SceneController : MonoBehaviour
{

    void QuitOnConnectionErrors()
    {
        string msg = "";

        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
            msg = "Camera permission is needed!";
        else if (Session.Status.IsError())
            msg = "ARCore encountered a problem connecting";

        if (!string.IsNullOrEmpty(msg))
            StartCoroutine(CodelabUtils.ToastAndExit(msg, 5));
    }

    // Start is called before the first frame update
    void Start()
    {
        QuitOnConnectionErrors();
    }

    // Update is called once per frame
    void Update()
    {
        if(Session.Status != SessionStatus.Tracking)
        {
            Screen.sleepTimeout = 15;
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
