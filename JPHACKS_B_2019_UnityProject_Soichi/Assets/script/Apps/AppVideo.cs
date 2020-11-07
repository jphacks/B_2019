using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AppVideo : MonoBehaviour,IAppElement
{
    Renderer m_renderer;
    Color m_defaultColor;
    VideoPlayer m_player;
    VideoPlayer Player
    {
        get
        {
            if(m_player==null)m_player= GetComponent<VideoPlayer>();
            return m_player;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_defaultColor = m_renderer.material.GetColor("_Color");
    }
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

    // Update is called once per frame
    void Update()
    {

    }

    public void Set(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("path is empty");
            return;
        }
        Player.url = path;
        Player.Play();
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
        m_renderer.material.SetColor("_Color", m_defaultColor);
    }

    public void OnMouseOverIn()
    {
        m_renderer.material.SetColor("_Color", m_defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
    }
}
