using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Select : MonoBehaviour
{
    [SerializeField] private AppManager scriptAppManager;
    [SerializeField] private Rotation[] scriptRotation;
    [SerializeField] private Transform[] transformTarget;
    [SerializeField] private Transform cameraMovePosition;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private Animator[] animatorCircle;
    [SerializeField] private Animator animatorIntro;
    [SerializeField] private Light[] directionalLight;
    [SerializeField] private Sprite[] spriteTitle;
    [SerializeField] private Image imageTitle;
    [SerializeField] private Button buttonBack;
    [SerializeField] private TextMeshProUGUI textKeeper;
    [SerializeField] private TextMeshProUGUI textStone;
    [SerializeField] private TextMeshProUGUI textMystery;
    [SerializeField] private string[] stringKeeper;
    [SerializeField] private string[] stringStone;
    [SerializeField] private string[] stringMystery;
    [SerializeField] private float speedCameraMoveIn;
    [SerializeField] private float speedCameraMoveOut;
    [SerializeField] private float speedScrollKeeper;
    [SerializeField] private float speedScrollMystery;
    private RaycastHit hit;
    private AudioSource audioSource;
    private float distanceToTarget;
    private float rangeFromTarget = 0.01f;
    private float speedCameraMove;
    private int currentSelection;
    private int previousSelection;
    private int currentLocation;
    private float colorAlpha;
    private float timeMusicIntro;
    public bool isIntro;
    private bool isMusicFadeOut;
    private bool isMusicFadeIn;
    private bool isLightsDim;
    private bool isLightsBrighten;
    private bool isLightsBright;
    private bool isMoving;
    private bool isNewUIState;
    [SerializeField] private int stateUI;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        timeMusicIntro = audioSource.clip.length;
        isLightsBright = true;
        //ShowMysteryIntro();
    }

    public void ShowMysteryIntro()
    {
        isIntro = true;
        animatorIntro.SetBool("isShow", true);
    }

    void FixedUpdate()
    {
        if (currentSelection != currentLocation)
        {
            distanceToTarget = Vector3.Distance(transform.position, transformTarget[currentSelection].position);

            if (distanceToTarget > rangeFromTarget)
            {
                var step = speedCameraMove * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, transformTarget[currentSelection].position, step);
            }
            else
            {
                currentLocation = currentSelection;
                isMoving = false;

                if (currentSelection == 0)
                {
                    isLightsDim = false;
                    isLightsBrighten = true;
                }
                else
                {
                    buttonBack.enabled = true;
                    stateUI = 1;
                    imageTitle.sprite = spriteTitle[currentSelection - 1];
                    scriptAppManager.ToggleNextButtonOn();
                    textKeeper.text = stringKeeper[currentSelection - 1];
                }
            }
        }

        if (stateUI == 1 && imageTitle.color.a < 1.0f && currentSelection > 0)
        {
            colorAlpha += 0.001f;
            Color newColor = new Color(1.0f, 1.0f, 1.0f, colorAlpha);
            imageTitle.color = newColor;
        }
        else if (stateUI == 1 && imageTitle.color.a >= 1.0f && currentSelection > 0)
        {
            stateUI = 2;
            colorAlpha = 0f;
            isNewUIState = true;
        }
        
        if (stateUI == 2 && isNewUIState && currentSelection > 0 && textKeeper.color.a < 1.0f)
        {
            colorAlpha += 0.001f;
            Color newColor = new Color(1.0f, 1.0f, 1.0f, colorAlpha);
            textKeeper.color = newColor;
        }
        else if (stateUI == 2 && currentSelection > 0 && textKeeper.color.a >= 1.0f)
        {
            stateUI = 3;
            isNewUIState = true;
        }

        if (stateUI == 3 && isNewUIState && currentSelection > 0)
        {
            isNewUIState = false;
            StartCoroutine(ScrollTextStone());
        }

        if (stateUI == 4 && isNewUIState && currentSelection > 0)
        {
            isNewUIState = false;
            StartCoroutine(ScrollTextMystery());
        }

        if (stateUI == 5 && imageTitle.color.a > 0f)
        {
            Color newColor = new Color(1.0f, 1.0f, 1.0f, 0f);
            imageTitle.color = newColor;
            textKeeper.color = newColor;
        }
        else if (stateUI == 5 && imageTitle.color.a <= 0)
        {
            stateUI = 0;
            colorAlpha = 0;
        }

        if (isMusicFadeOut && audioSource.volume > 0f)
        {
            audioSource.volume -= 0.01f;
        }
        else if (isMusicFadeOut && audioSource.volume <= 0f)
        {
            isMusicFadeOut = false;
            isMusicFadeIn = true;
            audioSource.clip = music[currentSelection];
            audioSource.Play();
        }

        if (isMusicFadeIn && audioSource.volume < 1.0f)
        {
            audioSource.volume += 0.02f;
        }
        else if (isMusicFadeIn && audioSource.volume >= 1.0f)
        {
            isMusicFadeIn = false;
        }

        if (isLightsDim)
        {
            for (int i = 0; i < directionalLight.Length; i++)
            {
                if (directionalLight[i].intensity > 0 && currentSelection - 1 != i)
                {
                    directionalLight[i].intensity -= 0.01f;
                }
            }
        }

        if (isLightsBrighten)
        {
            for (int i = 0; i < directionalLight.Length; i++)
            {
                if (directionalLight[i].intensity < 1)
                {
                    directionalLight[i].intensity += 0.02f;
                }
                else if (directionalLight[i].intensity >= 1)
                {
                    isLightsBright = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && !isMoving && !isIntro && isLightsBright)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                switch (hit.transform.tag)
                {
                    case "Target1":
                        previousSelection = currentSelection;
                        currentSelection = 1;
                        SetSelection(0);
                        break;
                    case "Target2":
                        previousSelection = currentSelection;
                        currentSelection = 2;
                        SetSelection(1);
                        break;
                    case "Target3":
                        previousSelection = currentSelection;
                        currentSelection = 3;
                        SetSelection(2);
                        break;
                    case "Target4":
                        previousSelection = currentSelection;
                        currentSelection = 4;
                        SetSelection(3);
                        break;
                    case "Target5":
                        previousSelection = currentSelection;
                        currentSelection = 5;
                        SetSelection(4);
                        break;
                    case "Target6":
                        previousSelection = currentSelection;
                        currentSelection = 6;
                        SetSelection(5);
                        break;
                    case "Target7":
                        previousSelection = currentSelection;
                        currentSelection = 7;
                        SetSelection(6);
                        break;
                }

                speedCameraMove = speedCameraMoveIn;
            }
        }
    }

    private IEnumerator ScrollTextStone()
    {
        for (int i = 0; i < stringStone[currentSelection - 1].Length; i++)
        {
            textStone.text += stringStone[currentSelection - 1][i];
            yield return new WaitForSeconds(speedScrollMystery);

            if (currentSelection == 0)
            {
                break;
            }
        }

        if (currentSelection > 0)
        {
            stateUI = 4;
            isNewUIState = true;
        }
    }

    private IEnumerator ScrollTextMystery()
    {
        for (int i = 0; i < stringMystery[currentSelection - 1].Length; i++)
        {
            textMystery.text += stringMystery[currentSelection - 1][i];
            yield return new WaitForSeconds(speedScrollMystery);

            if (currentSelection == 0)
            {
                break;
            }
        }

        if (currentSelection > 0)
        {
            stateUI = 0;
        }
    }

    public void Back()
    {
        if (currentSelection > 0 && !isMoving)
        {
            animatorCircle[currentSelection - 1].SetBool("isIn", false);
            previousSelection = currentSelection;
            currentSelection = 0;
            isMusicFadeOut = true;
            isMoving = true;
            buttonBack.enabled = false;
            StopCoroutine(ScrollTextStone());
            StopCoroutine(ScrollTextMystery());
            textKeeper.text = "";
            textStone.text = "";
            textMystery.text = "";
            stateUI = 5;
            speedCameraMove = speedCameraMoveOut;
        }
    }

    private void SetSelection(int index)
    {
        scriptRotation[index].enabled = true;
        isMusicFadeOut = true;
        animatorCircle[index].SetBool("isIn", true);
        isLightsBrighten = false;
        isLightsBright = false;
        isLightsDim = true;
        isMoving = true;
    }

    public void PlayIntroMusic()
    {
        if (isIntro)
        {
            audioSource.clip = music[8];
            audioSource.Play();
            StartCoroutine(PlayRainMusic());
        }
    }

    private IEnumerator PlayRainMusic()
    {
        yield return new WaitForSeconds(timeMusicIntro - 0.5f);

        if (currentSelection == 0)
        {
            audioSource.clip = music[0];
            audioSource.Play();
        }
    }
}
