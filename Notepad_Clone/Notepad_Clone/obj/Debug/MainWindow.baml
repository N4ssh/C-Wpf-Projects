   M S B A M L   `   `   `  ����H  DNotepad_Clone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Notepad_CloneNotepad_Clone  5   	       Notepad_Clone.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Notepad_Clone     5   	   -   5          � Title$  NoteBook��5
   	   $	��720��6   $
��1024��6'    � WindowStartupLocation$ CenterScreen=�64   .��5      �    	BodyColor#��[  6    � RowDefinitions 5   
   �� 5      $��24 �6   �� 5      �� 5      $��23 �6   .+�5   
   ��   	MenuColor#��[ 6   o� 5   
   
������ $��Center=�6(   .@�5      m� $
��File��6   $��Center=�5      $��Center=�5      $��13(�5        MenuTextColor#��[ 5      .@�5      m� -   5        $	��New��5       m� InputGestureText$ Ctrl+N��6(   $��13(�5      #��[ 5      m� 5      -   5        $��
New Window��5      $ Ctrl+Shift+N��6/   $��13(�5      #��[ 5!      m� 5"      -   5         m�Name$ Open_MenuItem��5"      $��Open...��62   $ Ctrl+O��6C   $��13(�5$      #��[ 5%      m� 5&      -   5        $ Save_MenuItem��5&      $
��Save��6O   $ Ctrl+S��6]   $��13(�5'      #��[ 5(      m� 5)      -   5        $ SaveAs_MenuItem��5)      $��
Save as...��6S   $ Ctrl+Shift+S��6g   $��13(�5*      #��[ 5+      �� 5,      m� 5-      $��Page Setup...��6   $��13(�5.      {�.  #��[ 50      m� 51      $��Print��6   $��13(�52      {�.  #��[ 54      �� 55      m� 56      -   5        $
��Exit��56      $��13(�57      #��[ 59      5:      m� 5;      $
��Edit��6   $��Center=�5<      $��Center=�5=      $��13(�5>      #��[ 5?      .@�5@      m� -   5        $
��Undo��5@      $ Ctrl+Z��6)   $��13(�5A      #��[ 5C      �� 5D      m� 5E      -	   5        $	��Cut��5E      $ Ctrl+X��6(   $��13(�5F      #��[ 5H      m� 5I      -
   5        $
��Copy��5I      $ Ctrl+C��6)   $��13(�5J      #��[ 5L      m� 5M      -   5        $��Paste��5M      $ Ctrl+V��6*   $��13(�5N      #��[ 5P      m� 5Q      -   5        $��Delete��5Q      $	 Del��6+   $��13(�5R      #��[ 5T      �� 5U      m� 5V      -   5        $ Find_MenuItem��5V      $��Find...��5W      $ Ctrl+X��6&   $��13(�5X      {�.  #��[ 5[      m� 5\      $��	Find Next��6   $ Ctrl+C��6.   $��13(�5]      #��[ 5^      m� 5_      $��Find Previous��6   $ Ctrl+V��62   $��13(�5`      #��[ 5a      m� 5b      $��
Replace...��6   $ Ctrl+H��6/   $��13(�5c      #��[ 5d      m� 5e      $��	Go Too...��6   $ Ctrl+G��6.   $��13(�5f      #��[ 5g      �� 5h      m� 5i      -   5        $��
Select All��5i      $ Ctrl+A��6/   $��13(�5j      #��[ 5l      m� 5m      -   5        $��	Time/Date��5m      $ F5��6.   $��13(�5n      #��[ 5p      5q      m� 5r      $��Format��6   $��Center=�5s      $��Center=�5t      $��13(�5u      #��[ 5v      .@�5w      m� -   5        $ WordWrap_MenuItem��5w      $��	Word Wrap��66    m� IsCheckable .  m� 	IsChecked . $��13(�5x      #��[ 5z      m� 5{      -   5        $��Font...��5{      $��13(�5|      #��[ 5~      5      m� 5�      $
��View��6   $��Center=�5�      $��Center=�5�      $��13(�5�      #��[ 5�      .@�5�      m� $
��Zoom��6   $��13(�5�      #��[ 5�      .@�5�      m� -   5        $��Zoom In��5�      $ 	Ctrl+Plus��60   $��13(�5�      #��[ 5�      m� 5�      -   5        $��Zoom Out��5�      $ 
Ctrl+Minus��61   $��13(�5�      #��[ 5�      m� 5�      -   5        $��Restore Default Zoom��5�      $ Ctrl+O��6=   $��13(�5�      #��[ 5�      5�      �� 5�      m� 5�      -   5        $ StatusBar_MenuItem��5�      $��
Status Bar��67    .  . $��13(�5�      #��[ 5�      5�      5�      �� 5�   
   #��[  6   $��1��66   �� 5�   
   -   5         ��Name$ MainTextBox��5�      
������ $��1��5�      $��0q�6   $��6q�5�      $��16(�6    �� 
CaretBrush �#D0D0D0	 �� AcceptsReturn	 . 
 �� TextWrapping$

 Wrap=�5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      $ �� HorizontalScrollBarVisibility$
 Auto=�5�        BodyTextColor#��[ 5�      .��6d   5�      �� 5�   
   -   5         ��Name$ StatusBar_Rectangle��5�      #��[ 62   $��2��6T   $y�Visible=�6a   � 5�   
   -   5         �Name$ 	StatusBar��5�      $��2��6"   $y�Visible=�6/    � ColumnDefinitions 5�      �� 5�      �� 5�      $	��140 �6#   �� 5�      $��60 �6#   �� 5�      $	��160 �6#   �� 5�      $	��160 �6#   .+�5�      �� $��1��6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   $
��Left=�6]   $��10 0 0 0q�6x   .+�5�      �� $	��Ln ��6   �� 5�      -   5         ��Name$ 	LineCount��5�      $��1��6/   �� 5�      $��,��6   �� 5�      $�� Col ��6   �� 5�      -   5        $ 
ColumCount��5�      $��1��60   5�      �� 5�      ���	#FF424242$��1��6)   $��20��63   $��Right=�6?   6]   �� 5�      ���	#FF424242$��1��6)   $��1��63   $��20��6C   $��Right=�6O   6m   �� 5�      ���	#FF424242$��1��6)   $��2��63   $��20��6C   $��Right=�6O   6m   �� 5�      ���	#FF424242$��1��6)   $��3��63   $��20��6C   $��Right=�6O   6m   �� 5�      -   5        $ ZoomPercentage��5�      $
��100%��60   $��2��6<   $��Center=�6L   $��0 0 18 0q�6g   $��Center=�6y   �� 5�      $��Windows (CRLF)��6   $��3��6.   $��Center=�6>   $��8 0 0 0q�6Y   �� 5�      $��UTF-8��6   $��4��6%   $��Center=�65   $��6 0 0 0q�6Q   5�      5�      5�      