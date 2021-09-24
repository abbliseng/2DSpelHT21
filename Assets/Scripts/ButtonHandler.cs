using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void PauseGame() {
        Simulation.PauseGame();
    }
    // Changeing paint size with buttons
    public void IncreasePaintWidth(int step = 1) {
        Simulation.width = Simulation.width + step;
    }
    public void DecreasePaintWidth(int step = 1) {
        Simulation.width = Simulation.width - step;
    }
    // Changeing game speed with buttons
    public void IncreaseGameSpeed(int step = 1) {
        Time.timeScale = Time.timeScale + step;
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
