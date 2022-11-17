using Sandbox;

public partial class BaseCallBack : BaseNetworkable
{
	/// <summary>
	/// This is the name of the callback used for mechanics to find the callback
	/// </summary>
	public virtual string CallBackName { get; protected set; }
	/// <summary>
	/// This is the List of all the mechanics that are using this callback
	/// </summary>
	public List<BaseMechanic> MyMechanics = new();

	/// <summary>
	/// This is the List of all the parts that are using this callback
	/// </summary>
	public List<ITardisPart> MyParts = new();


	public ent_tardis ctrl;
	public void Add ( BaseMechanic Mechanic)
	{
		MyMechanics.Add( Mechanic );
	}
	public void Add( String Mechanic )
	{
		var mec = ctrl.GetMechanic( Mechanic );
		if ( Mechanic != null)
		MyMechanics.Add( mec );
	}
	public void Remove( BaseMechanic Mechanic )
	{
		MyMechanics.Remove( Mechanic );
	}
	public int Count()
	{
		return MyMechanics.Count();
	}
	public void Remove( String Mechanic )
	{
		var mec = ctrl.GetMechanic( Mechanic );
		if ( Mechanic != null )
			MyMechanics.Remove( mec );
	}
	public List<BaseMechanic> GetMechanicList()
	{
		return MyMechanics;
	}
	public List<ITardisPart> GetPartsList()
	{
		return MyParts;
	}
	public String GetName()
	{
		return CallBackName;
	}
}
