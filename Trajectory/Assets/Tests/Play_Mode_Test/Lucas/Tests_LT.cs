using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Tests_LT
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator Tests_LTVelocityAfterFiring()
        {
            GameObject ballPrefab = Resources.Load<GameObject>("Eyeball");

            GameObject testGO = GameObject.Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            
            Rigidbody testRB = testGO.GetComponent<Rigidbody>();
            Ammo testAmmo = testGO.GetComponent<Ammo>();

            GameObject weaponPrefab = Resources.Load<GameObject>("CannonA");

            GameObject testWpn = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            Weapon testWeapon = testWpn.GetComponent<Weapon>();
            testWeapon.Start();

            float startVelocity = testRB.velocity.magnitude;
            Debug.Log("Starting velocity: "+startVelocity);

            Ammo inventory = testAmmo.PickUp();

            testWeapon.Load(ref inventory);
            Debug.Log("testWeapon Loaded");
            testWeapon.Fire();
            Debug.Log("testWeapon Fired");

            yield return new WaitForSeconds(0.1f);

            float endVelocity = testRB.velocity.magnitude;
            Debug.Log("Ending velocity: "+endVelocity);

            Assert.IsTrue(startVelocity == 0 && endVelocity > 0);
        }

        [UnityTest]
        public IEnumerator Tests_LTCooldownAfterFiring()
        {
            GameObject ballPrefab = Resources.Load<GameObject>("Eyeball");

            GameObject testGOA = GameObject.Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject testGOB = GameObject.Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            
            Rigidbody testRBA = testGOA.GetComponent<Rigidbody>();
            Rigidbody testRBB = testGOB.GetComponent<Rigidbody>();
            Ammo testAmmoA = testGOA.GetComponent<Ammo>();
            Ammo testAmmoB = testGOB.GetComponent<Ammo>();

            GameObject weaponPrefab = Resources.Load<GameObject>("CannonA");

            GameObject testWpn = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            Weapon testWeapon = testWpn.GetComponent<Weapon>();
            testWeapon.Start();

            Ammo inventory = testAmmoA.PickUp();

            testWeapon.Load(ref inventory);
            Debug.Log("testWeapon Loaded");
            testWeapon.Fire();
            Debug.Log("testWeapon Fired");

            inventory = testAmmoB.PickUp();

            testWeapon.Load(ref inventory);
            Debug.Log("testWeapon Loaded");
            testWeapon.Fire();
            Debug.Log("testWeapon Fired");

            yield return new WaitForSeconds(0.1f);

            float endVelocity = testRBB.velocity.magnitude;
            Debug.Log("Ending velocity of AmmoB: "+endVelocity);

            Assert.IsTrue(endVelocity == 0);
        }

        [UnityTest]
        public IEnumerator Tests_LTStressAmmosAndWeapons()
        {
            GameObject planePrefab = Resources.Load<GameObject>("Demo Plane");
            GameObject cameraPrefab = Resources.Load<GameObject>("Demo Camera");
            GameObject lightPrefab = Resources.Load<GameObject>("Demo Light");

            GameObject.Instantiate(planePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Instantiate(cameraPrefab, new Vector3(0, 1, 1), Quaternion.identity);
            GameObject.Instantiate(lightPrefab, new Vector3(0, 10, 0), Quaternion.identity);

            GameObject ballPrefab = Resources.Load<GameObject>("Eyeball");
            int i = 0;
            for(i = 0; i < 10000; i++) {
                GameObject weaponPrefab = Resources.Load<GameObject>("CannonA");

                GameObject testWpn = GameObject.Instantiate(weaponPrefab, new Vector3(0, 0, 0), Quaternion.identity);

                Weapon testWeapon = testWpn.GetComponent<Weapon>();
                testWeapon.Start();
                testWeapon.cooldownTime = 0f;

                GameObject testGO = GameObject.Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Ammo testAmmo = testGO.GetComponent<Ammo>();
                
                Ammo inventory = testAmmo.PickUp();

                testWeapon.Load(ref inventory);
                Debug.Log("testWeapon Loaded");
                testWeapon.Fire();
                Debug.Log("testWeapon Fired");

                yield return new WaitForSeconds(0.01f);

                float fps = 1/Time.smoothDeltaTime;
                Debug.Log("Iteration "+i+" FPS: "+1/Time.smoothDeltaTime);
                if(fps < 15) {
                    break;
                }
            }


            Assert.IsTrue(i >= 150);
        }
    }
}
