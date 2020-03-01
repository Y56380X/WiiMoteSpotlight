var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  StartProcess("swig", "-csharp ./swig/xwiimote.i");
  StartProcess("gcc", "-c -fpic ./swig/xwiimote_wrap.c -o ./swig/xwiimote.o");
  StartProcess("gcc", "-shared ./swig/xwiimote.o -o ./swig/libxwiimote.so");
  CopyFiles("./swig/*.cs", "./src/WiiMoteSpotlight.Lib.XWiiMote/Swig");
});

RunTarget(target);