using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Trey Klotz
 * Date: 12/13/2020
 * Description: Main controller for the game, controls msot buttons, obstacle movement, resetting, etc.
 */

public class GameController : MonoBehaviour
{
    //elements for list of possible randomly chosen obstacles for endless mode
    private Transform[] endlessElements;
    public Transform element0;
    public Transform element1;
    public Transform element2;
    public Transform element3;
    public Transform element4;
    public Transform element5;
    public Transform element6;
    public Transform element7;
    public Transform element8;
    public Transform element9;
    public Transform element10;
    public Transform element11;
    public Transform element12;

    public Button endlessMode;
    public Button regularMode;
    public Button quit;
    public PlayerController player;

    private float speed;
    private float time;
    private Vector3 direction;
    private bool bEndless;
    private bool bRegular;

    // Start is called before the first frame update
    void Start()
    {
        //assign the list of endlessElements
        endlessElements = new Transform[13];
        endlessElements[0] = element0;
        endlessElements[1] = element1;
        endlessElements[2] = element2;
        endlessElements[3] = element3;
        endlessElements[4] = element4;
        endlessElements[5] = element5;
        endlessElements[6] = element6;
        endlessElements[7] = element7;
        endlessElements[8] = element8;
        endlessElements[9] = element9;
        endlessElements[10] = element10;
        endlessElements[11] = element11;
        endlessElements[12] = element12;

        bEndless = bRegular = false;
        speed = 3.5f;
        time = 0f;
        direction.Set(0, 0, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bRegular) //simply move all objects towards the player
            this.gameObject.transform.Translate(direction * Time.deltaTime * speed);

        if (bEndless) {
            time += Time.deltaTime;

            if (1.1f < time) { //instantiate a new random element every ~1.1 seconds
                Instantiate(endlessElements[(int)Random.Range(0, 12)]);
                time = 0.0f;
            }
        }

    }

    public void onEndlessPress() {
        //if user chooses to play endless
        this.gameObject.transform.position = new Vector3(0, 100, 0); //move regular mode objects out of the way
        bEndless = true;
        player.startGame();
        endlessMode.gameObject.SetActive(false);
        regularMode.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void onRegularPress() {
        //if user chooses to play regular
        bRegular = true;
        player.startGame();
        endlessMode.gameObject.SetActive(false);
        regularMode.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    public void onQuitClick() {
        Application.Quit();
    }
}
