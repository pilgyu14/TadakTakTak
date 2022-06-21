using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private PlayerMoveComponent _playerMoveComponent;
    [SerializeField]
    private FireComponent _fireComponent;
    [SerializeField]
    private GunComponent _gunComponent;
    [SerializeField]
    private PoseComponent _poseComponent;

    private bool _isPosing = false;
    public bool IsPosing => _isPosing;

    void Start()
    {
        _playerMoveComponent.Initialize();
        _fireComponent.Initialize(_gunComponent); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPosing == true)
        {
            return;
        }
       Debug.Log("업데이트");
        _playerMoveComponent.UpdateSomething();
        _fireComponent.UpdateSomething(); 
    }
}
