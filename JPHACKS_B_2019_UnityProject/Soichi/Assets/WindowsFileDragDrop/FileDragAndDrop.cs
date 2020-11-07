using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using B83.Win32;
using TMPro;
using System.IO;
//https://baba-s.hatenablog.com/entry/2019/11/11/100000

public class FileDragAndDrop : SingletonMonoBehaviour<FileDragAndDrop>
{
    public delegate void DropFileEvent(string path, B83.Win32.POINT point);



    Dictionary<string, DropFileEvent> m_OnDropFiles=new Dictionary<string, DropFileEvent>();


    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }
    public void AddOnFiles(DropFileEvent func,string[] extentions) {
        foreach(var extention in extentions)
        {
            m_OnDropFiles.Add(extention, func);
        log.Add(extention);
        }
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        foreach (var file in aFiles)
        {
            string extention = Path.GetExtension(file).ToLower();
            if (!m_OnDropFiles.ContainsKey(extention))
            {
                Debug.LogError($"this extention'{extention}' does not supported");
                continue;
            }
            m_OnDropFiles[extention](file, aPos);
        }
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
            aFiles.Aggregate((a, b) => a + "\n\t" + b);
        Debug.Log(str);
        log.Add(str);



    }

    List<string> log = new List<string>();
    private void OnGUI()
    {
        if (GUILayout.Button("clear log"))
            log.Clear();
        foreach (var s in log)
            GUILayout.Label(s);
    }
}

