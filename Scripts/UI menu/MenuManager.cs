using UnityEngine;

public class MenuManager : MonoBehaviour //Script for Menu manager
{
    public Panel currentPanel;

    private void Start() //on start
    {
        SetupPanels();
    }

    private void SetupPanels() //get all panels into panel list and show the current pannel
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels) 
        {
            panel.Setup(this);

            currentPanel.Show();
        }

    }

    public void startGame()// if game start hide canvas
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;

    }

    public void endGame() //exit application
    {
        Application.Quit();
    }

    public void SetCurrent(Panel newPanel) //switch between current panel
    {
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }
}