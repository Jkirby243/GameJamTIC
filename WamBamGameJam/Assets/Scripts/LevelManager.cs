using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform subwayTransform;
    [SerializeField] private Transform levelTransform;
    [SerializeField] GameObject fadeImage;
    [SerializeField] GameObject enemySpawnerManager;
    [SerializeField] GameObject countDownText; 
    [SerializeField] int countDown = 3;
    [SerializeField] private ObjectiveManager objectiveM;
    [SerializeField] GameObject deathUI; 

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = subwayTransform.position;
        player.transform.rotation = Quaternion.identity;
        StartCoroutine(Fade("In", "subway")); //this should be moved to the level manager
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
        Cursor.visible = false;
        fadeImage.SetActive(true);
        //objectiveM.CreateNewObjective();
    } 

    public void HandlePlayerDeath()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        deathUI.SetActive(true);
    }

    public void StartFadeCoroutine(string value, string area)
    {
        StartCoroutine(Fade(value, area));
    }

    public IEnumerator Fade(string value, string nextArea)
    {
        if (value == "In" && nextArea.Contains("level"))
        {
            
            player.GetComponent<CharacterController>().enabled = true;
            var anim = fadeImage.GetComponent<Animator>();
            anim.SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            var image = fadeImage.GetComponent<Image>();
            Color currentColor = image.color;
            currentColor.a = 0;
            fadeImage.GetComponent<Image>().color = currentColor;
            
        }
        else if(value == "In" && nextArea.Contains("subway"))
        {
            objectiveM.CreateNewObjective();
            player.GetComponent<CharacterController>().enabled = true;
            var anim = fadeImage.GetComponent<Animator>();
            anim.SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            var image = fadeImage.GetComponent<Image>();
            Color currentColor = image.color;
            currentColor.a = 0;
            fadeImage.GetComponent<Image>().color = currentColor;
        }
        else
        {
            player.GetComponent<CharacterController>().enabled = false;
            var anim = fadeImage.GetComponent<Animator>();
            anim.SetTrigger("FadeOut");
            yield return new WaitForSeconds(1f);
            var image = fadeImage.GetComponent<Image>();
            Color currentColor = image.color;
            currentColor.a = 255;
            fadeImage.GetComponent<Image>().color = currentColor;
            StartCoroutine(AreaSetUp(nextArea));
        }
    }

    IEnumerator AreaSetUp(string area)
    {
        print("area: " + area);

        if (area.Contains("level"))
        {
            fadeImage.GetComponent<Image>().color = Color.black;
            int count = countDown;
            countDownText.SetActive(true);
            countDownText.GetComponent<TextMeshProUGUI>().SetText(countDown.ToString());
            yield return new WaitForSeconds(1f);

            for (int i = countDown - 1; i >= 0; i--)
            {
                count = i + 1;
                countDownText.GetComponent<TextMeshProUGUI>().SetText(count.ToString());
                yield return new WaitForSeconds(1f);
            }

            countDownText.GetComponent<TextMeshProUGUI>().SetText("Go!");
            yield return new WaitForSeconds(1f);
            enemySpawnerManager.SetActive(true);
            countDownText.SetActive(false);
            player.transform.position = levelTransform.position;
            StartCoroutine(Fade("In", "level"));
        }

        else
        {
            enemySpawnerManager.SetActive(false);
            player.transform.position = subwayTransform.position;
            player.GetComponent<PlayerHealth>().heal(10);
            StartCoroutine(Fade("In", "subway"));
        }
    }

    public void OnMainMButtonClicked(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
