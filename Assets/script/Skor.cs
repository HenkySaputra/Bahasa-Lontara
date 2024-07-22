using UnityEngine;

public class Skor : MonoBehaviour
{
    public static Skor instance;
    public int totalSkor;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetScore()
    {
        totalSkor = 0;
    }

    public void DestroyScoreManager()
    {
        instance = null;
        Destroy(gameObject);
    }
}