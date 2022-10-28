using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Control : MonoBehaviour
{
    public int cardNumberOfSingleline; // 한 줄의 카드 개수
    public int horizontalSpacing;
    public int verticalSpacing;
    public int indexSpriteBePrinted; // 각 카드에 출력할 Sprite 인덱스
    public int preOpenedIndex; // 이전에 오픈된 카드의 인덱스
    public int findCardNum; // 맞춘 카드의 수
    public CardFlip preOpenedObj;
    public CardFlip NowOpenedObj;
    public Vector3 centerPos; // 2차원 카드를 출력할 좌하단 좌표
    public GameObject basic_Card; // 카드 prefab
    public List<List<GameObject>> Cards; // 각 카드의 object 2차원 리스트
    public List<Sprite> cardSprites; // 전체 Sprite 리스트, 유니티 창에서 초기화
    public List<KeyValuePair<int, Sprite>> usingCardSprites; // 게임에서 사용할 sprite의 리스트
    public GameManager gameManager;

    void Start()
    {
        preOpenedObj = null;
        cardNumberOfSingleline = 6;
        horizontalSpacing = 2;
        verticalSpacing = 2;
        indexSpriteBePrinted = 0;
        preOpenedIndex = -1;
        findCardNum = 0;
        centerPos = gameObject.transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Cards = new List<List<GameObject>>();

        // 전체 Sprite에서 사용할 Sprite를 usingCardSprites에 저장
        usingCardSprites = getUsingCards(cardSprites);

        // Cards 초기화
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            List<GameObject> templist = new List<GameObject>();
            for(int j =0; j < cardNumberOfSingleline; j++)
            {
                templist.Add(null);
            }        
            Cards.Add(templist);
        }

        // Create card and connect script
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            for (int j = 0; j < cardNumberOfSingleline; j++)
            {
                Vector3 deltaPos = new Vector3((-1*(cardNumberOfSingleline - 1) + 2*j)* horizontalSpacing, ((cardNumberOfSingleline - 1) - 2 * i) * verticalSpacing, 0);
                Vector3 thisCardPos = centerPos + deltaPos;
                Cards[i][j] = Instantiate(basic_Card, thisCardPos, Quaternion.identity);
                Cards[i][j].AddComponent<CardFlip>();
                Cards[i][j].GetComponent<CardFlip>().init(indexSpriteBePrinted++);
            }
        }
    }

    void Update()
    {
    }

    /*
     * 전체 카드 Sprite에서 필요한 카드 Sprite를 random으로 선택합니다.
     *  100개의 Sprite가 존재하고, 6*6의 카드를 선택할때 다음의 과정에 따라 카드를 선택합니다.
     *  1. 100개의 Sprite를 무작위로 섞습니다.
     *  2. 0~35의 인덱스를 제외한 나머지 Sprite를 제거합니다.
     *  3. 0~35의 Sprite를 인덱스와 함께 1쌍을 더 생성하여 Pair List로 저장합니다.
     *  4. Pair를 랜덤한 순서로 바꾼뒤 pair List를 반환합니다.
    */
    List<KeyValuePair<int, Sprite>> getUsingCards(List<Sprite> ls)
    {
        List<KeyValuePair<int, Sprite>> result = new List<KeyValuePair<int, Sprite>>();

        // Suffle,Fisher-Yates shuffle 
        for (int i = ls.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);
            Sprite temp = ls[i];
            ls[i] = ls[rnd];
            ls[rnd] = temp;
        }

        // Remove useless card
        ls.RemoveRange(0, ls.Count - ((cardNumberOfSingleline * cardNumberOfSingleline) / 2));

        // Doubles list
        for (int i = 0; i < ls.Count; i++)
        {
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
        }
        // Shuffle pair of index and Sprite
        for (int i = result.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);
            KeyValuePair<int, Sprite> temp = result[i];
            result[i] = result[rnd];
            result[rnd] = temp;
        }

        return result;
    }
    
    public void report(int spriteIndex, GameObject go)
    {
        NowOpenedObj = go.GetComponent<CardFlip>();
        // Select opened card
        if (NowOpenedObj.isCardFaceFront || NowOpenedObj.Equals(preOpenedObj))
        {
            return;
        }

        // Select first card
        if (preOpenedIndex == -1)
        {
            NowOpenedObj.flipCard(true,true);
            preOpenedIndex = NowOpenedObj.spriteIndex;
            preOpenedObj = NowOpenedObj;

            return;
        }      
        // Select second card && dismatch
        if(preOpenedIndex != NowOpenedObj.spriteIndex)
        {
            gameManager.SetPlayMode(false);
            //isPlayMode = false;
            NowOpenedObj.flipCard(false,true);
            GameObject.Find("GameManager").GetComponent<GameManager>().reportFlipResult(false);

            Invoke("BackCard", 1.5f);
        }
        // Select second card && match
        else
        {
            NowOpenedObj.flipCard(false,true);
            GameObject.Find("GameManager").GetComponent<GameManager>().reportFlipResult(true);
            preOpenedIndex = -1;
            preOpenedObj = null;
            findCardNum += 2;
            if(findCardNum == cardNumberOfSingleline* cardNumberOfSingleline)
            {
                Debug.Log("Success!!");
            }
        }
        return;
    }
    public void BackCard() {
        preOpenedObj.flipCard(false,false);
        NowOpenedObj.flipCard(true,false);
        preOpenedIndex = -1;
        preOpenedObj = null;
    }

    public int getFindCardNum()
    {
        return findCardNum;
    }


}
