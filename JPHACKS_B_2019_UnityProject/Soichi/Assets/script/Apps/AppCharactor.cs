using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 複数の動画を扱える
/// 音声に応じて切り替えなど
/// </summary>
public class AppCharactor : MonoBehaviour, IAppElement
{

    [SerializeField] GameObject childOnNormal;
    [SerializeField] GameObject childOnVoice;

    List<AppVideo> m_videos = new List<AppVideo>();

    // Start is called before the first frame update
    void Start()
    {
        childOnVoice.SetActive(false);
    }
    public void Load(string[] pathes)
    {
        foreach(var path in pathes)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Set(string path)
    {

    }
    public void Close()
    {
        Destroy(gameObject);
    }
    public void SwitchMute()
    {
        var flag = gameObject.activeSelf;
        gameObject.SetActive(!flag);
    }

    public void OnMouseClicked()
    {
    }

    public void OnMouseOverExit()
    {
    }

    public void OnMouseOverIn()
    {
    }
    public void SetNormal(string path)
    {
        childOnNormal.GetComponent<AppVideo>().Set(path);
    }

    public void SetVoice(string path)
    {
        childOnVoice.GetComponent<AppVideo>().Set(path);
    }
}
