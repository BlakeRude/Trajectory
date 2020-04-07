using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tests_YL
    {
        [UnityTest]
        public IEnumerator StopBouncing()
        {
            SetupScene();
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(3);
                if (GameObject.Find("Player(Clone)").GetComponent<Rigidbody>().velocity.sqrMagnitude < .0001)
                { 
                    yield break;
                }
            }
            Assert.Fail();
        }

        [UnityTest]
        public IEnumerator StressTest()
        {
            var T = 1/Time.deltaTime;
            SetupScene();
            for (int i = 0; i < 100; i++)
            {
                
                T = 1/Time.deltaTime;
                for (int j = 0; j < 100; j++)
                {
                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player_Ship"));
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);
                if (T < 15)
                {
                    Debug.Log((i+1) * 100);
                    if (i < 10) Assert.Fail();
                    yield break;
                }  
            }
        }

        [UnityTest]
        public IEnumerator BoundaryTest()
        {
            SetupScene();
            bool flag = true;
            GameObject Clone = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player_Ship"));
            for (int i = 0; flag; i++)
            {
                Clone.GetComponent<Transform>().position = new Vector3(20f, 5f, 20f);
                Clone.GetComponent<Rigidbody>().velocity = new Vector3(-10f * i, 0, 0);
                yield return new WaitForSeconds(1);
                if (Clone.GetComponent<Transform>().position.x < -10)
                {
                    flag = false;
                    Debug.Log(i * 10);
                    if (i < 10) Assert.Fail();
                    yield break;
                    
                }
            }
            Assert.Fail();
        }

        void SetupScene()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject> ("Player_Ship"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Directional Light"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }
    }
}
