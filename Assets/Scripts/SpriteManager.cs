using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] shapes;
    [SerializeField]
    private Image currentSprite;
    [SerializeField]
    private int savedSprite;

    private void Start()
    {
        Load();
    }

    public void NextSprite()
    { 
        savedSprite++;
        if (savedSprite > 15)
        {
            savedSprite = 0;
        }
        currentSprite.sprite = shapes[savedSprite];
    }

    public void PreviousSprite()
    {
    savedSprite--;
    if (savedSprite < 0)
    {
        savedSprite = 15;
    }
    currentSprite.sprite = shapes[savedSprite];
    }

public void Save()
    {
        PlayerPrefs.SetInt("currentSprite", savedSprite);
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey("currentSprite"))
        {
            currentSprite.sprite = shapes[0];
        }
        else
        {
            savedSprite = PlayerPrefs.GetInt("currentSprite");
            currentSprite.sprite = shapes[savedSprite];
        }
    }
}
