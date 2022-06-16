using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelController : MonoBehaviour
{
    [SerializeField] Image easy;
    [SerializeField] Image medium;
    [SerializeField] Image hard;

    [SerializeField] Sprite unTicked;
    [SerializeField] Sprite ticked;

    [SerializeField] GameObject levelObject;
    private void Start()
    {
        levelObject.SetActive(false);

        if (PlayerPrefs.GetInt("level") <= 0)
        {
            SetEasyLevel();
        }

        UpdateLevel(PlayerPrefs.GetInt("level"));
    }

    public void SetEasyLevel()
    {
        PlayerPrefs.SetInt("level", 0);
        UpdateLevel(0);
    }

    public void SetMediumLevel()
    {
        PlayerPrefs.SetInt("level", 1);
        UpdateLevel(1);
    }

    public void SetHardLevel()
    {
        PlayerPrefs.SetInt("level", 2);
        UpdateLevel(2);
    }

    public void UpdateLevel(int level)
    {
        easy.sprite = unTicked;
        medium.sprite = unTicked;
        hard.sprite = unTicked;

        if (level == 0)
        {
            easy.sprite = ticked;
        }
        else if (level == 1)
        {
            medium.sprite = ticked;
        }
        else if (level == 2)
        {
            hard.sprite = ticked;
        }

        OpenLevel(false);
    }

    public void OpenLevel(bool isEnable)
    {
        levelObject.SetActive(isEnable);
    }
}
