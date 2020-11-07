using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AppUI))]
public class AppUICharactor : MonoBehaviour
{
    AppUI m_ui;
    AppCharactor m_charactor;
    private void Awake()
    {
        m_ui = GetComponent<AppUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_ui.m_target == null)
        {
            Debug.LogError("target not found");
            return;
        }
        m_charactor = m_ui.m_target.GetComponent<AppCharactor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNormalBrowseSuccess(string[] path)
    {
        m_charactor.SetNormal(path[0]);
    }
    public void OnVoiceBrowseSuccess(string[] path)
    {
        m_charactor.SetVoice(path[0]);
    }
}
