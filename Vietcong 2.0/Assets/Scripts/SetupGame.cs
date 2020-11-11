using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{
    private List<Transform> HazardList = new List<Transform>();

    public Text CountdownText;
    public RectTransform DescriptionPanel;
    public RectTransform PlayerNames;

    public RectTransform FadeToBlackPanel;
    private int FadingSpeed = 1;
    private bool FadedToOpaque = true;

    TileManager TileManagerScript;
    Projectileshooter ProjectileShooterScript;
    Movement PlayerMovementScript;

    AudioClip PlayCountdown;
    public AudioSource CountdownSource;

    AudioClip PlayBackground;
    public AudioSource BackgroundSource;
    private float FadeAudioSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Stores the audiosource clip in the variable PlayCountdown.       
        PlayCountdown = CountdownSource.clip;
        //Stores the audiosource clip in the variable PlayBackground.
        PlayBackground = BackgroundSource.clip;
        //Plays the background music.
        BackgroundSource.Play();

        //Disables the playernames panel so the playernames won't be displayed while the description panel is still active.
        PlayerNames.gameObject.SetActive(false);

        //Adds all the children components from the parent to the array.
        Transform[] TempHazard = GetComponentsInChildren<Transform>();

        //Goes over each item in the variable TempHazard and adds it to the list HazardList.
        foreach (Transform hazard in TempHazard)
        {
            //Checking if any of the items in the array TempHazard has the script TileManager attached to itself, if so add it to the HazardList.
            if (hazard.GetComponent<TileManager>())
            {
                HazardList.Add(hazard);
            }
            //Checking if any of the items in the array TempHazard has the script Projectileshooter attached to itself, if so add it to the HazardList.
            if (hazard.GetComponent<Projectileshooter>())
            {
                HazardList.Add(hazard);
            }
        }      
        //Disables all the hazards and player and starts the coroutine FadeToOpaque.
        DisableHazards();
        DisablePlayers();
        StartCoroutine(FadeToOpaque());
    }


    //This function gets called to disable all the hazards.
    public void DisableHazards()
    {
        //Goes over each item stored in the HazardList.
        foreach (Transform hazard in HazardList)
        {
            //Checks if the item in the HazardList has the TileManager script attached to itself, if so add the item to the variable TileManagerScript and disables the script.
            if (hazard.GetComponent<TileManager>())
            {
                TileManagerScript = hazard.GetComponent<TileManager>();
                TileManagerScript.enabled = false;
            }
            //Checks if the item in the HazardList has the Projectileshooter script attached to itself, if so add the item to the variable ProjectileShooterScript and disables the script.
            if (hazard.GetComponent<Projectileshooter>())
            {
                ProjectileShooterScript = hazard.GetComponent<Projectileshooter>();
                ProjectileShooterScript.enabled = false;
            }
        }
    }
    //This function gets called to disable all the players.
    public void DisablePlayers()
    {
        //Goes over each item stored in the list PlayerList and adds the GameObject in the gameobject player variable.
        foreach (GameObject player in PlayerTotal.PlayerList)
        {
            //Checks if the item in the PlayerList has the Movement script attched to itself, if so add the item to the variable PlayerMovementScript and sets the _CanMove boolean to false;
            if (player.GetComponent<Movement>())
            {
                PlayerMovementScript = player.GetComponent<Movement>();
                PlayerMovementScript._canMove = false;
            }
        }
    }

    //This function gets called to enable all the hazards.
    void EnableHazards()
    {
        //Goes over each item stored in the HazardList.
        foreach (Transform hazard in HazardList)
        {
            //Checks if the item in the HazardList has the TileManager script attached to itself, if so add the item to the variable TileManagerScript and enables the script.
            if (hazard.GetComponent<TileManager>())
            {
                TileManagerScript = hazard.GetComponent<TileManager>();
                TileManagerScript.enabled = true;
            }
            //Checks if the item in the HazardList has the Projectileshooter script attached to itself, if so add the item to the variable ProjectileShooterScript and enables the script.
            if (hazard.GetComponent<Projectileshooter>())
            {
                ProjectileShooterScript = hazard.GetComponent<Projectileshooter>();
                ProjectileShooterScript.enabled = true;
            }
        }
    }
    //This function gets called to enable all the players.
    void EnablePlayers()
    {
        //Goes over each item stored in the list PlayerList and adds the gameobject in the GameObject player variable.
        foreach (GameObject player in PlayerTotal.PlayerList)
        {
            //Checks if the item in the PlayerList has the Movement script attched to itself, if so add the item to the variable PlayerMovementScript and sets the _canMove boolean to true.
            if (player.GetComponent<Movement>())
            {
                PlayerMovementScript = player.GetComponent<Movement>();
                PlayerMovementScript._canMove = true;
            }
        }
    }

    //This function gets called when a player presses the ready button.
    public void ReadyGame()
    {
        //Disables the description panel, enables the playernames display and starts the coroutine.
        DescriptionPanel.gameObject.SetActive(false);
        PlayerNames.gameObject.SetActive(true);
        StartCoroutine(PrepareGame());
    }

    //This function gets called when the game ends. It stops all the coroutines of all the hazards and starts the coroutine FadeOutMusic. 
    public void StopGame()
    {
        foreach (Transform Hazard in HazardList)
        {
            if (Hazard.GetComponent<Projectileshooter>())
            {
                ProjectileShooterScript = Hazard.GetComponent<Projectileshooter>();
                ProjectileShooterScript.StopAllCoroutines();
            }
            if (Hazard.GetComponent<TileManager>())
            {
                TileManagerScript = Hazard.GetComponent<TileManager>();
                TileManagerScript.StopAllCoroutines();
            }
        }
        StartCoroutine(FadeOutMusic());
    }

    //Starts counting down before starting, once it hits "GO!" the function StartGame will be called.
    IEnumerator PrepareGame()
    {
        CountdownSource.PlayOneShot(PlayCountdown, 0.7f);
        CountdownText.text = "3";
        yield return new WaitForSeconds(1);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1);
        CountdownText.text = "Go!";
        EnablePlayers();
        yield return new WaitForSeconds(1);
        EnableHazards();
        CountdownText.text = "";
    }

    //This coroutine switches the panel from black to opaque.
    IEnumerator FadeToOpaque()
    {
        //Gets the color component from the panel and stores it in the FadingColor variable.
        Color FadingColor = FadeToBlackPanel.GetComponent<Image>().color;
        float FadeAmount;
        if (FadedToOpaque)
        {
            //Keeps looping until the alpha color of the image isn't smaller then 0.
            while (FadeToBlackPanel.GetComponent<Image>().color.a > 0)
            {
                FadeAmount = FadingColor.a - (FadingSpeed * Time.deltaTime);
                FadingColor = new Color(FadingColor.r, FadingColor.g, FadingColor.g, FadeAmount);
                FadeToBlackPanel.GetComponent<Image>().color = FadingColor;
                yield return null;
            }
            yield return new WaitForSeconds(FadingSpeed);
            FadedToOpaque = false;
            StartCoroutine(FadeToOpaque());
        }
    }

    //This coroutine slowly fades out the background music.
    IEnumerator FadeOutMusic()
    {
        while(BackgroundSource.volume > 0.01f)
        {
            BackgroundSource.volume -= Time.deltaTime / FadeAudioSpeed;
            yield return null;
        }     
    }
}
