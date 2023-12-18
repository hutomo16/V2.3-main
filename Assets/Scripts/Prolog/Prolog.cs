using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prolog : MonoBehaviour
{
    public Text teksnya;
    public string[] dialog;
    [SerializeField] private float teksSpeed = 1f;
    private int indexDialog;

    void Start()
    {
        StarDialog();
    }

    void StarDialog()
    {
        indexDialog = 0;
        StartCoroutine(Tulisan());
    }

    IEnumerator Tulisan()
    {
        foreach (char c in dialog[indexDialog].ToCharArray())
        {
            teksnya.text += c;
            yield return new WaitForSeconds(teksSpeed);
        }
    }

    void DialogNext()
    {
        if (indexDialog < dialog.Length - 1)
        {
            indexDialog++;
            teksnya.text = string.Empty;
            StartCoroutine(Tulisan());
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void NextButton()
    {
        if (teksnya.text == dialog[indexDialog])
        {
            DialogNext();
        }
        else
        {
            StopAllCoroutines();
            teksnya.text = dialog[indexDialog];
        }
    }
}
