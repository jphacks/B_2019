using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppSprite : MonoBehaviour,IAppElement
{
    SpriteRenderer m_renderer;
    SpriteRenderer Renderer
    {
        get{
            if(m_renderer==null)m_renderer = GetComponent<SpriteRenderer>();
            return m_renderer;
        }
    }
    Color m_defaultColor;
    void Start()
    {
        m_defaultColor = Renderer.material.GetColor("_Color");
        var clickable = GetComponent<Clickable3D>();
        if (clickable == null)
        {
            Debug.LogError("Clickable not found", gameObject);
            return;
        }
        clickable.OnMouseOverIn.AddListener(OnMouseOverIn);
        clickable.OnMouseOverExit.AddListener(OnMouseOverExit);
        var collider = GetComponent<BoxCollider>();
        collider.size = new Vector3(Renderer.bounds.size.x, Renderer.bounds.size.y, 1);
    }
    public void Load(Sprite sprite)
    {
        Renderer.sprite = sprite;
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
        Renderer.material.SetColor("_Color", m_defaultColor);
    }

    public void OnMouseOverIn()
    {
        Renderer.material.SetColor("_Color", m_defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
    }
}
