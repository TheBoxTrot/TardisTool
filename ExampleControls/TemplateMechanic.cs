using Sandbox;
using static ent_tardis;

partial class TemplateMechanic : BaseMechanic
{

	public override string ControlName { get; protected set; } = "TemplateMechanic";
	public override bool RequiresPower { get; protected set; } = false;
	public override void Startup()
	{
	}
	public override void callback( String CallBackMessage )
	{

		if ( CallBackMessage == "message" )
		{


		}
	}
	public override bool ConditionAction( BaseCondition thecond, Entity entity )
	{
		///check if its this then trigger that else trigger this else trigger that 
		//must return false if no action is taken
		if ( thecond.ConditionName == "name" )
		{
			//do something
			return true;
		}
		return false;

	}
	public override void DoAction( Entity entity )
	{
		///add all the functions you want here
	}
	
}
