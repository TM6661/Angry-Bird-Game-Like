using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public enum BirdState { Idle, Thrown, HitSomething}
    public GameObject Parent;
    public Rigidbody2D rigidbody2d;
    public CircleCollider2D collider2d;
    public UnityAction OnBirdDestroyed = delegate {};
    public UnityAction<Bird> OnBirdShoot = delegate {};
    public BirdState State { get { return _state; } }
    private BirdState _state;
    private float _minVelocity = 0.5f;
    private bool _flagDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
        collider2d.enabled = false;
        _state = BirdState.Idle;
    }

    // Update is called once per frame
    
    void FixedUpdate() {
        if (_state == BirdState.Idle && rigidbody2d.velocity.sqrMagnitude >= _minVelocity)
        {
            // Debug.Log(rigidbody2d.velocity.sqrMagnitude);
            _state = BirdState.Thrown;
        }    

        if ((_state == BirdState.Thrown || _state == BirdState.HitSomething) && 
        rigidbody2d.velocity.sqrMagnitude < _minVelocity && !_flagDestroy)
        {
            //Hancurkan object setelah dua detik
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2));
        }
    }
    
    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    public void Shoot(Vector2 velocity, float distance, float speed)
    {
        collider2d.enabled = true;
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2d.velocity = velocity * speed * distance;
        OnBirdShoot(this);
    }

    void OnDestroy() 
    {
        if (_state == BirdState.Thrown || _state == BirdState.HitSomething)
        {
            OnBirdDestroyed();   
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        _state = BirdState.HitSomething;
    }

    public virtual void OnTap()
    {
        //Do nothing
    }

    public virtual void OnUp()
    {
        
    }
}
