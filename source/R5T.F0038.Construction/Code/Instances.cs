using System;

using R5T.F0038.F001;


namespace R5T.F0038.Construction
{
    public static class Instances
    {
        public static INuGetPackages NuGetPackages { get; } = Construction.NuGetPackages.Instance;
        public static INuGetOperator NuGetOperator { get; } = F001.NuGetOperator.Instance;
        public static INuGetSources NuGetSources { get; } = Construction.NuGetSources.Instance;
    }
}