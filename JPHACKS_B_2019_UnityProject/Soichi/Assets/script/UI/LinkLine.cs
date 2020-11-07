using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LinkLine : MonoBehaviour
{
    ObjectLinker m_beginLinker;
    ObjectLinker m_endLinker;
    LineRenderer m_line;
    LineRenderer Line
    {
        get {
            if (m_line == null) m_line = GetComponent<LineRenderer>();
            return m_line;
        }
    }

    public bool linkEndToMouse = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (linkEndToMouse)
        {
            Line.SetPosition(1, Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                var currentLinker = UILineManager.Instance.GetMouseHoveredLinker();
                if (currentLinker != null)
                {
                    SetEnd(currentLinker);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void SetBegin(ObjectLinker linker)
    {
        Line.SetPosition(0, linker.transform.position);
        m_beginLinker = linker;
    }

    public void SetEnd(ObjectLinker linker)
    {
        linkEndToMouse = false;
        m_endLinker = linker;
        Line.SetPosition(1, linker.transform.position);
    }
}
