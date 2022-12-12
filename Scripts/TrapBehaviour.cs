using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField]
    private TrapTargetType trapTargetType;

    private Trap trap;

    public string trapType;

    private void Awake()
    {
        trap = new Trap();
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "BigTrap")
        {
            trapType = "Big";
        }
        else if (other.gameObject.tag == "ExplosionTrap")
        {
            trapType = "Explosion";
        }
        else
        {
            trapType = "Normal";
        }

        var characterMover = other.GetComponent<ICharacterMover>();
        trap.HandleCharacterEntered(characterMover, trapTargetType, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(ICharacterMover characterMover, TrapTargetType trapTargetType, string trapType)
    {
        if (characterMover.IsPlayer)
        {
            if (trapTargetType == TrapTargetType.Player)
            {
                if (trapType == "Big")
                {
                    characterMover.Health -= 10;
                }
                else if (trapType == "Explosion")
                {
                    characterMover.Health -= 100;
                }
                else
                {
                    characterMover.Health--;
                }
            }
        }
        else
        {
            if (trapTargetType == TrapTargetType.NPC)
            {
                characterMover.Health--;
            }
        }
    }
}

public enum TrapTargetType
{
    Player,
    NPC
}
