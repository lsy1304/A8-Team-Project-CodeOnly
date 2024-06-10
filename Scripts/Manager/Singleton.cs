using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();

    private static bool applicationIsQuitting = false;
    public static T Instance
    {
        get
        {
            if(applicationIsQuitting)
            {
                return null;
            }
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        GameObject obj = Instantiate(Resources.Load<GameObject>($"Prefabs/{typeof(T)}"));
                        DontDestroyOnLoad(obj);
                    }
                }

                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}
