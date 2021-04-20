using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;

    [SerializeField] private int cardPairs;
    [SerializeField] private int cardDifferences;

    private bool init = false;
    private int pairsFound = 0;

    // Card Code adapted from https://github.com/pronaypeddiraju/Memory-Game/blob/master/Memory%20Game/Assets/Scripts/gameManager.cs

    // Update
    void Update()
    {
        // If the cards have not been initialised, initialise
        if (!init)
            initialiseCards();

        // Runs when user releases the mouse button
        if (Input.GetMouseButtonUp(0))
            // Call checkCards()
            checkCards();
    } // Update - END

    // initialiseCards
    void initialiseCards()
    {
        // Amount of card pairs
        for (int id = 0; id < cardPairs; id++)
        {
            // Amount of different cards in the game
            for (int i = 1; i < cardDifferences; i++)
            {
                // Set test to false
                bool test = false;
                // Set choice to 0
                int choice = 0;
                // While test is false
                while (!test)
                {
                    // Set choice to a random number from 0 to the amount of cards
                    choice = Random.Range(0, cards.Length);
                    // Set test 
                    test = !(cards[choice].GetComponent<CardBehaviour>().init);
                } // while - END
                // Set the cards choice to the value of i
                cards[choice].GetComponent<CardBehaviour>().value = i;
                // Set the cards choice init to true
                cards[choice].GetComponent<CardBehaviour>().init = true;
            } // for different cards - END
        } // for card pairs - END

        // For each card in the game
        foreach (GameObject card in cards)
            // Setup graphics for each card
            card.GetComponent<CardBehaviour>().setupGraphics();

        // If init is false
        if (!init)
            // Set to true
            init = true;
    } // initialiseCards - END

    // getCardBack
    public Sprite getCardBack()
    {
        return cardBack;
    } // getCardBack - END

    // getCardFace
    public Sprite getCardFace(int i)
    {
        return cardFace[i - 1];
    } // getCardFace - END

    // checkCards
    void checkCards()
    {
        // card list
        List<int> card = new List<int>();

        // Cards Length
        for (int i = 0; i < cards.Length; i++)
        {
            // If the card is lying face up
            if (cards[i].GetComponent<CardBehaviour>().state == 1)
                // Add to cards list
                card.Add(i);
        } // for - END

        // if the count 
        if (card.Count == 2)
            // Call cardComparison with the list
            cardComparison(card);
    } // checkCards - END

    // cardComparison
    void cardComparison(List<int> card)
    {
        // Set DO_NOTHING to true, so the user can't do anything for the moment
        CardBehaviour.DO_NOTHING = true;

        // Set x to 0
        int x = 0;

        // If the two cards match
        if (cards[card[0]].GetComponent<CardBehaviour>().value == cards[card[1]].GetComponent<CardBehaviour>().value)
        {
            // Set x to 2
            x = 2;

            // Add pair
            pairsFound++;

            // If all pairs were found
            if(pairsFound == (cardDifferences - 1))
            {
                // Redirect player to the Main Menu
                SceneManager.LoadScene("highscores");
            } // if - END
            
        } // if - END
        
        // For the number of cards
        for (int i = 0; i < card.Count; i++)
        {
            // Set the cards state to x from CardBehaviour
            cards[card[i]].GetComponent<CardBehaviour>().state = x;
            // Call the falseCheck on the cards
            cards[card[i]].GetComponent<CardBehaviour>().falseCheck();
        } // for - END
    } // cardComparison - END
}
