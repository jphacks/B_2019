using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorGenerator : SingletonMonoBehaviour<CharactorGenerator>
{
    [SerializeField] GameObject prefab = default;
    
    public void GenerateCharactor()
    {
        var obj = Instantiate(prefab, transform).GetComponent<AppCharactor>();
        if (obj == null)
        {
            Debug.LogError("App video script not attached");
            return;
        }
        AppManager.Instance.AddAppCharactor(obj.gameObject);
    }
}
