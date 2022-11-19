using System;


namespace R5T.F0038.F001
{
	public class NuGetOperator : INuGetOperator
	{
		#region Infrastructure

	    public static INuGetOperator Instance { get; } = new NuGetOperator();

	    private NuGetOperator()
	    {
        }

	    #endregion
	}
}