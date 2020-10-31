using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using B83.Win32;

public class videoLoader : MonoBehaviour
{
    public int s = 0;
    [SerializeField]VideoPlayer player;
    // Start is called before the first frame update
    void OnEnable()
    {
        FileDragAndDrop.Instance.AddOnFiles(OnFiles);
    }
    void OnFiles(List<string> aFiles, POINT aPos)
    {
        player.Stop();
        foreach (var file in aFiles)
        {
            GenerateFromPath(file);
        }
    }

    //https://qiita.com/seka/items/4197e97562b1f071b8af
    public void GenerateFromPath(string path)
    {
        player.url = path;
        player.Play();

    }

}
