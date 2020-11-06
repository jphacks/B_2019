using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAppElement 
{
    void Close();
    void SwitchMute();
    void OnMouseOverIn();
    void OnMouseOverExit();
    void OnMouseClicked();
    
}
