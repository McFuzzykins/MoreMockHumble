using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void PlayerEnter_PlayerTargetedTrap_ReduceHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover cm = Substitute.For<ICharacterMover>();
        cm.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(cm, TrapTargetType.Player, "Normal");

        Assert.AreEqual(-1, cm.Health);
    }

    [Test]
    public void NPCEnter_NPCTargetedTrap_ReduceHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover cm = Substitute.For<ICharacterMover>();
        
        trap.HandleCharacterEntered(cm, TrapTargetType.NPC, "Normal");
        Assert.AreEqual(-1, cm.Health);
    }

    [Test]
    public void PlayerEnter_BigTrap_ReduceHealthBy10()
    {
        Trap trap = new Trap();
        ICharacterMover cm = Substitute.For<ICharacterMover>();
        cm.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(cm, TrapTargetType.Player, "Big");

        Assert.AreEqual(-10, cm.Health);
    }

    [Test]
    public void PlayerEnter_ExplosionTrap_ReduceHealthBy100()
    {
        Trap trap = new Trap();
        ICharacterMover cm = Substitute.For<ICharacterMover>();
        cm.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(cm, TrapTargetType.Player, "Explosion");

        Assert.AreEqual(-100, cm.Health);
    }
}
