var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  StartProcess("swig", "-csharp ./swig/xwiimote.i");
  CopyFiles("./swig/*.cs", "./src/WiiMoteSpotlight.Lib.XWiiMote/Swig");
});

RunTarget(target);