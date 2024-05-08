using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    bool flagfs = false;
    private void Start()
    {
        if (flagfs == false)
        {
            Screen.fullScreen = true;
            Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,Screen.fullScreen);
            flagfs = true;
        }
    }
    public void PlayGame()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionsButton()
    {
        StartCoroutine(DelayOption(0.5f));        
    }
    public void BackButton()
    {
        StartCoroutine(DelayBack(0.5f));
    }
    IEnumerator DelayOption(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        GameObject mainmenu = this.gameObject;
        mainmenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    IEnumerator DelayBack(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        GameObject mainmenu = this.gameObject;
        mainmenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
}
