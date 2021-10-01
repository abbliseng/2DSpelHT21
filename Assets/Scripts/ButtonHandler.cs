using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Simulation sim;
    public GameObject pauseMenu;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu();
        }
    }

    private void Start() {
        PauseMenu();
    }

    public void PauseMenu() {
        if (!pauseMenu.activeInHierarchy && Simulation.paused) {
            // no
        } else {
            PauseGame();
        }
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
    }

    public void PauseGame() {
        Simulation.PauseGame();
    }
    // Changeing paint size with buttons
    public void IncreasePaintWidth(int step = 1) {
        Simulation.width = Simulation.width + step;
        sim.UpdateWidthDisplay();
    }
    public void DecreasePaintWidth(int step = 1) {
        Simulation.width = Simulation.width - step;
        sim.UpdateWidthDisplay();
    }
    // Changeing game speed with buttons
    public void IncreaseGameSpeed(int step = 1) {
        if (Time.timeScale > 0) {
            Time.timeScale = Time.timeScale + step;
        }
    }
    public void DecreaseGameSpeed(int step = 1) {
        if ((Time.timeScale - step) <= 0) {
            Simulation.PauseGame();
        }
        else {
            Time.timeScale = Time.timeScale - step;
        }
    }
}
