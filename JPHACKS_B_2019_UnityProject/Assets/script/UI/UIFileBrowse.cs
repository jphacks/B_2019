using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using UnityEngine.Events;

public class UIFileBrowse : MonoBehaviour
{
    [System.Serializable]
    public class FileBrowseSucceed : UnityEvent<string[]>    {}

    public FileBrowseSucceed OnSuccess;

    public void OnPushBrowseButton()
    {
        // フィルタを設定します
        FileBrowser.SetFilters
        (
            false,
            new FileBrowser.Filter("Videos", ".mp4", ".avi")
        );
        // フォルダ選択ダイアログを表示します
        FileBrowser.ShowLoadDialog
        (
            path => Debug.Log("Selected: " + path),
            () => Debug.Log("Canceled"),
            false,
            false,
            "Select Folder",
            "Select"
        );
        // コルーチンサンプル
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    private IEnumerator ShowLoadDialogCoroutine()
    {
        // ファイル読み込みダイアログを表示してユーザーからの応答を待ちます
        yield return FileBrowser.WaitForLoadDialog(false, false, "Load File", "Load");
        if(FileBrowser.Success)
        OnSuccess.Invoke(FileBrowser.Result);
    }
}
