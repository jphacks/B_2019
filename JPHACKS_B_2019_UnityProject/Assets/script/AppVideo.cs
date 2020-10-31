using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AppVideo : MonoBehaviour,IAppElement
{
    VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player= GetComponent<VideoPlayer>();
        var clickable = GetComponent<Clickable3D>();
        clickable.OnMouseOverIn.AddListener(OnMouseOverIn);
        clickable.OnMouseOverExit.AddListener(OnMouseOverExit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load(string path)
    {
        player.url = path;
        player.Play();
    }

    public void OnGenerated()
    {
    }

    public void Close()
    {
        Destroy(gameObject);
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
