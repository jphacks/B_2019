using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable3D : MonoBehaviour
{
    Color defaultColor;
    Camera mainCamera;
    Renderer renderer;
    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        mainCamera = Camera.main;
        defaultColor = renderer.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit_info = new RaycastHit();
        float max_distance = 100f;

        bool is_hit = Physics.Raycast(ray, out hit_info, max_distance);

        if (is_hit && hit_info.collider == collider)
        {
            renderer.material.SetColor("_Color", defaultColor * new Color(0.5f, 0.5f, 0.5f, 1.0f));
        }
        else
        {
            renderer.material.SetColor("_Color", defaultColor);
        }

    }
}
