using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Next_Level : MonoBehaviour, IInteractable
{
    public GameObject interactionIcon;
    public Boolean levelComplete = true;
    
    public bool CanInteract()
    {
        return levelComplete;
    }


    public async void Interact()
    {
        Debug.Log("Fade start");

        await ScreenFade.Instance.FadeOut();


        SceneManager.LoadScene("Level2");

    }

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
