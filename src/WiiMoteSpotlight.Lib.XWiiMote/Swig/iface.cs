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

public class iface : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal iface(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(iface obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~iface() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          xwiimotePINVOKE.delete_iface(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public iface(string syspath) : this(xwiimotePINVOKE.new_iface(syspath), true) {
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
  }

  public void open(uint ifaces) {
    xwiimotePINVOKE.iface_open(swigCPtr, ifaces);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
  }

  public void close(uint ifaces) {
    xwiimotePINVOKE.iface_close(swigCPtr, ifaces);
  }

  public uint opened() {
    uint ret = xwiimotePINVOKE.iface_opened(swigCPtr);
    return ret;
  }

  public string get_syspath() {
    string ret = xwiimotePINVOKE.iface_get_syspath(swigCPtr);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int get_fd() {
    int ret = xwiimotePINVOKE.iface_get_fd(swigCPtr);
    return ret;
  }

  public uint available() {
    uint ret = xwiimotePINVOKE.iface_available(swigCPtr);
    return ret;
  }

  public void dispatch(xwii_event_ ev) {
    xwiimotePINVOKE.iface_dispatch(swigCPtr, xwii_event_.getCPtr(ev));
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
  }

  public void rumble(bool on) {
    xwiimotePINVOKE.iface_rumble(swigCPtr, on);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
  }

  public bool get_led(uint led) {
    bool ret = xwiimotePINVOKE.iface_get_led(swigCPtr, led);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void set_led(uint led, bool state) {
    xwiimotePINVOKE.iface_set_led(swigCPtr, led, state);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
  }

  public int get_battery() {
    int ret = xwiimotePINVOKE.iface_get_battery(swigCPtr);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string get_devtype() {
    string ret = xwiimotePINVOKE.iface_get_devtype(swigCPtr);
    if (xwiimotePINVOKE.SWIGPendingException.Pending) throw xwiimotePINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public string get_extension() {
    string ret = xwiimotePINVOKE.iface_get_extension(swigCPtr);
    return ret;
  }

  public void set_mp_normalization(int x, int y, int z, int factor) {
    xwiimotePINVOKE.iface_set_mp_normalization(swigCPtr, x, y, z, factor);
  }

  public void get_mp_normalization(SWIGTYPE_p_int x, SWIGTYPE_p_int y, SWIGTYPE_p_int z, SWIGTYPE_p_int factor) {
    xwiimotePINVOKE.iface_get_mp_normalization(swigCPtr, SWIGTYPE_p_int.getCPtr(x), SWIGTYPE_p_int.getCPtr(y), SWIGTYPE_p_int.getCPtr(z), SWIGTYPE_p_int.getCPtr(factor));
  }

  public static string get_name(uint iface) {
    string ret = xwiimotePINVOKE.iface_get_name(iface);
    return ret;
  }

}

}
