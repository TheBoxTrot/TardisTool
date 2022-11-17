using Sandbox;
using static BaseDefinition.tardisparts;

public partial class BaseMechanic : BaseNetworkable
{
	public virtual BaseNetworkable WhoTriggeredMeLast { get; protected set; }
	public TimeSince TimeSinceLastTriggered { get; protected set; }
	public virtual string ControlName { get; protected set; }
	public List<BaseCondition> MyConditions = new();
	[Net] public bool Activated { get; protected set; } = false;
	public virtual bool RequiresPower { get; protected set; } = true;
	public int timestriggereddebug = 0;
	public virtual void Startup()
	{

	}


	public virtual void OnFailed()
	{

	}

	public virtual void callback( String act )
	{
		
	}

	public ent_tardis ctrl;
	public BaseCondition CheckConditions()
	{
		BaseCondition finalcondition = null;
		if ( MyConditions.Count() > 0 )
		{
			Log.Info( MyConditions.Count());
			List<BaseCondition> temp = new();
			foreach ( var conditions in MyConditions )
			{
				Log.Info( conditions );
				Log.Info( conditions.ConditionEnabled );
				if ( conditions.ConditionEnabled )
				{
					temp.Add( conditions );
				}
			}
			if ( temp.Count() > 0 )
			{
				finalcondition = temp[0];
				foreach ( var tempconditions in temp )
				{
					
					if ( tempconditions.ConditionPriority < finalcondition.ConditionPriority )
					{
						finalcondition = tempconditions;
					}
				}
			}

		}
		return finalcondition;
	}
	public virtual void Action( Entity entity, BaseNetworkable Triggerentity )
	{
		timestriggereddebug++;
		
		WhoTriggeredMeLast = Triggerentity;
		BaseCondition cond;
		cond = CheckConditions();
		Log.Info( cond );
		if ( cond != null )
		{
			if ( ConditionAction( cond, entity ) == false )
			{
				cond.Trigger( entity ,this);
			}
		}
		else DoAction(  entity );
	}
	public virtual void DoAction(Entity entity)
	{
		
	}


	public virtual bool ConditionAction( BaseCondition thecond,Entity entity )
	{
		///check if its this then trigger that else trigger this else trigger that 
		//must return false if no action is taken
		return false;

	}
}
