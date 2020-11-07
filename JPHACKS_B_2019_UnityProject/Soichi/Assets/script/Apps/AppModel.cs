using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppModel : MonoBehaviour,IAppElement
{
    Renderer m_renderer;
    Color m_defaultColor;
    // Start is called before the first frame update
    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
        m_defaultColor = m_renderer.material.GetColor("_Color");
    }
    void Start()
    {
        Clickable3D clickable = GetComponent<Clickable3D>();
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
    public void OnMouseOverIn()
    {
        Debug.Log("mouse in");
        m_renderer.material.SetColor("_Color", m_defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
    }

    public void OnMouseOverExit()
    {
        Debug.Log("mouse exit");
        m_renderer.material.SetColor("_Color", m_defaultColor);
    }

    public void OnMouseClicked()
    {

    }
}
