using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppUI : MonoBehaviour
{
     public GameObject target;
    IAppElement appElement;
    // Start is called before the first frame update
    void Start()
    {
        appElement = target.GetComponent<IAppElement>();
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
}
