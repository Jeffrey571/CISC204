using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryGameManager : MonoBehaviour
{
    CardController[,] cards = new CardController[4,4];
    public GameObject cardprefab;
    private CardController firstcardselected;
    private CardController secondcardselected;
    private bool isflipping;
    private float showtime = 0.5f;
    private int turns = 0;
    public TextMeshProUGUI turntext;
    void Start()
    {
        restart();
    }

    private void generatecardarray()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                cards[i, j] = Instantiate(cardprefab).GetComponent<CardController>();

                switch (i)
                {
                    case 0:
                        cards[i, j].Initialize(this,new Vector2(i, j), cardcolors.RED);
                        break;
                    case 1:
                        cards[i, j].Initialize(this,new Vector2(i, j), cardcolors.YELLOW);
                        break;
                    case 2:
                        cards[i, j].Initialize(this,new Vector2(i, j), cardcolors.GREEN);
                        break;
                    case 3:
                        cards[i, j].Initialize(this,new Vector2(i, j), cardcolors.BLUE);
                        break;
                }
                cards[i, j].updateposition(new Vector2(i, j));
            }
        }
    }

    private void shufflecardarray()
    {
        int shuffleSteps = 4;
        for (int i = 0; i < shuffleSteps; i++)
        {
            int x1 = Random.Range(0, 4);
            int x2 = Random.Range(0, 4);
            int y1 = Random.Range(0, 4);
            int y2 = Random.Range(0, 4);
            CardController swap1 = cards[x1, y1];
            CardController swap2 = cards[x2, y2];
            cards[x2, y2] = swap1;
            cards[x1, y1] = swap2;
            swap1.updateposition(new Vector2(x2, y2));
            swap2.updateposition(new Vector2(x1, y1));
        }
    }
    public void handlecardclick(CardController c)
    {
        if (isflipping) return;

        if(secondcardselected == null)
        {
            if(firstcardselected == null)
            {
                c.flip();
                firstcardselected = c;
            }
            else if(firstcardselected == c)
            {
                c.flip();
                firstcardselected = null;
            }
            else
            {
                c.flip();
                secondcardselected = c;
            }
        }
        if(firstcardselected != null && secondcardselected != null)
        {
            turns++;
            UpdateUI();
            if (firstcardselected.comparecolor(secondcardselected.cardcolors))
            {
                cards[(int)firstcardselected.coordinates.x, (int)firstcardselected.coordinates.y] = null;
                cards[(int)secondcardselected.coordinates.x, (int)secondcardselected.coordinates.y] = null;
                Destroy(firstcardselected.gameObject);
                Destroy(secondcardselected.gameObject);
                firstcardselected = null;
                secondcardselected = null;

            }
            else
            {
                IEnumerator coroutine = WaitToFlipBackOver();
                StartCoroutine(coroutine);
            }
        }
    }
    private IEnumerator WaitToFlipBackOver()
    {
        isflipping = true;
        yield return new WaitForSecondsRealtime(showtime);

        cards[(int)firstcardselected.coordinates.x, (int)firstcardselected.coordinates.y].flip();
        cards[(int)secondcardselected.coordinates.x, (int)secondcardselected.coordinates.y].flip();
        firstcardselected = null;
        secondcardselected = null;
        isflipping = false;

    }
    public void restart()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (cards[i, j] != null)
                {
                    Destroy(cards[i, j].gameObject);
                    cards[i, j] = null;
                }
            }
        }
        generatecardarray();
        shufflecardarray();
        turns = 0;
        UpdateUI();
    }
    private void UpdateUI()
    {
        turntext.text = "Turns: " + turns; 
    }
}
