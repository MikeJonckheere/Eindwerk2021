   M S B A M L   `   `   `  ���� E  ATelevision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Television
Television      Television.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:Television     -     � Title$  TEVEE��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True��.���� ���	#FF727272���	#FF252525$��25q� �� CornerRadius$ 30��._��  � ColumnDefinitions �� $��6* ��� $��1* ��� $��1* � � RowDefinitions �� $��1* ��� $��1* ��� $��1* �.+��� -    ��Name$ 	btn_OnOff��$��On/Off��   RoundCorner#���   $��Center=�$��10q�$��40��$��70��$��Arial)�$��1���� -   $ btn_Closeapp��$��	Close App��#���   $��Center=�$��10q�$��40��$��70��$��Arial)�$��2���� -   $ 
btn_Source��$��Source��#���   $��Center=�$��10q�$��40��$��70��$��Arial)�$��1��$��2���� $��1��$��1��$��Center=�.+��� -   $ btn_ChannelUp��$��+��#���   $��Center=�$��5q�$��30��$��30��$��Arial)��� -   	 ��Name$	 txt_Channel��$��Center=�$��10q�$��Channel��$��14(�$
��Wrap=��� -   $ btn_ChannelDown��$��-��#���   $��Center=�$��5q�$��30��$��30��$��Arial)��� $��1��$��2��$��Center=�.+��� -   $ btn_VolumeUp��$��+��#���   $��Center=�$��5q�$��30��$��30��$��Arial)��� -	   $	 
txt_Volume��$��Center=�$��10q�$��Volume��$��14(�$
��Wrap=��� -
   $ btn_VolumeDown��$��-��#���   $��Center=�$��5q�$��30��$��30��$��Arial)��� $��1��$��0��$
��Left=�$��Center=�.+��� -   $	 txt_CurrentSource��$��Stretch=�$��20,5,0,5q�$��Current Source: ��$��20(�$
��Wrap=��� -   $	 txt_CurrentChannel��$��Stretch=�$��20,5,0,5q�$��Current Channel: ��$��20(�$
��Wrap=��� -   $	 txt_CurrentVolume��$��Stretch=�$��20,5,0,5q�$��Current Volume: ��$��20(�$
��Wrap=�