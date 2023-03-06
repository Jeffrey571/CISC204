using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cardcolors {RED = 1,YELLOW = 2,GREEN = 3,BLUE = 4}

public class CardController : MonoBehaviour
{
    private MemoryGameManager mgm;
    private bool isflipped = false;
    public bool IsFlipped { get => isflipped; private set => isflipped = value; }

    public cardcolors cardcolors
    {
        get;
        private set;
    }

    public Vector2 coordinates
    {
        get;
        private set;
    }

    public SpriteRenderer colorrend;

    // Start is called before the first frame update
    void Start()
    {
        colorrend.enabled = false;
    }

    public void Initialize(MemoryGameManager m, Vector2 c,cardcolors color)
    {
        mgm = m;
        coordinates = c;
        cardcolors = color;

        switch (cardcolors)
        {
            case cardcolors.RED:
                colorrend.color = Color.red;
                break;
            case cardcolors.YELLOW:
                colorrend.color = Color.yellow;
                break;
            case cardcolors.GREEN:
                colorrend.color = Color.green;
                break;
            case cardcolors.BLUE:
                colorrend.color = Color.blue;
                break;
        }
    }


    public void flip()
    {
        if (isflipped)
        {
            colorrend.enabled = false;
            isflipped = false;
        }
        else
        {
            colorrend.enabled = true;
            isflipped = true;
        }
        Debug.Log($"Card {gameObject.name} at position {coordinates} was flipped | IsFlipped {isflipped}!");
    }

    public bool comparecolor(cardcolors othercolor)
    {
        return this.cardcolors == othercolor;
    }

    public void updateposition(Vector2 newposition)
    {
        transform.position = newposition *2;
        coordinates = newposition;
    }
    public void OnMouseDown()
    {
        mgm.handlecardclick(this);
    }
}
