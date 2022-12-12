using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerMover : MonoBehaviour
{
    public GameObject dummyPlayer1;

    public int startShootingAfterSeconds = 30;

    public int shootEverySeconds = 5;

    private IEnumerator coroutine1;

    private WeaponMobile dummyWeaponMobile;
    // Start is called before the first frame update
    void Start()
    {

        Rigidbody2D rb = dummyPlayer1.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(60, rb.velocity[1]);


        dummyWeaponMobile = dummyPlayer1.GetComponent<WeaponMobile>();

        coroutine1 = StartShooting();

        StartCoroutine(coroutine1);

    }

    public IEnumerator StartShooting()
    {

        yield return new WaitForSeconds(startShootingAfterSeconds);

        while(true)
        {
            dummyWeaponMobile.Shoot();
            yield return new WaitForSeconds(shootEverySeconds);

        }

    }

}
