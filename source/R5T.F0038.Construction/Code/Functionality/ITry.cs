using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0038.Construction
{
	[FunctionalityMarker]
	public partial interface ITry : IFunctionalityMarker
	{
		public async Task GetDependencies_ForLocal()
		{
			var dependencies = await Instances.NuGetOperator.GetDependencies(
				Instances.NuGetSources.LocalSharedPackages,
				Instances.NuGetPackages.R5T_F0028,
				F0000.VersionOperator.Instance.From(1, 0, 1));

			foreach (var dependency in dependencies)
			{
				Console.WriteLine(dependency);
			}
		}

		public void GetDependencies_ForFile()
        {
			var localFilePath = @"C:\Temp\R5T.F0028.1.0.1.nupkg";

			var dependencies = Instances.NuGetOperator.GetDependencies(
				localFilePath);

            foreach (var dependency in dependencies)
            {
				Console.WriteLine(dependency);
            }
		}

		public async Task DownloadToLocalFile()
        {
			var localFilePath = @"C:\Temp\R5T.F0028.1.0.1.nupkg";

			await Instances.NuGetOperator.DownloadToFile(
				localFilePath,
				Instances.NuGetSources.LocalSharedPackages,
				Instances.NuGetPackages.R5T_F0028,
				F0000.VersionOperator.Instance.From(1, 0, 1));
        }
	}
}