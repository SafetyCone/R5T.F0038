using System;


namespace R5T.F0038
{
	public class DirectoryPaths : IDirectoryPaths
	{
		#region Infrastructure

	    public static IDirectoryPaths Instance { get; } = new DirectoryPaths();

	    private DirectoryPaths()
	    {
        }

	    #endregion
	}
}