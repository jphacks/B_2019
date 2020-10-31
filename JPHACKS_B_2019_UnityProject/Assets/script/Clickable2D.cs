using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==================================================================
//うまくうごきません
//

public class Clickable2D : MonoBehaviour
{
    Color defaultColor;
    Camera mainCamera;
    Renderer renderer;
    [SerializeField]Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
        defaultColor = renderer.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        var info = Physics2D.Raycast(ray.origin, ray.direction);
        if (info.collider == collider)
        {
            renderer.material.SetColor("_Color", defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
        }
        else
        {
            renderer.material.SetColor("_Color", defaultColor);
        }

    }
}
