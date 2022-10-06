using System;

using R5T.T0132;


namespace R5T.F0038
{
	[FunctionalityMarker]
	public partial interface INuGetPathsOperator : IFunctionalityMarker
	{
		public void OpenNuGetCacheDirectory()
        {
			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(@"%UserProfile%\.nuget\packages");
        }
	}
}