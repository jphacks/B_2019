using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable3D : MonoBehaviour
{
    Camera mainCamera;
    Collider collider;

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
}
