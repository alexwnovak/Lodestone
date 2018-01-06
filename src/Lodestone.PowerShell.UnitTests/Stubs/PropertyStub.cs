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

      public int GetterOnlyProperty
      {
         get;
      } = 0;

      private int _setterOnlyBackingField;
      public int SetterOnlyProperty
      {
         set => _setterOnlyBackingField = value;
      }

      public int ValidProperty
      {
         get;
         set;
      }
   }
}
