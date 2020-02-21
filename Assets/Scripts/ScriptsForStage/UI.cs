using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] life;
    public TextMeshProUGUI UIText;
    public Button retryButton;
    public Text stageText;
    private GameObject player;
    private int lifeIndex;
    private int deathCounter;
    private float time;
    private bool gameOverTextShowNowPlaying;
    private bool tutorialTextShowNowPlaying;
    public float FadeTime = 4f;
    public UnityEvent playerDie;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        lifeIndex = 0;
        deathCounter = 0;
        tutorialTextShowNowPlaying = false;
        gameOverTextShowNowPlaying = false;
    }
    private void Start()
    {
        TutorialTextShow();
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
        {
            gameOverTextShowNowPlaying = true;
            StartCoroutine(TextFadeIn(GameOverTextBuilder()));
            player.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(true);
        }
    }

    public void TutorialTextShow()
    {
        if (!tutorialTextShowNowPlaying)
        {
            tutorialTextShowNowPlaying = true;
            UIText.color = Color.gray;
            UIText.alpha = 1f;
            StartCoroutine(TextFadeIn(TutorialTextBuilder()));
        }
    }
    private void TutorialTextOff()
    {
        Time.timeScale = 1;
        UIText.color = Color.red;
        UIText.alpha = 0;
        tutorialTextShowNowPlaying = false;
    }
    IEnumerator TextFadeIn(string textToShow)
    {
        tutorialTextShowNowPlaying = true;
        UIText.text = textToShow;
        UIText.alpha = 0f;
        Color TextColor = UIText.color;
        time = 0f;
        while (TextColor.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            TextColor.a = Mathf.Lerp(0f, 1f, time);
            UIText.color = TextColor;
            yield return null;
        }
        Invoke("TutorialTextOff", 1f);

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
    private string TutorialTextBuilder()
    {
        StringBuilder tutorialText = new StringBuilder();
        tutorialText.Append("dir: drag\n");
        tutorialText.Append("attack: auto");
        return tutorialText.ToString();
    }
}
