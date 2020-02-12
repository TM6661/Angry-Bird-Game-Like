using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SlingShooter slingShooter;
    public List<Bird> birds;
    public List<Enemy> enemies;
    public TrailController trailController;
    public BoxCollider2D TapCollider;
    private Bird _shortBird;
    private bool _isGameEnded = false;
    private bool _isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            birds[i].OnBirdDestroyed += ChangeBird;
            birds[i].OnBirdShoot += AssignTrail;
        }

        for (int j = 0; j < enemies.Count; j++){
            enemies[j].onEnemyDestroyed += CheckGameEnd;
        }
        TapCollider.enabled = false;
        slingShooter.InitiateBird(birds[0]);
        _shortBird = birds[0];
        
    }

    private void ChangeBird()
    {
        TapCollider.enabled = false;

        if (_isGameEnded)
        {
            return;
        }

        birds.RemoveAt(0);

        if (birds.Count > 0)
        {
            slingShooter.InitiateBird(birds[0]);
        }
    }

    public void CheckGameEnd(GameObject destroyEnemy)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].gameObject == destroyEnemy)
            {
                enemies.RemoveAt(i);
                _shortBird.OnUp();
                break;
            }
        }
        if (enemies.Count == 0)
            {
                _isGameEnded = true;

                if (_isGameEnded)
                {
                    Debug.Log("Musuh Mati");
                }
            }
    }

    public void AssignTrail(Bird bird)
    {
        trailController.SetBird(bird);
        StartCoroutine(trailController.SpawnTrail());
        TapCollider.enabled = true;
    }


    void OnMouseDown() 
    {
        _isClicked = true;
        if (_shortBird != null &&_isClicked)
        {
            _shortBird.OnTap();
        }
    }

    void OnMouseUp() {
        _isClicked = false;
    }


}
