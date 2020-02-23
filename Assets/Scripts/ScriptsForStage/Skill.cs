using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Skill : MonoBehaviour
{
    [SerializeField] private Sprite[] skillIcons;
    private float skillTimer;
    private Image nowShowingSkillIcon;
    public UnityEvent skill0;
    float playerBulletBeforeSkillActive;

    private void Awake()
    {
        nowShowingSkillIcon = GetComponent<Image>();
        nowShowingSkillIcon.enabled = false;
    }

    private void Update()
    {
        if (skillTimer >= Constants.GetNumber.skillActiveTimer)
        {
            nowShowingSkillIcon.enabled = true;
            int randomIconIndex = Random.Range(0, skillIcons.Length);
            nowShowingSkillIcon.sprite = skillIcons[randomIconIndex];
            ActivateSkill();
            skillTimer = 0f;
        }
    }
    
    private void FixedUpdate()
    {
        skillTimer += Time.deltaTime;
    }

    private void ActivateSkill()
    {
        #region skill num 0 - 60
        if(nowShowingSkillIcon.sprite == skillIcons[0])
        {
            skill0.Invoke();
        }
        #endregion
        Invoke("SkillFinish", 3f);
    }

    private void SkillFinish()
    {
        nowShowingSkillIcon.enabled = false;
    }
}
