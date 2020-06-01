using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup BlackPanel;
    [SerializeField] private CanvasGroup textShow;
    [SerializeField] private float blackPanelFadeDuration;
    [SerializeField] private float textFadeDuration;
    [SerializeField] private GameObject Rocket;

    public void goToPlayScene()
    {
        StartCoroutine(wait());
    }
    private void Start()
    {
        blackPanelFadeOut();
        LeanTween.moveY(Rocket, 0, 2);
        //check if our current system info equals a desktop
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            textShow.gameObject.GetComponent<TextMeshProUGUI>().text = "PRESS W TO START";
        }
        //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            textShow.gameObject.GetComponent<TextMeshProUGUI>().text = "SWIPE UP TO START";
        }
        else
        {
            Debug.Log("Unknown Device MainMenuManager.cs 35");
        }
    }
    private void blackPanelFadeIn()
    {
        LeanTween.alphaCanvas(BlackPanel, 1, blackPanelFadeDuration);
    }
    private void blackPanelFadeOut()
    {
        LeanTween.alphaCanvas(BlackPanel, 0, blackPanelFadeDuration);
    }
    IEnumerator wait()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        blackPanelFadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex: currentScene + 1);
    }
    private void Update()
    {
        if (textShow.alpha == 0)
        {
            LeanTween.alphaCanvas(textShow, 1, textFadeDuration);
        }
        if (textShow.alpha == 1)
        {
            LeanTween.alphaCanvas(textShow, 0, textFadeDuration);
        }
    }
}
