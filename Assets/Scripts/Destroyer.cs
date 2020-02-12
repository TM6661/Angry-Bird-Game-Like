using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col) {
        string tag = col.gameObject.tag;

        if (tag == "Bird" || tag == "Enemy" || tag == "Obstacle")
        {
            // StartCoroutine(WaitForDead(5));
            Destroy(col.gameObject);
        }
    }

    // public IEnumerator WaitForDead(float second)
    // {
    //     yield return new WaitForSeconds(second);
    //     OnDestroy(Tag);
    // }

    // public void OnDestroy(Collider2D col) {
    //     Destroy(Tag.gameObject);
    // }
}
