using TechTalk.SpecFlow;

namespace Lodestone.PowerShell.AcceptanceTests.Transformations
{
   [Binding]
   public class GenericObjectTransformation
   {
      [StepArgumentTransformation]
      public object GenericTransform( object value )
      {
         if ( int.TryParse( value.ToString(), out int result ) )
         {
            return result;
         }

         return value;
      }
   }
}
