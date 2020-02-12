using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    [SerializeField]
    public float _boostForce = 100;
    public bool _hasBoost = false;

    public void Boost()
    {
        if (State == BirdState.Thrown && !_hasBoost)
        {
            rigidbody2d.AddForce(rigidbody2d.velocity * _boostForce);
            _hasBoost = true;
            Debug.Log("Cepet");
        }
    }

    public override void OnTap()
    {
        
        Boost();
    }

    public override void OnUp()
    {
        Release();
    }

    private void Release()
    {
        _hasBoost = false;
    }
}
