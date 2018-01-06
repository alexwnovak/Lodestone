#tool "nuget:?package=xunit.runner.console"

var target = Argument( "target", "Default" );
var configuration = Argument( "configuration", "Release" );

var buildDir = Directory( "./src/Lodestone.PowerShell/bin" ) + Directory( configuration );

//===========================================================================
// Clean Task
//===========================================================================

Task( "Clean" )
   .Does( () =>
{
   CleanDirectory( buildDir );
});

//===========================================================================
// Restore Task
//===========================================================================

Task( "RestoreNuGetPackages" )
   .IsDependentOn( "Clean" )
   .Does( () =>
{
   NuGetRestore( "./src/Lodestone.sln" );
} );

//===========================================================================
// Build Task
//===========================================================================

Task( "Build" )
   .IsDependentOn( "RestoreNuGetPackages")
   .Does( () =>
{
  MSBuild( "./src/Lodestone.sln", settings => settings.SetConfiguration( configuration ) );
} );

//===========================================================================
// Test Task
//===========================================================================

Task( "RunUnitTests" )
   .IsDependentOn( "Build" )
   .Does( () =>
{
    XUnit2( "./src/Lodestone.PowerShell.UnitTests/bin/" + Directory( configuration ) + "/*Tests*.dll" );
} );

//===========================================================================
// Create NuGet Package Task
//===========================================================================

Task( "CreatePackage" )
   .IsDependentOn( "RunUnitTests" )
   .Does( () =>
{
   CreateDirectory( "./artifacts" );
   
   var settings = new NuGetPackSettings
   {   
     OutputDirectory = "./artifacts",
     ArgumentCustomization = args => args.Append( "-Prop Configuration=" + configuration )
   };
   
   NuGetPack( "./Lodestone.PowerShell.nuspec", settings );
} );

//===========================================================================
// Default Task
//===========================================================================

Task( "Default" )
   .IsDependentOn( "RunUnitTests" );

RunTarget( target );
