using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject CameraOffset;

    private GameObject StartPoint;
    private GameObject GoalPoint;
    private GameObject StartBarrier;
    private GameObject SwitchGroup;

    public float _camOrthoSize;

    private void Awake()
    {
        StartPoint = transform.Find("StartPoint").gameObject;
        GoalPoint = transform.Find("GoalPoint").gameObject;
        StartBarrier = transform.Find("StartBarrier").gameObject;

        CameraOffset = transform.Find("CameraOffset").gameObject;
        
    }

    private void OnEnable()
    {
        SwitchGroup = transform.Find("SwitchGroup")?.gameObject;
    }

    public void SetPlayer()
    {
        InitStart();
        Instantiate(Resources.Load<GameObject>("Player"), StartPoint.transform.position, Quaternion.identity);
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = StartPoint.transform.position;
    }

    public void InitStart()
    {
        StartBarrier.SetActive(false);
        StartPoint.SetActive(false);
        if (SwitchGroup == null) return;
        SwitchGroup.SetActive(true);
    }
}
