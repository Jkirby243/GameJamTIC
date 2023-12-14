using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SubwayManager : MonoBehaviour
{

    private bool playerReady;
    private bool fadeIn; 
    [SerializeField] GameObject fadeImage;
    [SerializeField] private GameObject instructionsText;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelManager levelManager; 

    public float alpha;
    private float lerpDuration = 15f;
    private float currentTime = 0f; 

    private void Start()
    {
        //StartCoroutine(Fade("In")); //this should be moved to the level manager
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _player = other.gameObject; 
            if(other.GetComponent<WeaponsManager>().GetActiveGun() != null)
            {
                playerReady = true;
                instructionsText.SetActive(true);
                instructionsText.GetComponent<TextMeshProUGUI>().SetText("Press E to Exit");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerReady = false;
            instructionsText.SetActive(false);
        }
    }

    //IEnumerator Fade(string value)
    //{
    //    if(value == "In")
    //    {
    //        _player.GetComponent<CharacterController>().enabled = true;
    //        var anim = fadeImage.GetComponent<Animator>();
    //        anim.SetTrigger("FadeIn");
    //        yield return new WaitForSeconds(1f);
    //        var image =  fadeImage.GetComponent<Image>();
    //        Color currentColor = image.color;
    //        currentColor.a = 0;
    //        fadeImage.GetComponent<Image>().color = currentColor;
    //    }
    //    else
    //    {
            
    //        var anim = fadeImage.GetComponent<Animator>();
    //        anim.SetTrigger("FadeOut");
    //        yield return new WaitForSeconds(1f);
    //        var image = fadeImage.GetComponent<Image>();
    //        Color currentColor = image.color;
    //        currentColor.a = 255;
    //        fadeImage.GetComponent<Image>().color = currentColor;
    //    }
    //}

    //[SerializeField] private float subwayCountDownTimer;
    //[SerializeField] private float loadingTime = 60f;
    //[SerializeField] private TextMeshProUGUI countDownText; 

    //[SerializeField] private GameObject entryDoor;
    //[SerializeField] private GameObject exitDoor;

    //[SerializeField] private SubwayExitTrigger exitTrigger;

    //private bool endOfTimer; 

    //// Start is called before the first frame update
    //void Start()
    //{
    //    subwayCountDownTimer = loadingTime;

    //}

    // Update is called once per frame
    void Update()
    {

        if (playerReady && Input.GetKeyDown(KeyCode.E))
        {
            instructionsText.SetActive(false);
            levelManager.StartFadeCoroutine("Out");
        }



    }
}
