using UnityEngine;

public class SingletonInstance : MonoBehaviour
{
    private static SingletonInstance instance;

    private void Awake()
    {
        if (instance == null)
        {
            transform.parent = null;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
