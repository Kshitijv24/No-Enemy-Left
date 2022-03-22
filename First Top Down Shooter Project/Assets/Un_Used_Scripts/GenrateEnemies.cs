using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenrateEnemies : MonoBehaviour
{
    public GameObject[] enemy;
    public int enemyTypes;
    public int enemyNumber;

    private int enemyCount;

    private int index;
    private int xPos;
    private int yPos;
    private int[] yPosArray = new int[] { 24, -25 };
    private int[] xPosArray = new int[] { -25, 26 };

    void Start(){
        StartCoroutine(EnemyGenerateCoroutine());
    }

    IEnumerator EnemyGenerateCoroutine(){

        while(enemyCount != enemyNumber)
        {

            xPos = Random.Range(xPosArray[0], xPosArray.Length);
            yPos = Random.Range(yPosArray[0], yPosArray.Length);
            index = Random.Range(0, enemyTypes);
            

            Instantiate(enemy[index], new Vector3(xPos, yPos, transform.position.z), Quaternion.identity);

            yield return new WaitForSeconds(0.5f);

            enemyCount++;
            Debug.Log(enemyCount);
        }
    }
}
