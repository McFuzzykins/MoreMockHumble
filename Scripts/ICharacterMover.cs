using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterMover
{
    int Health { get; set; }
    bool IsPlayer { get; }
}
