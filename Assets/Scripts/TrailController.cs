using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public GameObject trail;
    public Bird targetBird;
    private List<GameObject> _trail;
    void Start()
    {
        _trail = new List<GameObject>();
    }

    public void SetBird(Bird bird)
    {
        targetBird = bird;
        for (int i = 0; i < _trail.Count; i++) 
        {
            Destroy(_trail[i].gameObject);
        }
        _trail.Clear();
    }

    public IEnumerator SpawnTrail()
    {
        _trail.Add(Instantiate(trail, targetBird.transform.position, Quaternion.identity));
        yield return new WaitForSeconds(0.1f);

        if (targetBird != null && targetBird.State != Bird.BirdState.HitSomething)
        {
            StartCoroutine(SpawnTrail());
        }
    }
}
