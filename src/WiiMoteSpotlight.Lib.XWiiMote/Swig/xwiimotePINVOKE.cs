//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.1
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace WiiMoteSpotlight.Lib.XWiiMote.Swig {

class xwiimotePINVOKE {

  protected class SWIGExceptionHelper {

    public delegate void ExceptionDelegate(string message);
    public delegate void ExceptionArgumentDelegate(string message, string paramName);

    static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
    static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
    static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
    static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
    static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
    static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
    static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
    static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
    static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
    static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
    static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

    static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
    static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
    static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

    [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="SWIGRegisterExceptionCallbacks_xwiimote")]
    public static extern void SWIGRegisterExceptionCallbacks_xwiimote(
                                ExceptionDelegate applicationDelegate,
                                ExceptionDelegate arithmeticDelegate,
                                ExceptionDelegate divideByZeroDelegate, 
                                ExceptionDelegate indexOutOfRangeDelegate, 
                                ExceptionDelegate invalidCastDelegate,
                                ExceptionDelegate invalidOperationDelegate,
                                ExceptionDelegate ioDelegate,
                                ExceptionDelegate nullReferenceDelegate,
                                ExceptionDelegate outOfMemoryDelegate, 
                                ExceptionDelegate overflowDelegate, 
                                ExceptionDelegate systemExceptionDelegate);

    [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_xwiimote")]
    public static extern void SWIGRegisterExceptionCallbacksArgument_xwiimote(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentNullException(paramName, message));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
      SWIGRegisterExceptionCallbacks_xwiimote(
                                applicationDelegate,
                                arithmeticDelegate,
                                divideByZeroDelegate,
                                indexOutOfRangeDelegate,
                                invalidCastDelegate,
                                invalidOperationDelegate,
                                ioDelegate,
                                nullReferenceDelegate,
                                outOfMemoryDelegate,
                                overflowDelegate,
                                systemDelegate);

      SWIGRegisterExceptionCallbacksArgument_xwiimote(
                                argumentDelegate,
                                argumentNullDelegate,
                                argumentOutOfRangeDelegate);
    }
  }

  protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

  public class SWIGPendingException {
    [global::System.ThreadStatic]
    private static global::System.Exception pendingException = null;
    private static int numExceptionsPending = 0;
    private static global::System.Object exceptionsLock = null;

    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      } 
    }

    public static void Set(global::System.Exception e) {
      if (pendingException != null)
        throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(exceptionsLock) {
        numExceptionsPending++;
      }
    }

    public static global::System.Exception Retrieve() {
      global::System.Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(exceptionsLock) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }

    static SWIGPendingException() {
      exceptionsLock = new global::System.Object();
    }
  }


  protected class SWIGStringHelper {

    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

    [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="SWIGRegisterStringCallback_xwiimote")]
    public static extern void SWIGRegisterStringCallback_xwiimote(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_xwiimote(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static xwiimotePINVOKE() {
  }


  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_new_monitor___")]
  public static extern global::System.IntPtr new_monitor(bool jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_delete_monitor___")]
  public static extern void delete_monitor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_monitor_get_fd___")]
  public static extern int monitor_get_fd(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_monitor_poll___")]
  public static extern string monitor_poll(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__type_set___")]
  public static extern void xwii_event__type_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__type_get___")]
  public static extern uint xwii_event__type_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__get_abs___")]
  public static extern void xwii_event__get_abs(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__set_abs___")]
  public static extern void xwii_event__set_abs(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__get_key___")]
  public static extern void xwii_event__get_key(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__set_key___")]
  public static extern void xwii_event__set_key(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__get_time___")]
  public static extern void xwii_event__get_time(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__set_time___")]
  public static extern void xwii_event__set_time(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_xwii_event__ir_is_valid___")]
  public static extern bool xwii_event__ir_is_valid(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_new_xwii_event____")]
  public static extern global::System.IntPtr new_xwii_event_();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_delete_xwii_event____")]
  public static extern void delete_xwii_event_(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_new_iface___")]
  public static extern global::System.IntPtr new_iface(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_delete_iface___")]
  public static extern void delete_iface(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_open___")]
  public static extern void iface_open(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_close___")]
  public static extern void iface_close(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_opened___")]
  public static extern uint iface_opened(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_syspath___")]
  public static extern string iface_get_syspath(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_fd___")]
  public static extern int iface_get_fd(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_available___")]
  public static extern uint iface_available(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_dispatch___")]
  public static extern void iface_dispatch(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_rumble___")]
  public static extern void iface_rumble(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_led___")]
  public static extern bool iface_get_led(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_set_led___")]
  public static extern void iface_set_led(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_battery___")]
  public static extern int iface_get_battery(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_devtype___")]
  public static extern string iface_get_devtype(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_extension___")]
  public static extern string iface_get_extension(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_set_mp_normalization___")]
  public static extern void iface_set_mp_normalization(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_mp_normalization___")]
  public static extern void iface_get_mp_normalization(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_iface_get_name___")]
  public static extern string iface_get_name(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_CORE_get___")]
  public static extern string NAME_CORE_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_ACCEL_get___")]
  public static extern string NAME_ACCEL_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_IR_get___")]
  public static extern string NAME_IR_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_MOTION_PLUS_get___")]
  public static extern string NAME_MOTION_PLUS_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_NUNCHUK_get___")]
  public static extern string NAME_NUNCHUK_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_CLASSIC_CONTROLLER_get___")]
  public static extern string NAME_CLASSIC_CONTROLLER_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_BALANCE_BOARD_get___")]
  public static extern string NAME_BALANCE_BOARD_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_PRO_CONTROLLER_get___")]
  public static extern string NAME_PRO_CONTROLLER_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_DRUMS_get___")]
  public static extern string NAME_DRUMS_get();

  [global::System.Runtime.InteropServices.DllImport("xwiimote", EntryPoint="CSharp_WiiMoteSpotlightfLibfXWiiMotefSwig_NAME_GUITAR_get___")]
  public static extern string NAME_GUITAR_get();
}

}
