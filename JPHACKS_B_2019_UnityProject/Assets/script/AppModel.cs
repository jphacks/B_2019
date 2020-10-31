using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppModel : MonoBehaviour,IAppElement
{
    Renderer renderer;
    Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.GetColor("_Color");
        Clickable3D clickable = GetComponent<Clickable3D>();
        clickable.OnMouseOverIn.AddListener(OnMouseOverIn);
        clickable.OnMouseOverExit.AddListener(OnMouseOverExit);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGenerated()
    {

    }

    public void Close()
    {
        Destroy(gameObject);
    }

    public void OnMouseOverIn()
    {
        Debug.Log("mouse in");
        renderer.material.SetColor("_Color", defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
    }

    public void OnMouseOverExit()
    {
        Debug.Log("mouse exit");
        renderer.material.SetColor("_Color", defaultColor);
    }

    public void OnMouseClicked()
    {

    }
}
