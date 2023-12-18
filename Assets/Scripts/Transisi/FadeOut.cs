using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public GameObject FadeOutDead;
    int indexScene;

    void Start()
    {
        // Initialization code (if needed)
    }

    void Update()
    {
        // Update code (if needed)
    }

    public void FadeOutCoba()
    {
        StartCoroutine(FadeOutAndLoadNextScene());
    }

    private IEnumerator FadeOutAndLoadNextScene()
    {
        FadeOutDead.SetActive(true);
        Animator animator = FadeOutDead.GetComponent<Animator>();
        animator.SetBool("fade", true);

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(3);
    }
}
