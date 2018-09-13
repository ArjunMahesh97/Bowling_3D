using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	ActionMaster actionMaster = new ActionMaster();

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01OneStrike(){
		Assert.AreEqual(endTurn,actionMaster.Bowl(10));
		
	}
}