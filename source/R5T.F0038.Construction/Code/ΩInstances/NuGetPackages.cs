using System;


namespace R5T.F0038.Construction
{
	public class NuGetPackages : INuGetPackages
	{
		#region Infrastructure

	    public static INuGetPackages Instance { get; } = new NuGetPackages();

	    private NuGetPackages()
	    {
        }

	    #endregion
	}
}