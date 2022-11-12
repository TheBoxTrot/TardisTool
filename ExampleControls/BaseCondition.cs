
using System.Collections.Generic;
using System;
using static BaseDefinition.tardisparts;
using System.Runtime.ConstrainedExecution;

public partial class BaseCondition : BaseNetworkable
{   /// <summary>
	/// The name of the condition
	/// </summary>
	public virtual String ConditionName { get; protected set; }
	/// <summary>
	/// The priority of the condition (Lower number is a higher priority and will be picked, 1-whatever (0 is reserved for the Power))
	/// </summary>
	public virtual int ConditionPriority { get; protected set; }
	/// <summary>
	///	The list of all the conditions this condition has assigned to it
	/// </summary>
	public List<BaseCondition> MyConditions = new();
	/// <summary>
	///	the Tardis_Brain this Condition is associated with
	/// </summary>
	public ent_tardis ctrl;
	/// <summary>
	///	Self explanatory a True or False on whether this Condition is enabled
	/// </summary>
	public virtual bool ConditionEnabled { get; set; } = false;
	/// <summary>
	/// A Function that is Called when the Tardis First Creates its Controls
	/// </summary>
	public virtual void Startup()
	{

	}
	/// <summary>
	/// A function that is Called when A mechanic or another condition triggers it
	/// </summary>
	/// <param name="entity"></param>
	public void Trigger( Entity entity )
	{
			BaseCondition cond;
			cond = CheckConditions();
			if ( cond != null )
			{
				if ( ConditionAction( cond ) == false )
				{
					cond.Trigger( entity );
				}
			}
			else DoAction( entity );
	}
	/// <summary>
	/// This Function Checks if this Condition has any predefined functions it should trigger if not then it will pass it on it its Condition (Must end the function with a return false;)
	/// </summary>
	/// <param name="thecond"></param>
	/// <returns></returns>
	public virtual bool ConditionAction( BaseCondition thecond)
	{
		///check if its this then trigger that else trigger this else trigger that 

		return false;
	}
	/// <summary>
	/// Triggers the Action
	/// </summary>
	/// <param name="entity"></param>
	public virtual void DoAction( Entity entity )
	{

	}
	/// <summary>
	/// Checks each of its condition to determine which to use
	/// </summary>
	/// <returns></returns>
	public BaseCondition CheckConditions()
	{
		BaseCondition finalcondition = null;
		if ( MyConditions.Count() > 0 )
		{
			
			List<BaseCondition> temp = new();
			foreach ( var conditions in MyConditions )
			{
				if (conditions.ConditionEnabled)
				{
					temp.Add( conditions );
				}
			}
			 finalcondition = temp[0];
			foreach ( var tempconditions in temp )
			{

				if ( tempconditions.ConditionPriority < finalcondition.ConditionPriority )
				{
					finalcondition = tempconditions;
				}
			}

		}
		return finalcondition;
	}


}
