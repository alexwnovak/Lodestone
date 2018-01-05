namespace Lodestone.PowerShell.Internal
{
   internal static class Resources
   {
      public const string MissingCmdletAttribute = "Type {0} does not have a Cmdlet attribute--is this a PowerShell Cmdlet?";
      public const string MessageCmdletBaseType = "Type {0} does not inherit Cmdlet or PSCmdlet--is this a PowerShell Cmdlet?";
      public const string NonPublicCmdlet = "Type {0} must be public to be a viable Cmdlet";
   }
}
