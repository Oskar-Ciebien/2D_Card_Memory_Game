using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    // Variables
    public static bool DO_NOTHING = false;

    [SerializeField] private int cardsState;
    [SerializeField] private int cardsValue;
    [SerializeField] private bool initialised = false;

    private Sprite cardBack;
    private Sprite cardFace;
    private GameObject cardsManager;

    // Card code adapted from https://github.com/pronaypeddiraju/Memory-Game/blob/master/Memory%20Game/Assets/Scripts/cardScript.cs

    // Start
    void Start()
    {
        // Set the cards state to 1 - So that the back is shown
        cardsState = 1;
        // Set cardsManager to the object with the tag CardManager
        cardsManager = GameObject.FindGameObjectWithTag("CardManager");
    } // Start - END

    // setupGraphics
    public void setupGraphics()
    {
        // Setup cardBack and cardFace
        cardBack = cardsManager.GetComponent<GameManager>().getCardBack();
        cardFace = cardsManager.GetComponent<GameManager>().getCardFace(cardsValue);

        // Call flipCard
        flipCard();
    } // setupGraphics - END

    // flip
    public void flipCard()
    {
        // If the cardsState is 0 = Face up
        if (cardsState == 0)
            // Flip the card
            cardsState = 1;
        // If the cardsState is 1 = Face down
        else if (cardsState == 1)
            // Flip the card
            cardsState = 0;

        // If the cardsState is equal to 0 = Face up and STOP is equal to false
        if (cardsState == 0 && !DO_NOTHING)
            // Set the sprite to the back of card = face down
            GetComponent<Image>().sprite = cardBack;
        // If the cardsState is equal to 1 = Face down and STOP is equal to false
        else if (cardsState == 1 && !DO_NOTHING)
            // Set the sprite to the front of the card = face up
            GetComponent<Image>().sprite = cardFace;
    } // flipCard - END

    // value
    public int value
    {
        // Get and set the cardsValue
        get { return cardsValue; }
        set { cardsValue = value; }
    } // value - END

    // state
    public int state
    {
        // Get and set the cardsState
        get { return cardsState; }
        set { cardsState = value; }
    } // state - END

    // init
    public bool init
    {
        // Get and set the initalised
        get { return initialised; }
        set { initialised = value; }
    } // init - END

    // falseCheck
    public void falseCheck()
    {
        // Start Coroutine on pause
        StartCoroutine(pause());
    } // falseCheck - END

    // pause
    IEnumerator pause()
    {
        // Wait for 1 second to let the player have a final look at the cards
        yield return new WaitForSeconds(1);
        // If the cardsState is equal to 0 = face up
        if (cardsState == 0)
            // Set the sprite to the back of the card
            GetComponent<Image>().sprite = cardBack;
        // If the cardsState is equal to 1 = face down
        else if (cardsState == 1)
            // Set the sprite to the front of the card
            GetComponent<Image>().sprite = cardFace;
        // Set DO_NOTHING to false
        DO_NOTHING = false;
    } // pause - END
}
