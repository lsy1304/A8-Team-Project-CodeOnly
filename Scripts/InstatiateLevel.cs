using UnityEngine;

public class InstatiateLevel : MonoBehaviour
{
   void Start()
   {
        LevelManager.Instance.InitLevel();
        Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
   }
}
