using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircumstantialCanvasDetector : MonoBehaviour
{
    public float _radius = 1.5f;
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }

    // When the object enters a collision
    public UnityEvent OnEnter = new UnityEvent();

    // When the object exits a collision
    public UnityEvent OnExit = new UnityEvent();

    private RaycastHit[] _raycastHitResults = new RaycastHit[25];
    private bool _wasInside = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchCollisions());
    }
 
    IEnumerator SearchCollisions()
    {
        while (true)
        {
            var hit = Physics.SphereCastNonAlloc(transform.position, _radius, Vector3.forward, _raycastHitResults, 9);
            //tiene que comprobar si estaba antes dentro
            //despues si esta dentro no hacer nada y si ha salido invocar onexit
            Debug.Log(hit);
            
                if (Search())
                {
                    if (!_wasInside)
                    {
                        _wasInside = true;
                        OnEnter.Invoke();
                        //iniializa
                    }
                }
                else
                {
                    if (_wasInside)
                    {
                        _wasInside = false;
                        OnExit.Invoke();
                        //Finaza
                    }
                }
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool Search()
    {
        var isInside = false;

        if (_raycastHitResults != null)
        {
            for (int i = 0; i < _raycastHitResults.Length; i++)
            {
                if (_raycastHitResults[i].transform.gameObject.layer == 9)
                {
                    isInside = true;
                    i = _raycastHitResults.Length;
                }
            }
        }

        return isInside;
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
