using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] GameObject appUIPrefab = default;
    [SerializeField] Transform contentParent=default;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAppUI(GameObject app)
    {
        var obj = Instantiate(appUIPrefab, contentParent);
        obj.GetComponent<AppUI>().target = app;
    }
    public void OnAddApp(int value)
    {

    }
}
