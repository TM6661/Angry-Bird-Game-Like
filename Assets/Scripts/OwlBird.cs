using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    [SerializeField]
    public bool _hasResize = false;

    public void Resize()
    {
        if (State == BirdState.Thrown && !_hasResize)
        {
            this.gameObject.transform.localScale = Vector2.Scale(new Vector2(1.5f,1.5f), new Vector2(1.5f,1.5f));
            _hasResize = true;
            Debug.Log("Gede");
        }
    }

    public override void OnTap()
    {
        
        Resize();
    }

    public override void OnUp()
    {
        Release();
    }

    private void Release()
    {
        _hasResize = false;
    }
}
