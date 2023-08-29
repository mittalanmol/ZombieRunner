using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameovercanvas;


    private void Start()
    {
        gameovercanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameovercanvas.enabled=true;
        Time.timeScale = 0; // stoppin timing when game ends so there is no weird contradictions
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;//to easily get the cursor instead of using the ESC button when player is dead something
        Cursor.visible = true;
    }

}
