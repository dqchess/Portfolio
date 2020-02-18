
using UnityEditor;

public class Constants
{
    public float dieHP = 0f;
    public float leftLimit = -25f;
    public float rightLimit = 25f;
    public float upLimit = 25f;
    public float downLimit = -25f;
    public float maxHP = 100f;
    public float invicibilityOffTime = 1.5f;
    public float moveSpeed = 5f;
    private Constants(){}
    private static Constants instance;

    public static Constants GetNumber
    {
        get
        {
            if (instance == null)
                instance = new Constants();
            return instance;
        }
    }
    
}
