   M S B A M L   `   `   `  ����E  ATelevision, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Television
Television  5   	       Television.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Television     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��174* �6   �� 5      $
��626* �6   �� 5      $	��45* �6   .+�5   
   �� -   5         ��Name$ 	btn_OnOff��5      $��On/Off��6$   $��Right=�65   $��
0,50,100,0q�6Q   $	��Top=�6e   $��40��6}   $��70��6�   $��Arial)�6�   $��1��6�   �� 5   
   -   5        $ 
btn_Source��5      $��Source��6%   $��Right=�66   $��0,300,100,0q�6R   $	��Top=�6g   $��40��6   $��70��6�   $��Arial)�6�   $��1��6�   6�   �� 5   
   -   5        $ btn_ChannelUp��5      $��+��6(   $��Right=�64   $��0,150,170,0q�6P   $	��Top=�6e   $��20��6}   $��20��6�   $��Arial)�6�   $��1��6�   6�   �� 5   
   -   5         ��Name$ txt_Channel��5      $��Right=�6*   $��0,200,160,0q�6F   $��Channel��6[   $
��Wrap=�6j   $	��Top=�6~   $��1��6�   �� 5   
   -   5        $ btn_ChannelDown��5      $��-��6*   $��Right=�66   $��0,250,170,0q�6R   $	��Top=�6g   $��20��6   $��20��6�   $��Arial)�6�   $��1��6�   6�   �� 5   
   -   5        $ btn_VolumeUp��5      $��+��6'   $��Right=�63   $��
0,150,70,0q�6O   $	��Top=�6c   $��20��6{   $��20��6�   $��Arial)�6�   $��1��6�   6�   �� 5   
   -   5        $ 
txt_Volume��5      $��Right=�6)   $��
0,200,60,0q�6E   $��Volume��6Y   $
��Wrap=�6g   $	��Top=�6{   $��1��6�   �� 5   
   -	   5        $ btn_VolumeDown��5      $��-��6)   $��Right=�65   $��
0,250,70,0q�6Q   $	��Top=�6e   $��20��6}   $��20��6�   $��Arial)�6�   $��1��6�   6�   �� 5   
   -
   5        $ txt_CurrentSource��5      $
��Left=�6I   $��	84,61,0,0q�6d   $��Current Source: ��6w   $
��Wrap=�6�   $	��Top=�6�   $��2��6�   $	��150��6�   �� 5   
   -   5        $ txt_CurrentChannel��5      $
��Left=�6J   $��	84,91,0,0q�6e   $��Current Channel: ��6x   $
��Wrap=�6�   $	��Top=�6�   $��2��6�   $	��150��6�   �� 5   
   -   5        $ txt_CurrentVolume��5      $
��Left=�6I   $��
84,127,0,0q�6d   $��Current Volume: ��6x   $
��Wrap=�6�   $	��Top=�6�   $��2��6�   $	��150��6�   5      5       