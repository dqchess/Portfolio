using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] life;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Text stageText;
    private GameObject player;
    private int lifeIndex;
    private int deathCounter;
    private float time;
    private bool gameOverTextShowNowPlaying;
    public float FadeTime = 4f;
    public UnityEvent playerDie; 
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        lifeIndex = 0;
        deathCounter = 0;
        gameOverTextShowNowPlaying = false;
   
    }

    private void Start()
    {
        gameOverText.alpha = 0.0f;
        retryButton.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (deathCounter == life.Length)
        {
            playerDie.Invoke();
            Cursor.visible = true;
        }

        stageText.text = stageLevelTextBuilder();
    }
    public void lifeDelete()
    {
        if (GameManager.instance.invicibility)
            return;
        if (lifeIndex < life.Length)
        {
            life[lifeIndex].gameObject.SetActive(false);
            lifeIndex++;
            deathCounter++;
        }
    }

    public void GameOverTextShow()
    {
        if (!gameOverTextShowNowPlaying)
            StartCoroutine("GameOverTextFadeIn");
    }

    IEnumerator GameOverTextFadeIn()
    {
        gameOverTextShowNowPlaying = true;
        gameOverText.text = GameOverTextBuilder();
        Color gameOverTextColor = gameOverText.color;
        time = 0f;

        while (gameOverTextColor.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            gameOverTextColor.a = Mathf.Lerp(0f, 1f, time);
            gameOverText.color = gameOverTextColor;
            yield return null;
        }
        player.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(true);
    }

    private string GameOverTextBuilder()
    {
        StringBuilder GameOverTextBuilder = new StringBuilder();
        string playTime = GameManager.instance.playTime.ToString("00.00").Replace(".", ":");
        GameOverTextBuilder.Append("Game Over\n");
        GameOverTextBuilder.Append(playTime);
        return GameOverTextBuilder.ToString();
    }

    private string stageLevelTextBuilder()
    {
        StringBuilder stageLevelTextBuilder = new StringBuilder();
        string stageLevel = GameManager.instance.stageLevel.ToString();

        stageLevelTextBuilder.Append("STAGE ");
        stageLevelTextBuilder.Append(stageLevel);
        return stageLevelTextBuilder.ToString();
    }
}
