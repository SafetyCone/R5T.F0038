using System;

using R5T.T0131;


namespace R5T.F0038.Construction
{
	[ValuesMarker]
	public partial interface INuGetSources : IValuesMarker
	{
		public string LocalSharedPackages => @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Packages";
	}
}