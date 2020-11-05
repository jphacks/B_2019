using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 複数の動画を扱える
/// 音声に応じて切り替えなど
/// </summary>
public class AppCharactor : MonoBehaviour, IAppElement
{
    List<AppVideo> m_videos = new List<AppVideo>();


    // Start is called before the first frame update
    void Start()
    {
        var clickable = GetComponent<Clickable3D>();
        if (clickable == null)
        {
            Debug.LogError("Clickable not found", gameObject);
            return;
        }
        clickable.OnMouseOverIn.AddListener(OnMouseOverIn);
        clickable.OnMouseOverExit.AddListener(OnMouseOverExit);

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
    public void Active(bool flag)
    {

    }
    public void Close()
    {
        Destroy(gameObject);
    }

    public void OnGenerated()
    {
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

}
