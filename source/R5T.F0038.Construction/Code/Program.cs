using System;
using System.Threading.Tasks;


namespace R5T.F0038.Construction
{
    class Program
    {
        static async Task Main()
        {
            //NuGetPathsOperator.Instance.OpenNuGetCacheDirectory();

            //await Try.Instance.DownloadToLocalFile();
            //Try.Instance.GetDependencies_ForFile();
            await Try.Instance.GetDependencies_ForLocal();
        }
    }
}