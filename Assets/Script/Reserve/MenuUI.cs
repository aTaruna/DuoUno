using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MenuManager.instance.WarnaBal = color;
    }

    private void Start()
    {
        ColorPicker.Init();
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitBtn()
    {
        MenuManager.instance.SaveColor();
        Application.Quit();
    }
    public void SaveColor()
    {
        MenuManager.instance.SaveColor();
    }
    public void LoadColor()
    {
        MenuManager.instance.LoadColor();
    }
}
