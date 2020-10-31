using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAppElement 
{
    void OnGenerated();
    void Close();
    void OnMouseOverIn();
    void OnMouseOverExit();
    void OnMouseClicked();
    
}
