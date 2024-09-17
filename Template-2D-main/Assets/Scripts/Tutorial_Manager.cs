using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public PlayerController playerController;
    private float fuerzaSaltoInicial;
    public float waitTime = 2f;
    public bool pushedButton = false;
    // Start is called before the first frame update
    void Start()
    {
        fuerzaSaltoInicial = playerController.jumpingPower;
        playerController.jumpingPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++) 
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("Horizontal") != 0)
            {
                pushedButton = true;
            }
        } else if (popUpIndex == 1)
        {
            playerController.jumpingPower = fuerzaSaltoInicial;
            if (Input.GetKeyDown(KeyCode.W))
            {
                pushedButton = true;
            }
        }else if (popUpIndex == 2)
        {
            if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
            {
                pushedButton = true;
            }
        }

        if (pushedButton)
        {
            if(waitTime <= 0)
            {
                popUpIndex++;
                pushedButton = false;
                waitTime = 2;
            }
            waitTime -= Time.deltaTime;
        }
    }
}
