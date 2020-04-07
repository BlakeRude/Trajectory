using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tests_NM
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        
        [UnityTest]
        public IEnumerator Tests_NMSpeedBoundaryTest()
        {

            GameObject fieldPrefab1 = Resources.Load<GameObject>("Playground");
            GameObject.Instantiate(fieldPrefab1, new Vector3(0, 0, 0), Quaternion.identity);

            GameObject playerPrefab1 = Resources.Load<GameObject>("First Person Player");
            GameObject testPlayer1 = GameObject.Instantiate(playerPrefab1, new Vector3(0, 5, 0), Quaternion.identity);
            Player player1 = testPlayer1.GetComponent<Player>();

            int i = 1;
            for (i = 1; i < 500; i++)
            {
                testPlayer1.transform.position = new Vector3(0, 5, 0);
                player1.speed = i;
                //Debug.Log("speed:" +player1.speed);
                
                player1.moveTest();

                if (player1.transform.position.x < -6)
                {
                    Debug.Log("speed:" + player1.speed);
                    yield break;
                }
                else if(i == 499)
                {
                    Debug.Log("Test Passed i = 500");
                    Debug.Log("speed:" + (player1.speed + 1));
                    yield break;
                }
            }
            Debug.Log("FAILURE");
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator Tests_NMGravityBoundaryTest()
        {

            GameObject fieldPrefab2 = Resources.Load<GameObject>("Playground");
            GameObject.Instantiate(fieldPrefab2, new Vector3(0, 0, 0), Quaternion.identity);

            GameObject playerPrefab2 = Resources.Load<GameObject>("First Person Player");
            GameObject testPlayer2 = GameObject.Instantiate(playerPrefab2, new Vector3(0, 100, 0), Quaternion.identity);
            Player player2 = testPlayer2.GetComponent<Player>();

            player2.speed = 0;

            while (player2.transform.position.y < 1)
            {
                player2.moveTest();
            }
            if (player2.transform.position.y < 0)
            {
                Debug.Log("Test Failure: Baby Boy has slipped");
                Debug.Log("gravity:" + player2.gravity);
                yield break;
            }

            Debug.Log("Test Success: Major Tom Made It Back To Earth");
            yield break;

        }
        /*
        [UnityTest]
        public IEnumerator Tests_NMStressTest()
        {
            var T = 1 / Time.deltaTime;

            GameObject fieldPrefab3 = Resources.Load<GameObject>("Playground");
            GameObject.Instantiate(fieldPrefab3, new Vector3(0, 0, 0), Quaternion.identity);

            for(int i = 0; i < 10000; i++)
            {
                GameObject playerPrefab3 = Resources.Load<GameObject>("First Person Player");
                GameObject testPlayer3 = GameObject.Instantiate(playerPrefab3, new Vector3(0, 100, 0), Quaternion.identity);
                Player player3 = testPlayer3.GetComponent<Player>();
                T = 1 / Time.deltaTime;
                if (T < 15 )
                {
                    Debug.Log("Time =" + T);
                    Debug.Log("Number of Players Spawned =" + i);
                    break;
                }
            }
            

            yield break;

        }
        */

    }
}
