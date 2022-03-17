using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour
{
    public string text;
    public void OpenUrl() {
        Application.OpenURL(text);
    }
}
