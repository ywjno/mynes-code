
// This file has been generated by the GUI designer. Do not modify.
namespace MyNesGTK
{
	public partial class Dialog_Paths
	{
		private global::Gtk.Table table3;
		
		private global::Gtk.Button button185;
		
		private global::Gtk.Button button186;
		
		private global::Gtk.Button button187;
		
		private global::Gtk.Button button188;
		
		private global::Gtk.Button button189;
		
		private global::Gtk.Button button190;
		
		private global::Gtk.Entry entry_gg;
		
		private global::Gtk.Entry entry_snaps;
		
		private global::Gtk.Entry entry_sounds;
		
		private global::Gtk.Entry entry_sram;
		
		private global::Gtk.Entry entry_state;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MyNesGTK.Dialog_Paths
			this.Name = "MyNesGTK.Dialog_Paths";
			this.Title = global::Mono.Unix.Catalog.GetString ("Paths Settings");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("MyNesGTK.resources.folder_wrench.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Internal child MyNesGTK.Dialog_Paths.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table (((uint)(6)), ((uint)(3)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.button185 = new global::Gtk.Button ();
			this.button185.CanFocus = true;
			this.button185.Name = "button185";
			this.button185.UseUnderline = true;
			this.button185.Label = global::Mono.Unix.Catalog.GetString ("Change");
			this.table3.Add (this.button185);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table3 [this.button185]));
			w2.LeftAttach = ((uint)(2));
			w2.RightAttach = ((uint)(3));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button186 = new global::Gtk.Button ();
			this.button186.CanFocus = true;
			this.button186.Name = "button186";
			this.button186.UseUnderline = true;
			this.button186.Label = global::Mono.Unix.Catalog.GetString ("Change");
			this.table3.Add (this.button186);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table3 [this.button186]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(2));
			w3.RightAttach = ((uint)(3));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button187 = new global::Gtk.Button ();
			this.button187.CanFocus = true;
			this.button187.Name = "button187";
			this.button187.UseUnderline = true;
			this.button187.Label = global::Mono.Unix.Catalog.GetString ("Change");
			this.table3.Add (this.button187);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table3 [this.button187]));
			w4.TopAttach = ((uint)(2));
			w4.BottomAttach = ((uint)(3));
			w4.LeftAttach = ((uint)(2));
			w4.RightAttach = ((uint)(3));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button188 = new global::Gtk.Button ();
			this.button188.CanFocus = true;
			this.button188.Name = "button188";
			this.button188.UseUnderline = true;
			this.button188.Label = global::Mono.Unix.Catalog.GetString ("Change");
			this.table3.Add (this.button188);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table3 [this.button188]));
			w5.TopAttach = ((uint)(3));
			w5.BottomAttach = ((uint)(4));
			w5.LeftAttach = ((uint)(2));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button189 = new global::Gtk.Button ();
			this.button189.CanFocus = true;
			this.button189.Name = "button189";
			this.button189.UseUnderline = true;
			this.button189.Label = global::Mono.Unix.Catalog.GetString ("Change");
			this.table3.Add (this.button189);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table3 [this.button189]));
			w6.TopAttach = ((uint)(4));
			w6.BottomAttach = ((uint)(5));
			w6.LeftAttach = ((uint)(2));
			w6.RightAttach = ((uint)(3));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.button190 = new global::Gtk.Button ();
			this.button190.CanFocus = true;
			this.button190.Name = "button190";
			this.button190.UseUnderline = true;
			this.button190.Label = global::Mono.Unix.Catalog.GetString ("Reset all to defaults");
			this.table3.Add (this.button190);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table3 [this.button190]));
			w7.TopAttach = ((uint)(5));
			w7.BottomAttach = ((uint)(6));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.entry_gg = new global::Gtk.Entry ();
			this.entry_gg.CanFocus = true;
			this.entry_gg.Name = "entry_gg";
			this.entry_gg.IsEditable = false;
			this.entry_gg.InvisibleChar = '●';
			this.table3.Add (this.entry_gg);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table3 [this.entry_gg]));
			w8.TopAttach = ((uint)(4));
			w8.BottomAttach = ((uint)(5));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.entry_snaps = new global::Gtk.Entry ();
			this.entry_snaps.CanFocus = true;
			this.entry_snaps.Name = "entry_snaps";
			this.entry_snaps.IsEditable = false;
			this.entry_snaps.InvisibleChar = '●';
			this.table3.Add (this.entry_snaps);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table3 [this.entry_snaps]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.entry_sounds = new global::Gtk.Entry ();
			this.entry_sounds.CanFocus = true;
			this.entry_sounds.Name = "entry_sounds";
			this.entry_sounds.IsEditable = false;
			this.entry_sounds.InvisibleChar = '●';
			this.table3.Add (this.entry_sounds);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table3 [this.entry_sounds]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.entry_sram = new global::Gtk.Entry ();
			this.entry_sram.CanFocus = true;
			this.entry_sram.Name = "entry_sram";
			this.entry_sram.IsEditable = false;
			this.entry_sram.InvisibleChar = '●';
			this.table3.Add (this.entry_sram);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table3 [this.entry_sram]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.entry_state = new global::Gtk.Entry ();
			this.entry_state.CanFocus = true;
			this.entry_state.Name = "entry_state";
			this.entry_state.IsEditable = false;
			this.entry_state.InvisibleChar = '●';
			this.table3.Add (this.entry_state);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table3 [this.entry_state]));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("State saves folder");
			this.table3.Add (this.label3);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table3 [this.label3]));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Save-Ram folder");
			this.table3.Add (this.label4);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table3 [this.label4]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Snapshots folder");
			this.table3.Add (this.label5);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table3 [this.label5]));
			w15.TopAttach = ((uint)(2));
			w15.BottomAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Sound records folder");
			this.table3.Add (this.label6);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table3 [this.label6]));
			w16.TopAttach = ((uint)(3));
			w16.BottomAttach = ((uint)(4));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Game Genie codes folder");
			this.table3.Add (this.label7);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table3 [this.label7]));
			w17.TopAttach = ((uint)(4));
			w17.BottomAttach = ((uint)(5));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			w1.Add (this.table3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(w1 [this.table3]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Internal child MyNesGTK.Dialog_Paths.ActionArea
			global::Gtk.HButtonBox w19 = this.ActionArea;
			w19.Name = "dialog1_ActionArea";
			w19.Spacing = 10;
			w19.BorderWidth = ((uint)(5));
			w19.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w20 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19 [this.buttonCancel]));
			w20.Expand = false;
			w20.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w19 [this.buttonOk]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 646;
			this.DefaultHeight = 315;
			this.Show ();
			this.button190.Pressed += new global::System.EventHandler (this.OnButton190Pressed);
			this.button189.Pressed += new global::System.EventHandler (this.OnButton189Pressed);
			this.button188.Pressed += new global::System.EventHandler (this.OnButton188Pressed);
			this.button187.Pressed += new global::System.EventHandler (this.OnButton187Pressed);
			this.button186.Pressed += new global::System.EventHandler (this.OnButton186Pressed);
			this.button185.Pressed += new global::System.EventHandler (this.OnButton185Pressed);
		}
	}
}
