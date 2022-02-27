using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  [SerializeField] private GameObject[] windows;
  public void ChangeWindows(int window)
  {
        for (int i = 0; i < windows.Length; i++)
            windows[i].SetActive(false);
       
        windows[window].SetActive(true);
  }
}
