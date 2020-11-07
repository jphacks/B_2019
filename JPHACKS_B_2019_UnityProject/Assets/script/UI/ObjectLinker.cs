using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLinker : MonoBehaviour
{
    [SerializeField] Transform lineTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnObjectReceived()
    {

    }

    void OnObjectSent()
    {

    }

    //EventTriggerで各種指定


    public void OnPointOver()
    {
        UILineManager.Instance.SetHoveredLinker(this);
    }
    public void OnPointDown()
    {
        UILineManager.Instance.GenerateLineMouse(this);
    }
    public void OnPointExit()
    {
        UILineManager.Instance.SetHoveredLinker(null);
    }
}
