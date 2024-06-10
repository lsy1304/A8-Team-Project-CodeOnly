using System;
using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int CurLevelIdx;

    private Camera _cam;

    public event Action OnLevelClear;
    public event Action OnLevelRestart;
    public Level[] levels = new Level[2];
    public bool BlockToggleSwitch = false;

    private class CameraOffset
    {
        public float camOrthSize;
        public Vector3 position;
    }
    protected override void Awake()
    {
        base.Awake();
        _cam = Camera.main;
        OnLevelClear += CameraCoroutine;
    }

    public void CallOnLevelRestartEvent()
    {
        OnLevelRestart?.Invoke();
    }

    public void CallOnLevelClearEvent()
    {
        BlockToggleSwitch = true;
        OnLevelClear?.Invoke();
    }

    public void InitLevel()
    {
        LoadLevel(CurLevelIdx, true);
    }

    private Level LoadLevel(int levelIdx, bool setPlayer = false)
    {
        GameObject go = Resources.Load<GameObject>($"Stage/Stage{levelIdx}");
        
        if (go == null) return null;

        Level curLevel = Instantiate(go).GetComponent<Level>();
        if (setPlayer)
        {
            SetCameraPosition(curLevel);
            curLevel.SetPlayer();

            levels[0] = curLevel;
            GameObject nextLevel = Resources.Load<GameObject>($"Stage/Stage{levelIdx + 1}");

            if (nextLevel == null) return null;

            levels[1] = Instantiate(nextLevel).GetComponent<Level>();
        }
        return curLevel;
    }

    public void UpdateLevel()
    {
        Destroy(levels[0].gameObject);
        levels[0] = levels[1];
        levels[0].InitStart();
        levels[1] = LoadLevel(++CurLevelIdx + 1);
    }

    private void SetCameraPosition(Level level)
    {
        _cam.transform.position = level.CameraOffset.transform.position;
        _cam.orthographicSize = level._camOrthoSize;
    }

    private void CameraCoroutine()
    {
        CameraOffset startOffset = new CameraOffset();
        CameraOffset endOffset = new CameraOffset();

        
        startOffset.position = levels[0].CameraOffset.transform.position;
        startOffset.camOrthSize = levels[0]._camOrthoSize;
        endOffset.position = levels[1].CameraOffset.transform.position;
        endOffset.camOrthSize = levels[1]._camOrthoSize;
        
        StartCoroutine(MoveCameraToNextLevel(startOffset, endOffset));
    }

    private IEnumerator MoveCameraToNextLevel(CameraOffset startPosition, CameraOffset endPosition)
    {
        float time = 0f;
        while (_cam.transform.position != endPosition.position || _cam.orthographicSize != endPosition.camOrthSize)
        { 
            time += Time.deltaTime;
            _cam.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, time);
            _cam.orthographicSize = Mathf.Lerp(startPosition.camOrthSize, endPosition.camOrthSize, time);
             yield return null;
        }
    }
}
