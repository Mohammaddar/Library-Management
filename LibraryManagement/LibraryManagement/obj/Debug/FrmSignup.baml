   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5      !    LibraryManagement.FrmSignup   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LibraryManagement     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  	FrmSignup��5      $	��800��5	      $	��500��5
      ���	#FFF6F5F5 � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         tmpRoundedIconButton �� 
TargetType ��Name �� CornerRadius � ColumnDefinitions �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value  tmpRoundedImage ��Name J� Clip �� RadiusX �� RadiusY �� Rect ��Name �� Left
 �� Top J� Opacity  tmpRoundedButton-  'System.Windows.Media.Effects.BlurEffect  tmpBackButton �� Padding ��Name  tmpRoundedTextBox ��Name��%*
  &	        &	 �    &	 4    &	     �� 5   
   " ��67   .R�5      �� $ 	btnBorder��5      #��z��5      $ 16��5      ._�5      �  5      �� 5      $��4* �6+   �� 5      $��1* �6+   .+�5      �� $��0��5      $	��150��5      $��
10,0,-10,0q�5      $��Center=�5      $��Center=�5       
������ #��z��5"      #��z��5#      #��z��5$      #��z��5%      �� 5&      $��1��5'      $��24��5(      $��24��5)      $��	-20,0,0,0q�5*      $��Images/login.png��5+      5,      5-       5.      P� 5/      	 �@J�IsMouseOver
 . . �50      �� $ 	btnBorder��6    � �� �	#FF33555D6J   51      53      �� 54   
   " ��62   .R�55      �� #��z��56      #��z��57      
���   �$��2q�59      $ 90��5:      ._�5;      �� #��z��6   #��z��69   .+�5<      �� $ 
imgProfile��5=      $	��126��5>      $	��126��5?      $��Images/profile.png��5@      $
��Fill=�5A       5B      �� 5C      $ 90Q�5D   !   $ 90Q�5E   !   $ 0,0,126,126�5F   !   5H      �� 5I      $ 	btnSetPic��5J      -   5        $ 18��5K      $ 48��5L      $��90��5M      $��35��5N      ���	#FFFFF5FD$��Change��5Q      $��Fonts/#Titillium Web)�5R      $��10(�5S      
���   �$	 0.8Q�5U      #���  5V      $y�Hidden=�5W      5X      5Y       5Z      P� 5[      	 �@J�IsMouseOver
 . . �5\      �� $ 	btnSetPic��6    � y�$ Visible=�6J   �� 5]      $ 
imgProfile��6    �@J�Effect 5^        5_      5a      5b      5e      �� 5f   
   " ��60   .R�5g      �� $ border��5h      $ 	10,6,10,6q�5i      
������ $��0q�5k      $ 16��5l      ._�5m      �� $ btnBack��5n      $��1��5o      $ 40��5p      $ 40��5q      
������ $��Fonts/#Titillium Web)�5s      
�������$��Back To Login Page��5u      5v       5w      P� 5x      	 �@J�IsMouseOver
 . . �5y      �� $ border��6    � �� �	#198C8F9A6G   5z      5}      �� 5~   
   " ��64   .R�5      � #��z��6   #��z��63   .+�5�      �� $ txtBoxBorder��5�      #��z��5�      ���	#FFE4E3E5$	��0.4q�5�      $ 14��5�      �� 5�      $	 edt��5�      -   5        $��	12,6,12,6q�5�      $��Stretch=�5�      $��Stretch=�5�      $��Center=�5�      
������ $��0q�5�      5�      5�       5�      P� 5�      	 �@J�IsMouseOver
 . . �5�      �� $ txtBoxBorder��6    � �� �	#FFEAF1F66M   5�      5�      5�      .��5�      �� .+�5�   
   �� $ 0��5�      $	��800��5�       K� ZIndex$ 0��5�      $��Images/lib3.jpeg��5�      $
��Fill=�5�       5�      �� 5�      $ 0,0,650,480�6$   5�      �� 5�   
   -   5        $ btnBack��5�      $ 40��5�      $ 40��5�      #��[ 5�      �� 5�   
   $��0��5�      $ 40��5�      $	 124��5�      $
��Left=�5�      $��Center=�5�      $��Library 
Management��5�      $��Fonts/#Arvo)�5�      $��32(�5�      $
��Bold"�5�      
�������5�      �� 5�   
   $��1��5�      $ 42��5�      $	 230��5�      $��Welcome!��5�      $��Fonts/#Titillium Web)�5�      $��22(�5�      
�������5�      �� 5�   
   $��1��5�       �� Right$ 50��5�       �� Bottom$ 60��5�      $	��440��5�      $	��380��5�      $ 	10,0,10,5q�5�      $ 1��5�      ���	#4C116790$��0q�5�      $ 4��5�      ��5�      �� 5�       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,2&�67   .��5�      �  � Offset$	 0.5Q�6#     � Color$  White��60   � 5�      $ 1Q�6#   $  	#FFDEE0E5��6.   5�      ! J� Effect! 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�      "   
BlurRadius$" 12Q�5�      #   	Direction$	# 350Q�5�      $   Opacity$$ 20Q�5�      %   Color$% 	#4CECECF0��5�      ._�5�      � & � RowDefinitions& 5�      �� 5�      $
��0.7* �6$   �� 5�      $
��2.4* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   .+�5�      �� $��0��5�      $ 42��5�      $	 230��5�      $��0,10,0,0q�5�      $��Center=�5�      $��Center=�5�      $��Sign Up As Member��5�      $��Fonts/#Titillium Web)�5�      $��20(�5�      ���	#FF022E575�      � 5�      $��1��6    5�      �� 5�      $��1* �6+   �� 5�      $
��1.5* �6+   .+�5�      �� -   5        $��
btnProfile��5�      $��0��5�      $	��130��5�      $	��130��5�      $��	20,10,0,0q�5�      #��[ 5�      .��5�      �� $��75��5�      $	��100��5�      $��Button��5�      5�      � 5�      $��1��6   & 5�      �� 5�      $��1* �6,   �� 5�      $��1* �6,   .+�5�      �� $��0��5�      $��0,20,0,0q�5�      ' �� Orientation$' Vertical=�5      .+�5     �� $��30,0,0,2q�5  !   $
��Left=�5  !   $��Center=�5  !   
������ $��Fonts/#Titillium Web)�5  !   $��12(�5  !   ���	#FF005A8D$��User name :��5	  !   �� 5
     -   5        $��edtUserName��5  !   $��2��5  !   $	��210��5  !   $��40��5  !   $��0,0,0,0q�5  !   $��Stretch=�5  !   $��Stretch=�5  !   $��Center=�5  !   ���	#FFF6F5F7$��Fonts/#Titillium Web)�5  !   #��[ 5  !   5     �� 5     $��1��6%   $' Vertical=�62   .+�5     �� $��30,0,0,2q�5  !   $
��Left=�5  !   $��Center=�5  !   
������ $��Fonts/#Titillium Web)�5  !   $��12(�5  !   ���	#FF005A8D$��Phone number :��5   !   �� 5!     -   5        $��edtPhoneNum��5"  !   $	��210��5#  !   $��40��5$  !   $��0,0,0,0q�5%  !   $��Stretch=�5&  !   $��Stretch=�5'  !   $��Center=�5(  !   ���	#FFF6F5F7$��Fonts/#Titillium Web)�5*  !   #��[ 5+  !   5,     5-     5.     �� 5/     $��2��6   $' Vertical=�6*   .+�50     �� $��30,0,0,2q�51     $
��Left=�52     $��Center=�53     
������ $��Fonts/#Titillium Web)�55     $��12(�56     ���	#FF005A8D$��Email :��58     �� 59     -   5        $��edtEmail��5:     $	��378��5;     $��40��5<     $��	21,0,21,0q�5=     $��Stretch=�5>     $��Stretch=�5?     $��Center=�5@     ���	#FFF6F5F7$��Fonts/#Titillium Web)�5B     #��[ 5C     5D     � 5E     $��3��6    5F     �� 5G     $��1* �6+   �� 5H     $
��1.2* �6+   .+�5J     �� $��0��5K     $��0,-4,0,0q�5L     $' Vertical=�5M     .+�5N     �� $��30,0,0,2q�5O     $
��Left=�5P     $��Center=�5Q     
������ $��Fonts/#Titillium Web)�5S     $��12(�5T     ���	#FF005A8D$��
Password :��5V     G� 5W     -   5        $��edtPassword��5X     $	��160��5Y     $��40��5Z     $��
11.2,0,0,0q�5[     $��Stretch=�5\     $��Stretch=�5]     $��Center=�5^     ���	#FFDED9E3$��Fonts/#Titillium Web)�5`       tmpRoundedPassBox#���  5a     5b     �� 5c     -	   5        $��btnLogin��5d     $��1��5e     $	��200��5f     $��40��5g     $��-12.8,0,0,0q�5h     $��Stretch=�5i     $��Stretch=�5j     ���#053742���#005A8D$��Proceed to payment��5n     $��Fonts/#Titillium Web)�5o     $��14(�5p     
�������#���   5r     5s     5t     5u     �� 5w  
   $ 85��5x     $	 212��5y     $	��260��5z     $	��0.3��5{     $ 2��5|     ���	#7FAFA9B95}     5~     5     