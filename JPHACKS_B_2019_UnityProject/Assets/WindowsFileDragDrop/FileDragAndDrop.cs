using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using B83.Win32;
using TMPro;
//https://baba-s.hatenablog.com/entry/2019/11/11/100000

public class FileDragAndDrop : SingletonMonoBehaviour<FileDragAndDrop>
{
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        AddOnFiles(OnFiles);
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }
    public void AddOnFiles(UnityDragAndDropHook.DroppedFilesEvent func) { UnityDragAndDropHook.OnDroppedFiles += func; }
    void OnFiles(List<string> aFiles, POINT aPos)
    {
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

