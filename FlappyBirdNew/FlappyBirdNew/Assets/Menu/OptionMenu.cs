using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Toggle isFullScreen;
    private int CurrentResIndex;
    private void Start()
    {
        resolutions=Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> listoption=new List<string>();
        CurrentResIndex=0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            listoption.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(listoption);
        resolutionDropdown.value = CurrentResIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetRes()
    {
        CurrentResIndex=resolutionDropdown.value;
        Screen.SetResolution(resolutions[CurrentResIndex].width, resolutions[CurrentResIndex].height,isFullScreen.isOn);
    }
    public void BackButton()
    {
        StartCoroutine(DelayBack(0.5f));
    }
    IEnumerator DelayBack(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        GameObject Optionmenu = this.gameObject;
        Optionmenu.SetActive(false);
        Mainmenu.SetActive(true);
    }
    public void VolumeSlider(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetFullScreen()
    {
        Screen.fullScreen = isFullScreen.isOn;       
    }
}
