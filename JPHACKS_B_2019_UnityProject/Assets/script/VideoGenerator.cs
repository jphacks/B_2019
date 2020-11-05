using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using B83.Win32;

public class VideoGenerator : SingletonMonoBehaviour<VideoGenerator>
{
    [SerializeField] GameObject prefab = default;
 public GameObject Prefab { get { return prefab; } }

    readonly string[] extentions = {".mp4",".avi" }; 

    // Start is called before the first frame update
    void OnEnable()
    {
        FileDragAndDrop.Instance.AddOnFiles(OnFiles, extentions);
    }
    void OnFiles(string file, POINT aPos)
    {
        if (prefab == null)
        {
            Debug.LogError("prefab not set");
            return;
        }
        var obj = Instantiate(prefab, transform).GetComponent<AppVideo>();
        if (obj == null)
        {
            Debug.LogError("App video script not attached");
            return;
        }
        obj.OnGenerated();
        obj.Load(file);
        AppManager.Instance.AddApp(obj.gameObject);
        // GenerateFromPath(file);
    }

    //https://qiita.com/seka/items/4197e97562b1f071b8af
    /*public void GenerateFromPath(string path)
    {
        player.url = path;
        player.Play();
    }*/

}
