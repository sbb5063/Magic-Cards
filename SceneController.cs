using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard OriginalCard;
    [SerializeField] private Sprite[] images;
    public const int gridcols = 4;
    public const int gridrows = 2;
    public const float Offsetx = 2f;
    public const float Offsety = 2.5f;
    private MemoryCard firstrevealed;
    private MemoryCard secondrevealed;
    private int score = 0;
    public Text scorelabel;

    public bool canReveal{ get { return secondrevealed == null; } }


    public void CardRevealed(MemoryCard card)
    {
        if(firstrevealed == null)
        {
            firstrevealed = card;
            scorelabel.text = "Score :" + score;
        }
        else
        {
            secondrevealed = card;
           StartCoroutine(CheckMatch());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
       int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
       numbers = ShuffleArray(numbers);
       Vector3 Startpos = OriginalCard.transform.position;
       for(int i = 0; i < gridcols; i++)
        {
            for(int j = 0; j < gridrows; j++)
            {
                MemoryCard card;
                if(i == 0 && j == 0)
               {
                  card = OriginalCard;
               }
               else
               {
                  card = Instantiate(OriginalCard) as MemoryCard;
               }

                int index = j * gridcols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posx = (Offsetx * i) + Startpos.x;
                float posy = -(Offsety * j) + Startpos.y;

                card.transform.position = new Vector3(posx, posy, Startpos.z);
            }
        }

       
    }

    IEnumerator CheckMatch()
    {
        if(firstrevealed.id == secondrevealed.id)
        {
            score++;
            scorelabel.text = "Score :" + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstrevealed.Unreveal();
            secondrevealed.Unreveal();
        }

        firstrevealed = null;
        secondrevealed = null;
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            tmp = newArray[r];
        }
        return newArray;
    }

    public void Restart()
    {
        Application.LoadLevel("test");
    }

}
