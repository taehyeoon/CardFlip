using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Card_Control : MonoBehaviour
{
    public bool isPlayMode = true;
    public int cardNumberOfSingleline; // 한 줄의 카드 개수
    public int horizontalSpacing;
    public int verticalSpacing;
    public int indexSpriteBePrinted; // 각 카드에 출력할 Sprite 인덱스
    public int preOpenedIndex; // 이전에 오픈된 카드의 인덱스
    public int correctNumber; // 맞춘 카드의 수
    public CardFlip preOpenedObj;
    public CardFlip NowOpenedObj;
    public Vector3 criteriaPos; // 2차원 카드를 출력할 좌하단 좌표
    public GameObject basic_Card; // 카드 prefab
    public List<List<GameObject>> Cards; // 각 카드의 object 2차원 리스트
    public List<Sprite> cardSprites; // 전체 Sprite 리스트, 유니티 창에서 초기화
    public List<KeyValuePair<int, Sprite>> usingCardSprites; // 게임에서 사용할 sprite의 리스트
    void Start()
    {
        cardNumberOfSingleline = 6;
        horizontalSpacing = 3;
        verticalSpacing = 3;
        indexSpriteBePrinted = 0;
        preOpenedIndex = -1;
        correctNumber = 0;
        criteriaPos = new Vector3(35, 13, 0);
        preOpenedObj = null;

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

        // 카드 생성 후 Cards에 저장
        // Cards 스크립트 각 카드에 연결
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            for (int j = 0; j < cardNumberOfSingleline; j++)
            {
                Vector3 thisCardPos = criteriaPos + new Vector3(j * horizontalSpacing, i * verticalSpacing, 0);
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

        //suffle,Fisher-Yates shuffle 
        for (int i = ls.Count - 1; i > 0; i--)
        {
            int rnd = UnityEngine.Random.Range(0, i);

            Sprite temp = ls[i];
            ls[i] = ls[rnd];
            ls[rnd] = temp;
        }

        // 필요한 쌍의 개수를 제외한 sprite 제거
        ls.RemoveRange(0, ls.Count - ((cardNumberOfSingleline * cardNumberOfSingleline) / 2));

        // 같은 Sprite를 2개씩 생성
        for(int i = 0; i < ls.Count; i++)
        {
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
        }
        // 인덱스와 Sprite쌍을 랜덤하게 배열
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
        //if 이미 오픈되어 있는 카드라면, 해당 입력 무시
        if (NowOpenedObj.isCardFaceFront)
        {
            return;
        }

        //if 첫번째 open이면 해당 인덱스 번호를 첫번째 open으로 저장
        if (preOpenedIndex == -1)
        {
            // 카드 open
            NowOpenedObj.flipCard(true);
            // 카드 정보 저장
            preOpenedIndex = NowOpenedObj.spriteIndex;
            preOpenedObj = NowOpenedObj;
            return;
        }
        
        //if 두번째 open이면 첫번째 open 카드와 현재 카드 그림을 비교
            //if 다른 그림이면 현재 카드 오픈 하고 0.5초 대기 후 첫번째, 두번째 카드 모두 close
        if(preOpenedIndex != NowOpenedObj.spriteIndex)
        {
            Debug.Log("pre : " + preOpenedIndex + " present : " + NowOpenedObj.spriteIndex);
            isPlayMode = false;
            NowOpenedObj.flipCard(false);

            Invoke("BackCard", 3f);
        }
            //if 같은 그림이면 현재 카드 open && 맞춘카드 숫자 += 2
        else
        {
            Debug.Log("pre : " + preOpenedIndex + " present : " + NowOpenedObj.spriteIndex);
            NowOpenedObj.flipCard(false);
            preOpenedIndex = -1;
            preOpenedObj = null;
            correctNumber += 2;
                //if 맞춘 카드 숫자가 전체 카드수와 같다면 게임 종료
            if(correctNumber == cardNumberOfSingleline* cardNumberOfSingleline)
            {
                Debug.Log("Success!!");
            }
        }
        return;
    }
    public void BackCard() {
        preOpenedObj.flipCard(false);
        NowOpenedObj.flipCard(true);
        preOpenedIndex = -1;
        preOpenedObj = null;
    }
    public void SetPlayMode(bool state)
    {
        isPlayMode = state;
    }
    public bool GetisPlayMode()
    {
        return isPlayMode;
    }
    
}
