namespace Lodestone.PowerShell.UnitTests.Stubs
{
   internal class PropertyStub
   {
      public int PublicField = 5;

      internal int InternalProperty
      {
         get;
         set;
      }

      public static string StaticProperty
      {
         get;
         set;
      }
   }
}
