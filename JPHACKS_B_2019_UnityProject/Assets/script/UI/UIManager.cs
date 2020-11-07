using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] GameObject appUIPrefab = default;
    [SerializeField] GameObject appUICharactorPrefab = default;
    [SerializeField] Transform contentParent=default;

    [SerializeField] TMP_Dropdown dropdown = default;
    List<string> m_options=new List<string>();
    bool m_UIActiveFlag = true;

    private void Start()
    {
        foreach(var opt in dropdown.options)
        {
            m_options.Add( opt.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!m_UIActiveFlag&&Input.anyKeyDown){
            m_UIActiveFlag = true;
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
        }
    }

    public void AddAppUI(GameObject target)
    {
        var obj = Instantiate(appUIPrefab, contentParent);
        obj.GetComponent<AppUI>().SetTarget(target);
    }
    public void AddAppUICharactor(GameObject target)
    {

        var obj = Instantiate(appUICharactorPrefab, contentParent);
        obj.GetComponent<AppUI>().SetTarget(target);

    }

    public void AddCharactor()
    {
        CharactorGenerator.Instance.GenerateCharactor();
    }
    public void AddVideo()
    {
        VideoGenerator.Instance.GenerateVideo("");
    }
    public void OffUI()
    {
        m_UIActiveFlag = false;
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }


}
