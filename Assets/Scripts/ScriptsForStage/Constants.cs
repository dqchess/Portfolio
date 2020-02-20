
using UnityEditor;

public class Constants
{
    public readonly float dieHP = 0f;
    public readonly float leftLimit = -25f;
    public readonly float rightLimit = 25f;
    public readonly float upLimit = 25f;
    public readonly float downLimit = -25f;
    public readonly float maxHP = 100f;
    public readonly float invicibilityOffTime = 1.5f;
    public readonly float baseATK = 100f;
    public readonly float baseBulletSpeed = 0.3f;
    public readonly float monsterBaseSpeed = 1f;//몬스터는 점점 빨라진다.
    public readonly float moveSpeed = 5f;
    public readonly float attackDelay = 1f;
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
