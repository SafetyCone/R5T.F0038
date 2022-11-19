using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using R5T.T0132;


namespace R5T.F0038.F001
{
	[FunctionalityMarker]
	public partial interface INuGetOperator : IFunctionalityMarker
	{
		public async Task DownloadToFile(
			string nuGetFilePath,
			string source,
			string packageID,
			Version version,
			CancellationToken cancellationToken = default)
        {
			NuGetVersion nuGetVersion = this.GetNuGetVersion(version);

			await this.DownloadToFile(
				nuGetFilePath,
				source,
				packageID,
				nuGetVersion,
				cancellationToken);
        }

		public async Task DownloadToFile(
			string nuGetFilePath,
			string source,
			string packageID,
			NuGetVersion version,
			CancellationToken cancellationToken = default)
		{
			using var fileStream = F0000.FileStreamOperator.Instance.NewWrite(
				nuGetFilePath);

			await this.DownloadToStream(
				fileStream,
				source,
				packageID,
				version,
				cancellationToken);
		}

		public async Task DownloadToStream(
			Stream stream,
			string source,
			string packageID,
			NuGetVersion version,
			CancellationToken cancellationToken = default)
		{
			ILogger logger = NullLogger.Instance;

			SourceCacheContext cacheContext = new SourceCacheContext();

			SourceRepository repository = Repository.Factory.GetCoreV3(source);

			FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

			await resource.CopyNupkgToStreamAsync(
				packageID,
				version,
				stream,
				cacheContext,
				logger,
				cancellationToken);
		}

		public async Task<bool> Exists(
			string source,
			string packageID,
			Version version,
			CancellationToken cancellationToken = default)
        {
			NuGetVersion nuGetVersion = this.GetNuGetVersion(version);

			var exists = await this.Exists(
				source,
				packageID,
				nuGetVersion,
				cancellationToken);

			return exists;
        }

		public async Task<bool> Exists(
			string source,
			string packageID,
			NuGetVersion version,
			CancellationToken cancellationToken = default)
        {
			ILogger logger = NullLogger.Instance;

			SourceCacheContext cacheContext = new SourceCacheContext();

			SourceRepository repository = Repository.Factory.GetCoreV3(source);

			FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>(cancellationToken);

			var exists = await resource.DoesPackageExistAsync(
				packageID,
				version,
				cacheContext,
				logger,
				cancellationToken);

			return exists;
		}

		public string[] GetDependencies(
			string nupkgFilePath)
        {
			using var fileStream = F0000.FileStreamOperator.Instance.NewRead(nupkgFilePath);

			using var reader = new PackageArchiveReader(fileStream);

			NuspecReader nuspec = reader.NuspecReader;

			var dependencyGroup = nuspec.GetDependencyGroups()
				.Single();

			var dependencies = dependencyGroup.Packages
				.Select(package => package.Id)
				.ToArray();

			return dependencies;
		}

		public async Task<string[]> GetDependencies(
			string source,
			string packageID,
			Version version,
			CancellationToken cancellationToken = default)
        {
			NuGetVersion nuGetVersion = this.GetNuGetVersion(version);

			var dependencies = await this.GetDependencies(
				source,
				packageID,
				nuGetVersion,
				cancellationToken);

			return dependencies;
		}

		public async Task<string[]> GetDependencies(
			string source,
			string packageID,
			NuGetVersion version,
			CancellationToken cancellationToken = default)
        {
			ILogger logger = NullLogger.Instance;

			SourceCacheContext cacheContext = new SourceCacheContext();

			SourceRepository repository = Repository.Factory.GetCoreV3(source);

			FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>(cancellationToken);

			var dependencyInfo = await resource.GetDependencyInfoAsync(
				packageID,
				version,
				cacheContext,
				logger,
				cancellationToken);

			var dependencyGroup = dependencyInfo.DependencyGroups
				.Single();

			var dependencies = dependencyGroup.Packages
				.Select(package => package.Id)
				.ToArray();

			return dependencies;
		}

		public NuGetVersion GetNuGetVersion(Version version)
        {
			NuGetVersion nuGetVersion = new NuGetVersion(
				version.Major,
				version.Minor,
				version.Build);

			return nuGetVersion;
        }
	}
}