using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI playerAtk;
    public TextMeshProUGUI monsterHP;
    public TextMeshProUGUI monsterAtk;
    

    public GameObject playerPanel;
    public GameObject monsterPanel;

    int numberOfDiceRolls;
    int playerTotalScore;
    int monsterTotalScore;
    public int diceCap = 9;

    public GameObject[] playerDice;
    public GameObject[] monsterDice;
    
    public int monsterHPValue;
    public int monsterAtkValue;
    public int playerHPValue;
    public int playerAtkValue;

    public static GameManager gm { get; private set; }

    private void Awake()
    {
        numberOfDiceRolls = 1;
        if (gm != null && gm != this)
        {
            Destroy(this);
            DontDestroyOnLoad(GameManager.gm);
        }
        else
        {
            gm = this;

            DontDestroyOnLoad(GameManager.gm);

            

        }
        

    }
    private void Start()
    {

        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        counterText.text = numberOfDiceRolls.ToString();
        PlayerHP();
        PlayerAtk();
        MonsterHP();
        MonsterAtk();
    }


    public void RollTheDice() //return total dice rolls
    {
        playerTotalScore = 0; // resetlendi
        monsterTotalScore = 0;

        foreach (Transform child in playerPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in monsterPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i =0; i< numberOfDiceRolls; i++)
        {
            int rand1 = Random.Range(1, 7);
            int rand2 = Random.Range(1, 7);
            
            playerTotalScore += rand1;
            monsterTotalScore += rand2;

            StartCoroutine(FadeIn(rand1, rand2));

            //Debug.Log("Gelen zar " + rand + " Yeni Total " + playerTotalScore);
        }
  
    }

    IEnumerator FadeIn(int a, int b)
    {
        GameObject pDiceTemp = Instantiate(playerDice[a - 1], transform.position, transform.rotation, playerPanel.transform);
        GameObject mDiceTemp = Instantiate(monsterDice[b - 1], transform.position, transform.rotation, monsterPanel.transform);

        Color p = pDiceTemp.GetComponent<Image>().color;
        p.a = 0;
        pDiceTemp.GetComponent<Image>().color = p;

        Color m = mDiceTemp.GetComponent<Image>().color;
        m.a = 0;
        mDiceTemp.GetComponent<Image>().color = m;

        for (float f = 0.05f; f <= 1; f += 0.05f)
        {

            Color p1 = pDiceTemp.GetComponent<Image>().color;
            p1.a = f;
            pDiceTemp.GetComponent<Image>().color = p1;

            Color m1 = mDiceTemp.GetComponent<Image>().color;
            m1.a = f;
            mDiceTemp.GetComponent<Image>().color = m1;

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void IncrementCounter()
    {
        if(numberOfDiceRolls < diceCap)
        {
            numberOfDiceRolls += 1;
        }
    }

    public void DecrementCounter()
    {
        if (numberOfDiceRolls > 1)
        {
            numberOfDiceRolls -= 1;
        }
    }


    public void PlayerHP()
    {   
        playerHP.text = playerTotalScore.ToString();
    }

    public void PlayerAtk()
    {
        playerAtk.text = playerTotalScore.ToString();
    }

    public void MonsterHP()
    {
        monsterHP.text = (monsterTotalScore*10).ToString();
    }

    public void MonsterAtk()
    {
        monsterAtk.text = (monsterTotalScore*5).ToString();
    }
    public void Reset()
    {
        numberOfDiceRolls = 1;
        playerTotalScore = 0;
        monsterTotalScore = 0;
    }
    public void setValues()
    {
        monsterHPValue = monsterTotalScore * 10;
        monsterAtkValue = monsterTotalScore * 5;
        playerHPValue = playerTotalScore;
        playerAtkValue = playerTotalScore;
    }

    public void nextScene()
    {
        setValues();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}