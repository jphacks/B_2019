using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Clickable3D : MonoBehaviour
{
    Camera mainCamera;
    new Collider collider;

    enum State
    {
        None,
        Hit
    }

    State m_state = State.None;
    public UnityEvent OnMouseOverIn { get; private set; } = new UnityEvent();
    public UnityEvent OnMouseOverExit { get; private set; } = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        mainCamera = Camera.main;
    }

    bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit_info = new RaycastHit();
        float max_distance = 100f;

        bool is_hit = Physics.Raycast(ray, out hit_info, max_distance);

        if (is_hit && hit_info.collider == collider)
        {
            if (m_state==State.None)
            {
                OnMouseOverIn.Invoke();
                m_state = State.Hit;
            }
           /* if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
            }
            if (isClicked)
            {
                MovePosition();
            }*/
        }
        else
        {
            if (m_state == State.Hit)
            {
                m_state = State.None;
                OnMouseOverExit.Invoke();
            }
        }

    }

    void MovePosition()
    {
/*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        moveTo = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = moveTo;*/
    }

}
