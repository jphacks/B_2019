using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILineManager : SingletonMonoBehaviour<UILineManager>
{
    [SerializeField] Transform lineParent;
    [SerializeField] GameObject prefab;
    List<LinkLine> m_lines = new List<LinkLine>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// beginからマウスの座標に追従する線を生成します
    /// </summary>
    /// <param name="begin"></param>
    public void GenerateLineMouse(ObjectLinker begin)
    {
        var obj = Instantiate(prefab, lineParent).GetComponent<LinkLine>();
        obj.SetBegin(begin);
        obj.linkEndToMouse = true;
    }


    ObjectLinker m_currentHoveredLinker;

    public ObjectLinker GetMouseHoveredLinker()
    {
        return m_currentHoveredLinker;
    }

    public void SetHoveredLinker(ObjectLinker linker)
    {
        m_currentHoveredLinker = linker;
    }


}
