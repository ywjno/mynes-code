
// This file has been generated by the GUI designer. Do not modify.
namespace Stetic
{
	internal class Gui
	{
		private static bool initialized;

		internal static void Initialize (Gtk.Widget iconRenderer)
		{
			if ((Stetic.Gui.initialized == false)) {
				Stetic.Gui.initialized = true;
				global::Gtk.IconFactory w1 = new global::Gtk.IconFactory ();
				global::Gtk.IconSet w2 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.MyNes.ico"));
				w1.Add ("MyNesIcon", w2);
				global::Gtk.IconSet w3 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.monitor.png"));
				w1.Add ("VideoSettings", w3);
				global::Gtk.IconSet w4 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.sound.png"));
				w1.Add ("Audio", w4);
				global::Gtk.IconSet w5 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.folder_wrench.png"));
				w1.Add ("Paths", w5);
				global::Gtk.IconSet w6 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.wrench.png"));
				w1.Add ("Preferences", w6);
				global::Gtk.IconSet w7 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.color_wheel.png"));
				w1.Add ("Palette", w7);
				global::Gtk.IconSet w8 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.controller.png"));
				w1.Add ("Input", w8);
				global::Gtk.IconSet w9 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.control_play.png"));
				w1.Add ("Play", w9);
				global::Gtk.IconSet w10 = new global::Gtk.IconSet (global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.control_eject.png"));
				w1.Add ("Stop", w10);
				w1.AddDefault ();
			}
		}
	}

	internal class ActionGroups
	{
		public static Gtk.ActionGroup GetActionGroup (System.Type type)
		{
			return Stetic.ActionGroups.GetActionGroup (type.FullName);
		}

		public static Gtk.ActionGroup GetActionGroup (string name)
		{
			return null;
		}
	}
}
