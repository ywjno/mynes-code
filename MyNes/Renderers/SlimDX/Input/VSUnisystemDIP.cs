using MyNes.Core.IO.Input;
namespace MyNes
{
   public  class VSUnisystemDIP : IVSunisystemDIP
   {
       private JoyButton[] _buttons;

       public JoyButton CreditServiceButton { get { return _buttons[0]; } }
       public JoyButton DIPSwitch1 { get { return _buttons[1]; } }
       public JoyButton DIPSwitch2 { get { return _buttons[2]; } }
       public JoyButton DIPSwitch3 { get { return _buttons[3]; } }
       public JoyButton DIPSwitch4 { get { return _buttons[4]; } }
       public JoyButton DIPSwitch5 { get { return _buttons[5]; } }
       public JoyButton DIPSwitch6 { get { return _buttons[6]; } }
       public JoyButton DIPSwitch7 { get { return _buttons[7]; } }
       public JoyButton DIPSwitch8 { get { return _buttons[8]; } }
       public JoyButton CreditLeftCoinSlot { get { return _buttons[9]; } }
       public JoyButton CreditRightCoinSlot { get { return _buttons[10]; } }

       public VSUnisystemDIP(InputManager manager)
       {
           _buttons = new JoyButton[11];
           for (int i = 0; i < 11; i++)
           {
               _buttons[i] = new JoyButton(manager);
           }
       }

       public byte GetData4016()
       {
           byte data = 0;
           if (CreditServiceButton.IsPressed())
               data |= 0x04;
           if (DIPSwitch1.IsPressed())
               data |= 0x08;
           if (DIPSwitch2.IsPressed())
               data |= 0x10;
           if (CreditLeftCoinSlot.IsPressed())
               data |= 0x20;
           if (CreditRightCoinSlot.IsPressed())
               data |= 0x40;
           return data;
       }
       public byte GetData4017()
       {
           byte data = 0;
           if (DIPSwitch3.IsPressed())
               data |= 0x04;
           if (DIPSwitch4.IsPressed())
               data |= 0x08;
           if (DIPSwitch5.IsPressed())
               data |= 0x10;
           if (DIPSwitch6.IsPressed())
               data |= 0x20;
           if (DIPSwitch7.IsPressed())
               data |= 0x40;
           if (DIPSwitch8.IsPressed())
               data |= 0x80;
           return data;
       }
    }
}
