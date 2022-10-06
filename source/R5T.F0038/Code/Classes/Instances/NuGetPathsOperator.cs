using System;


namespace R5T.F0038
{
	public class NuGetPathsOperator : INuGetPathsOperator
	{
		#region Infrastructure

	    public static INuGetPathsOperator Instance { get; } = new NuGetPathsOperator();

	    private NuGetPathsOperator()
	    {
        }

	    #endregion
	}
}