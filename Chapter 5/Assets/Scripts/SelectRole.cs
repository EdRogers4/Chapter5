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
    [SerializeField] private GameObject canvasWeapons;
    [SerializeField] private TextMeshProUGUI textRoleName;
    [SerializeField] private TextMeshProUGUI textRoleVirtues1;
    [SerializeField] private TextMeshProUGUI textRoleVirtues2;
    [SerializeField] private TextMeshProUGUI textRoleVirtues3;
    [SerializeField] private RectTransform transformRoleVirtues1;
    [SerializeField] private RectTransform transformRoleVirtues2;
    [SerializeField] private RectTransform transformRoleVirtues3;
    [SerializeField] private float[] positionRoleVirtues1;
    [SerializeField] private float[] positionRoleVirtues2;
    [SerializeField] private float[] positionRoleVirtues3;
    [SerializeField] private Button[] buttonRole;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Sprite[] spriteBanner;
    [SerializeField] private Image imageBanner;
    [SerializeField] private RectTransform transformBanner;
    [SerializeField] private RectTransform[] transformRole;
    [SerializeField] private Vector3[] positionRoleOrigin;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animatorBanner;
    [SerializeField] private Animator animatorRoleText;
    [SerializeField] private Animator animatorNext;
    [SerializeField] private Animator animatorRoleButtons;
    [SerializeField] private List<int> listRolesWithTextColorWhite;
    private int selectedPrevious;
    private int selectedCurrent;

    private void Start()
    {
        isSelectRole = true;

        for (int i = 0; i < positionRoleOrigin.Length; i++)
        {
            positionRoleOrigin[i] = transformRole[i].position;
        }

        ShowButtons();
    }

    private void ShowButtons()
    {
        animatorRoleButtons.SetBool("isShow", true);
    }

    public void Select(int index)
    {
        animatorNext.SetBool("isShow", false);
        buttonNext.interactable = false;
        selectedPrevious = selectedCurrent;
        isSelected[index] = true;
        selectedCurrent = index;
        imageBanner.sprite = spriteBanner[index];
        animatorBanner.SetBool("isHide", false);
        animatorBanner.SetBool("isStretch", false);
        animatorRoleText.SetBool("isShow", false);
        audioSource.Stop();
        textRoleVirtues1.text = "";
        textRoleVirtues2.text = "";
        textRoleVirtues3.text = "";

        if (selectedPrevious != selectedCurrent)
        {
            isSelected[selectedPrevious] = false;
        }

        transformRoleVirtues1.anchoredPosition = new Vector2(positionRoleVirtues1[selectedCurrent], transformRoleVirtues1.anchoredPosition.y);
        transformRoleVirtues2.anchoredPosition = new Vector2(positionRoleVirtues2[selectedCurrent], transformRoleVirtues2.anchoredPosition.y);
        transformRoleVirtues3.anchoredPosition = new Vector2(positionRoleVirtues3[selectedCurrent], transformRoleVirtues3.anchoredPosition.y);

        StartCoroutine(StretchBanner());
    }

    private IEnumerator StretchBanner()
    {
        yield return new WaitForSeconds(0.1f);
        animatorBanner.SetBool("isStretch", true);
        yield return new WaitForSeconds(0.5f);
        PlayMusic(selectedCurrent);
        yield return new WaitForSeconds(0.5f);
        textRoleName.text = stringRoleName[selectedCurrent];
        textRoleVirtues1.text = stringRoleVirtues1[selectedCurrent];
        textRoleVirtues2.text = stringRoleVirtues2;
        textRoleVirtues3.text = stringRoleVirtues3[selectedCurrent];
        animatorRoleText.SetBool("isShow", true);

        if (listRolesWithTextColorWhite.Contains(selectedCurrent))
        {
            animatorRoleText.SetBool("isWhite", true);
        }
        else
        {
            animatorRoleText.SetBool("isWhite", false);
        }
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = music[index];
        audioSource.Play();
    }

    public void ToggleRoleButtons(bool value)
    {
        for (int i = 0; i < buttonRole.Length; i++)
        {
            buttonRole[i].interactable = value;
        }
    }

    public void ToggleNextButtonOn()
    {
        buttonNext.interactable = true;
        animatorNext.SetBool("isShow", true);
    }

    public void NextPage()
    {
        canvasWeapons.SetActive(true);
        animatorNext.SetBool("isShow", false);
        buttonNext.interactable = false;
        animatorBanner.SetBool("isHide", true);
        animatorBanner.SetBool("isStretch", false);
        animatorRoleText.SetBool("isHide", true);
        animatorRoleText.SetBool("isShow", false);
        animatorRoleButtons.SetBool("isShow", false);
    }
}
