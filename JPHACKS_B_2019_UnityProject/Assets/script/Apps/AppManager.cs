using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : SingletonMonoBehaviour<AppManager>
{

    public enum App
    {
        movie=0,
        sprite=1,
        model=2,
        charactor=3
    }


   // [SerializeField] GameObject appModelPrefab;

    List<GameObject> m_items=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddApp(GameObject app)
    {
        m_items.Add(app);
        UIManager.Instance.AddAppUI(app);
    }
    public void AddAppCharactor(GameObject app)
    {
        m_items.Add(app);
        UIManager.Instance.AddAppUICharactor(app);
    }

    public void GenerateApp(App app)
    {

    }
    public GameObject[] GetChildren()
    {
        return null;
    }
}
