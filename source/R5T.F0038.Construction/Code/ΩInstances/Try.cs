using System;


namespace R5T.F0038.Construction
{
	public class Try : ITry
	{
		#region Infrastructure

	    public static ITry Instance { get; } = new Try();

	    private Try()
	    {
        }

	    #endregion
	}
}