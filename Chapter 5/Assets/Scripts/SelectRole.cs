using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectRole : MonoBehaviour
{
    public bool isSelectRole;
    [SerializeField] private bool isIntro;
    [SerializeField] private bool[] isSelected;
    [SerializeField] private string[] stringRoleName;
    [SerializeField] private string[] stringRoleVirtues1;
    [SerializeField] private string[] stringRoleVirtues3;
    [SerializeField] private string stringRoleVirtues2;
    [SerializeField] private TextMeshProUGUI textRoleName;
    [SerializeField] private TextMeshProUGUI textRoleVirtues1;
    [SerializeField] private TextMeshProUGUI textRoleVirtues2;
    [SerializeField] private TextMeshProUGUI textRoleVirtues3;
    [SerializeField] private Sprite[] spriteBanner;
    [SerializeField] private Image imageBanner;
    [SerializeField] private RectTransform transformBanner;
    [SerializeField] private RectTransform[] transformRole;
    [SerializeField] private Vector3[] positionRoleOrigin;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animatorBanner;
    [SerializeField] private List<int> listRolesWithTextColorWhite;
    private RaycastHit hit;
    private int selectedPrevious;
    private int selectedCurrent;
    private float alphaRoleName;
    private float alphaRoleVirtues1;
    private float alphaRoleVirtues2;
    private float alphaRoleVirtues3;

    private void Start()
    {
        isSelectRole = true;

        for (int i = 0; i < positionRoleOrigin.Length; i++)
        {
            positionRoleOrigin[i] = transformRole[i].position;
        }
    }

    void Update()
    {
    }

    public void Select(int index)
    {
        selectedPrevious = selectedCurrent;
        isSelected[index] = true;
        selectedCurrent = index;
        imageBanner.sprite = spriteBanner[index];
        animatorBanner.SetBool("isStretch", false);
        audioSource.Stop();
        StopCoroutine(FadeInTextRoleName());
        StopCoroutine(FadeInTextRoleVirtues1());
        StopCoroutine(FadeInTextRoleVirtues2());
        StopCoroutine(FadeInTextRoleVirtues3());
        textRoleName.color = Color.clear;
        alphaRoleName = 0f;
        alphaRoleVirtues1 = 0f;
        alphaRoleVirtues2 = 0f;
        alphaRoleVirtues3 = 0f;
        textRoleVirtues1.text = "";
        textRoleVirtues2.text = "";
        textRoleVirtues3.text = "";
        textRoleVirtues1.color = Color.clear;
        textRoleVirtues2.color = Color.clear;
        textRoleVirtues3.color = Color.clear;

        if (selectedPrevious != selectedCurrent)
        {
            isSelected[selectedPrevious] = false;
        }

        StartCoroutine(StretchBanner());
    }

    private IEnumerator StretchBanner()
    {
        yield return new WaitForSeconds(0.1f);
        animatorBanner.SetBool("isStretch", true);
        yield return new WaitForSeconds(0.5f);
        PlayMusic(selectedCurrent);
        StartCoroutine(FadeInTextRoleName());
    }

    private IEnumerator FadeInTextRoleName()
    {
        textRoleName.text = stringRoleName[selectedCurrent];

        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(0.00392f);
            alphaRoleName += 0.0039216f;

            if (listRolesWithTextColorWhite.Contains(selectedCurrent))
            {
                textRoleName.color = new Color(1f, 1f, 1f, alphaRoleName);
            }
            else
            {
                textRoleName.color = new Color(0f, 0f, 0f, alphaRoleName);
            }
        }

        StartCoroutine(FadeInTextRoleVirtues1());
    }

    private IEnumerator FadeInTextRoleVirtues1()
    {
        textRoleVirtues1.text = stringRoleVirtues1[selectedCurrent];

        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(0.00392f);
            alphaRoleVirtues1 += 0.0039216f;

            if (listRolesWithTextColorWhite.Contains(selectedCurrent))
            {
                textRoleVirtues1.color = new Color(1f, 1f, 1f, alphaRoleVirtues1);
            }
            else
            {
                textRoleVirtues1.color = new Color(0f, 0f, 0f, alphaRoleVirtues1);
            }
        }

        StartCoroutine(FadeInTextRoleVirtues2());
    }

    private IEnumerator FadeInTextRoleVirtues2()
    {
        textRoleVirtues2.text = stringRoleVirtues2;

        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(0.00392f);
            alphaRoleVirtues2 += 0.0039216f;

            if (listRolesWithTextColorWhite.Contains(selectedCurrent))
            {
                textRoleVirtues2.color = new Color(1f, 1f, 1f, alphaRoleVirtues2);
            }
            else
            {
                textRoleVirtues2.color = new Color(0f, 0f, 0f, alphaRoleVirtues2);
            }
        }

        StartCoroutine(FadeInTextRoleVirtues3());
    }

    private IEnumerator FadeInTextRoleVirtues3()
    {
        textRoleVirtues3.text = stringRoleVirtues3[selectedCurrent];

        for (int i = 0; i < 255; i++)
        {
            yield return new WaitForSeconds(0.00392f);
            alphaRoleVirtues3 += 0.0039216f;

            if (listRolesWithTextColorWhite.Contains(selectedCurrent))
            {
                textRoleVirtues3.color = new Color(1f, 1f, 1f, alphaRoleVirtues3);
            }
            else
            {
                textRoleVirtues3.color = new Color(0f, 0f, 0f, alphaRoleVirtues3);
            }
        }
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = music[index];
        audioSource.Play();
    }
}
