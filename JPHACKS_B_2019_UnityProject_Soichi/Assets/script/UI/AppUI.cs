using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppUI : MonoBehaviour
{
     public GameObject m_target;
    IAppElement appElement;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetTarget(GameObject target)
    {
        appElement = target.GetComponent<IAppElement>();
        m_target = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseButtonPushed()
    {
        appElement.Close();
        Destroy(gameObject);
    }
    public void OnMuteButtonPushed()
    {
        appElement.SwitchMute();
    }

    public void SetTargetPath(string[] path)
    {
        appElement.Set(path[0]);
    }
}
