using System.Collections;
using UnityEngine;

public class Panel : MonoBehaviour //Script for ui panels
{
    private Canvas canvas;
    private MenuManager menuManager;
    private CanvasGroup group;

    private void Awake() //on awake set canvas and group
    {
        canvas = GetComponent<Canvas>();
        group = GetComponent<CanvasGroup>();
    }

    public void Setup(MenuManager menuManager) //set menu manager and hide it
    {
        this.menuManager = menuManager;
        Hide();
    }

    public void Show() //show canvas
    {
        canvas.enabled = true;
        group.alpha = 1.0f;
    }

    public void Hide() //hide canvas
    {
        StartCoroutine(Fade());
        canvas.enabled = false;
        
    }

    IEnumerator Fade() //fade canvas
    {
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.1f)
        {
            yield return null;
        }
    }
}
