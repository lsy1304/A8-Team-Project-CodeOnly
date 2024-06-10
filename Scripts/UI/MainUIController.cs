using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    [SerializeField]
    GameObject soundBoard;
    public void ToggleWindow()
    {
        bool isActive = soundBoard.activeSelf;
        soundBoard.SetActive(!isActive);
    }
}
