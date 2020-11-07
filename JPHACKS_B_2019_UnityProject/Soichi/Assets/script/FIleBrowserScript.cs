using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.Linq;

public class FIleBrowserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadBrowser();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBrowser()
    {
        // フォルダ選択ダイアログを表示します
        FileBrowser.ShowLoadDialog
        (
            path => Debug.Log("Selected: " + path),
            () => Debug.Log("Canceled"),
            true,
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
        yield return FileBrowser.WaitForLoadDialog(false,false, "Load File", "Load");
        if(FileBrowser.Success)
        Debug.Log(FileBrowser.Result.Aggregate((a, b) => a + "\n\t" + b));
    }

}
