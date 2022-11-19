using System;

using R5T.T0131;


namespace R5T.F0038
{
	[ValuesMarker]
	public partial interface IDirectoryPaths : IValuesMarker
	{
		public string LocalNuGetPackagesDirectory => @"%UserProfile%\.nuget\packages";
	}
}