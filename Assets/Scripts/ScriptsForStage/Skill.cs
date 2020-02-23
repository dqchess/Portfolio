using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] private Sprite[] skillIcons;
    private float skillTimer;
    private Image nowShowingSkillIcon;

    private void Awake()
    {
        nowShowingSkillIcon = GetComponent<Image>();
        nowShowingSkillIcon.enabled = false;
    }

    private void Update()
    {
        if(skillTimer >= Constants.GetNumber.skillActiveTimer)
        {
            nowShowingSkillIcon.enabled = true;
            int randomIconIndex = Random.Range(0, skillIcons.Length);
            nowShowingSkillIcon.sprite = skillIcons[randomIconIndex];
            Invoke("SkillFinish", 3f);
            skillTimer = 0f;
        }
    }

    private void SkillFinish()
    {
        nowShowingSkillIcon.enabled = false;
    }

    private void FixedUpdate()
    {
        skillTimer += Time.deltaTime;
    }

}
