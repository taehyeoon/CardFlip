using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Control : MonoBehaviour
{
    public int cardNumberOfSingleline;
    public int horizontalSpacing;
    public int verticalSpacing;
    public int indexSpriteBePrinted;
    public Vector3 centerPos;
    public GameObject basic_Card;
    public List<List<GameObject>> Cards;
    public List<Sprite> cardSprites;
    public Dictionary<int, Sprite> usingCards;
    
    void Start()
    {
        cardNumberOfSingleline = 4;
        horizontalSpacing = 3;
        verticalSpacing = 3;
        indexSpriteBePrinted = 0;
        centerPos = new Vector3(35, 13, 0);
        Cards = new List<List<GameObject>>();

        /*
        ////// ���࿡ ó���� �����ϴ� ī���� ������ cardNumberOfSingleline*cardNumberOfSingleline�� ���ں��� �۴ٸ� ����ó�� �ؾ���
        // ����Ʈ�� ����
        GetShuffleList(cardSprites);
        // ����� ���� ī�常 ����� ������ ����
        //Debug.Log("initial number : " + cardSprites.Count);
        //Debug.Log("delete number :" + (cardSprites.Count - (cardNumberOfSingleline * cardNumberOfSingleline)/2));
        cardSprites.RemoveRange(0, cardSprites.Count - ((cardNumberOfSingleline * cardNumberOfSingleline)/2));

        //Debug.Log("after first suffle :" + cardSprites.Count);
        // ��� ī�带 2���� ����
        GetDoubleList(cardSprites);
        //Debug.Log("after doubling List :" + cardSprites.Count);
        GetShuffleList(cardSprites);
        //Debug.Log("after second suffle :" + cardSprites.Count);
        usingCards = 
         */

        // Cards �ʱ�ȭ
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            List<GameObject> templist = new List<GameObject>();
            for(int j =0; j < cardNumberOfSingleline; j++)
            {
                templist.Add(null);
            }        
            Cards.Add(templist);
        }

        // ī�� ���� �� Cards�� ����
        // Cards ��ũ��Ʈ �� ī�忡 ����
        //int iter = 1;
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            for (int j = 0; j < cardNumberOfSingleline; j++)
            {
                //Debug.Log("j=" + i + " k=" + j);
                //////��� ¦��*¦���� ���¿��� �� ������� ī�尡 ���� thisCardPos�� �ٽ� �����ؾ���
                //Debug.Log(iter++);
                Vector3 thisCardPos = centerPos + new Vector3((j - 2) * horizontalSpacing, (i - 2) * verticalSpacing, 0);
                Cards[i][j] = Instantiate(basic_Card, thisCardPos, Quaternion.identity);
                Cards[i][j].AddComponent<CardFlip>();
                Cards[i][j].GetComponent<CardFlip>().init(indexSpriteBePrinted++);
            }

        }


        //GameObject.Find(Cards[0][0].name).GetComponent<CardFlip>().cardFaceFront;
    }

    void Update()
    {
       
    }
    public List<T> GetShuffleList<T>(List<T> _list)
    {

        for (int i = _list.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            T temp = _list[i];
            _list[i] = _list[rnd];
            _list[rnd] = temp;
        }
        return _list;
    }
    /*
    Dictionary<int, Sprite> getUsingCards(List<Sprite> ls, int _cardNumberOfSingleline)
    {
        int half = _cardNumberOfSingleline * cardNumberOfSingleline / 2;
        //GetShuffleList(ls);
        //suffle,Fisher-Yates shuffle 
        for (int i = ls.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            Sprite temp = ls[i];
            ls[i] = ls[rnd];
            ls[rnd] = temp;
        }

        ls.RemoveRange(0, cardSprites.Count - ((cardNumberOfSingleline * cardNumberOfSingleline) / 2));
        
        Dictionary<int, Sprite> result = new Dictionary<int, Sprite>();
        
        for(int i = 0; i < ls.Count; i++)
        {
            result.Add(i,ls[i]);
            result.Add(i,ls[i]);
        }
        result.
        for (int i = result.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            KeyValuePair<int, Sprite> temp = result.
            ls[i] = ls[rnd];
            ls[rnd] = temp;
        }


        return null;
    }
    */
    
}