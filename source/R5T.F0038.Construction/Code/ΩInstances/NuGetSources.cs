using System;


namespace R5T.F0038.Construction
{
	public class NuGetSources : INuGetSources
	{
		#region Infrastructure

	    public static INuGetSources Instance { get; } = new NuGetSources();

	    private NuGetSources()
	    {
        }

	    #endregion
	}
}