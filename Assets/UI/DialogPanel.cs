﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DialogPanel : MonoBehaviour
{
    public List<string> msgs;
    public Text dialog;

    // Use this for initialization
    void Start()
    {
        msgs = new List<string>();
        dialog.text = "";
    }

    public void UpdateDialog(string msgToLog)
    {
        int count = msgs.Count;
        string newDialog = "";
        string time = "" + System.DateTime.Now + "] ";
        int start = (time.IndexOf(":", System.StringComparison.CurrentCulture)) - 2;
        time = "[" + time.Substring(start);
        msgs.Add(time + msgToLog + "\n");
        // TODO: only display last 5 messages
        IEnumerable<string> displayMsgs = msgs.Skip(count - 5);

        foreach (string msg in displayMsgs)
        {
            newDialog += msg;
        }

        dialog.text = newDialog;
    }
}