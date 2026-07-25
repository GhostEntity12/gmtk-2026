

public abstract class EnemyState
{
	public abstract void Enter();

	public abstract void Exit();

	public abstract void Tick(Enemy e);
}

public class RoamingEnemyState : EnemyState
{
	public override void Enter()
	{
		throw new System.NotImplementedException();
	}

	public override void Exit()
	{
		throw new System.NotImplementedException();
	}

	public override void Tick(Enemy e)
	{
		// Wander between waypoints

		if (e.PlayerInViewCone)
		{
			//transition
		}
	}
}
