using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAppElement 
{
    void Set(string path);
    void Close();
    void SwitchMute();
    void OnMouseOverIn();
    void OnMouseOverExit();
    void OnMouseClicked();
}
