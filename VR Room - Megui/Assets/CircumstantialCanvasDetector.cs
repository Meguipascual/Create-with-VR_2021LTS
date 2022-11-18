using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CircumstantialCanvasDetector : MonoBehaviour
{
    public float _radius = 1.5f;
    public float _maxDistance = 1.5f;
    public LayerMask _layer;
    [Serializable] public class CollisionEvent : UnityEvent<Collision> { }

    // When the object enters a collision
    public UnityEvent OnEnter = new UnityEvent();

    // When the object exits a collision
    public UnityEvent OnExit = new UnityEvent();

    private RaycastHit[] _raycastHitResults;
    private int _countRayHitResults;
    private bool _wasInside = false;

    // Start is called before the first frame update
    void Start()
    {
        _raycastHitResults = new RaycastHit[200];
        StartCoroutine(SearchCollisions());
    }
 
    IEnumerator SearchCollisions()
    {
        while (true)
        {
            _countRayHitResults = Physics.SphereCastNonAlloc(transform.position, _radius, transform.forward, _raycastHitResults, _maxDistance, _layer);
            //tiene que comprobar si estaba antes dentro
            //despues si esta dentro no hacer nada y si ha salido invocar onexit
            
            
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

        
        for (int i = 0; i < _countRayHitResults; i++)
        {
            if (_raycastHitResults != null)
            {
                Debug.Log(_raycastHitResults[i].transform.name);
                if (_raycastHitResults[i].transform.CompareTag("Player"))
                {
                    Debug.Log("see the player");
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
