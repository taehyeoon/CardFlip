using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Control : MonoBehaviour
{
    public int cardNumberOfSingleline; // �� ���� ī�� ����
    public int horizontalSpacing;
    public int verticalSpacing;
    public int indexSpriteBePrinted; // �� ī�忡 ����� Sprite �ε���
    public Vector3 centerPos; // 2���� ī�带 ����� �߽� ��ǥ
    public GameObject basic_Card; // ī�� prefab
    public List<List<GameObject>> Cards; // �� ī���� object 2���� ����Ʈ
    public List<Sprite> cardSprites; // ��ü Sprite ����Ʈ, ����Ƽ â���� �ʱ�ȭ
    public List<KeyValuePair<int, Sprite>> usingCardSprites; // ���ӿ��� ����� sprite�� ����Ʈ
    //public GameObject card_Flip; // cardFlip Script
    void Start()
    {
        cardNumberOfSingleline = 6;
        horizontalSpacing = 3;
        verticalSpacing = 3;
        indexSpriteBePrinted = 0;
        centerPos = new Vector3(35, 13, 0);
        Cards = new List<List<GameObject>>();

        // ��ü Sprite���� ����� Sprite�� usingCardSprites�� ����
        usingCardSprites = getUsingCards(cardSprites);

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
        for (int i = 0; i < cardNumberOfSingleline; i++)
        {
            for (int j = 0; j < cardNumberOfSingleline; j++)
            {
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

    /*
     * ��ü ī�� Sprite���� �ʿ��� ī�� Sprite�� random���� �����մϴ�.
     *  100���� Sprite�� �����ϰ�, 6*6�� ī�带 �����Ҷ� ������ ������ ���� ī�带 �����մϴ�.
     *  1. 100���� Sprite�� �������� �����ϴ�.
     *  2. 0~35�� �ε����� ������ ������ Sprite�� �����մϴ�.
     *  3. 0~35�� Sprite�� �ε����� �Բ� 1���� �� �����Ͽ� Pair List�� �����մϴ�.
     *  4. Pair�� ������ ������ �ٲ۵� pair List�� ��ȯ�մϴ�.
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

        // �ʿ��� ���� ������ ������ sprite ����
        ls.RemoveRange(0, ls.Count - ((cardNumberOfSingleline * cardNumberOfSingleline) / 2));

        // ���� Sprite�� 2���� ����
        for(int i = 0; i < ls.Count; i++)
        {
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
            result.Add(new KeyValuePair<int, Sprite>(i, ls[i]));
        }
        // �ε����� Sprite���� �����ϰ� �迭
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
        CardFlip cf = go.GetComponent<CardFlip>();
        // ī�� 180�� ȸ��


        //if �̹� ���µǾ� �ִ� ī����, �ش� �Է� ����
        if (cf.isCardFaceFront)
        {
            return;
        }
        else
        {
            cf.flipCard();
        }
        
        //if ù��° open�̸� �ش� �ε��� ��ȣ�� ù��° open���� ����
        
        //if �ι�° open�̸� ù��° open ī��� ���� ī�� �׸��� ��

            //if �ٸ� �׸��̸� ���� ī�� ���� �ϰ� 0.5�� ��� �� ù��°, �ι�° ī�� ��� close

            //if ���� �׸��̸� ���� ī�� open && ����ī�� ���� += 2

                //if ���� ī�� ���ڰ� ��ü ī����� ���ٸ� ���� ����

                //if ���� ī�� ���ڿ� ��ü ī����� �ٸ��ٸ� �ƹ� ���� ����


        return;
    }
    
}
