   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5      "    LibraryManagement.FrmMembers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LibraryManagement     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$	  frm��5       � Title$ 
FrmMembers��5	      $	��920��5
      $	��570��5      ���#F6F5F5 � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         
tmpTabItem �� 
TargetType ��Name �� Triggers P� Property P� Value	 �� 
TargetName
 �� Property �� Value  tmpTabItem2 �Name ��Name P� 
SourceName  tmpListBooksItem �� Orientation  tmpListMyBooksItem  tmpListBoxBooks ��Name �� 
TargetType  tmpListBoxMyBooks  tmpRoundedTextBox �� CornerRadius ��Name �� 	MaxLength  tmpEditableRoundedTextBox � ColumnDefinitions ��Name  tmpEditButton ]� 
Conditions �� Property �� Value �� 
SourceName :� RoutedEvent :� 
SourceName �� 
TargetName �� TargetProperty �� KeyTime  �� Value 	 tmpRoundedImage! ��Name" J� Clip# �� RadiusX$ �� RadiusY% �� Rect& �� Left
' �� Top( J� Opacity 
 tmpRoundedButton-  'System.Windows.Media.Effects.BlurEffect  tmpSearchableRoundedTextBox  tmpSearchButton��%�,  &	        &	 M    &	 w    &	     &	 �    7  &	 �    7  &	     &	 #!    7  &		 �%    &	 a)    7  �� 5   
   " 	�6-   .R�5      �� $ borderTabItem��6   
������ ._�5      �� $��
lblTabItem��5      $��50,0,0,0q�5      $
��Left=�5      $��Center=�5      
������ #��z��5      $��Fonts/#Titillium Web)�5      #��z��5      $
��Bold"�5      ���#1453745      5       5      P� 5       �@J�IsMouseOver . . �5       �� $	 borderTabItem��6   
 � �� �	#FFEAF1F66N   5!      P� 5"       �@d�	IsChecked$
 trueY�6/   . �5#      �� $	 borderTabItem��6   
 � �� �#D3E0EA6N   5$      5&      �� 5'   
   " ��6.   .R�5(      � $ gridTabItem2��5)      #��z��5*      #��z��5+      .+�5,      �� $ borderTabItem2��5-      
������ ���#022E57$��0,0,0,0q�50      �� 51      $ lblTabItem2��52      $��Stretch=�53      $��Stretch=�54      $��Center=�55      $��Center=�56      
������ $��0q�58      #��z��59      $��Fonts/#Titillium Web)�5:      $��13(�5;      ���#022E575<      5=       5>      P� 5?      $ gridTabItem2��6    �@J�IsMouseOver . . �5@      �� $	 borderTabItem2��6   
 � �� �#D3E0EA6O   5A      P� 5B       �@��
IsSelected . . �5C      �� $	 borderTabItem2��6   
 � ��$ 0,0,0,1q�6T   �� 5D      $	 lblTabItem2��6   
 � ��$ SemiBold"�6L   5E      5G      �� 5H   
   " ��63   .R�5I      �� $ borderListItem��5J      ���	#66768BA3$��	0,0.4,0,0q�5L      ._�5M      �� $��16,0,0,0q�6   $ 
Horizontal=�6/   .+�5N      �� $��txtBookNumber��5O      $��40��5P      $��45��5Q      $��10,0,0,0q�5R      $
��Left=�5S      $��Center=�5T      $��Fonts/#Titillium Web)�5V      $��13(�5W      ���#11698E��5U      �� *Info0+5X      �� 5Y      $��txtAllBooksName��5Z      $	��100��5[      $��45��5\      $��10,0,0,0q�5]      $
��Left=�5^      $��Center=�5_      $��Fonts/#Titillium Web)�5a      $��13(�5b      ���#495464��5`      �� *Info1+5c      �� 5d      $��txtAllBooksWriter��5e      $	��100��5f      $��45��5g      $��10,0,0,0q�5h      $
��Left=�5i      $��Center=�5j      $��Fonts/#Titillium Web)�5l      $��13(�5m      ���#495464��5k      �� *Info2+5n      �� 5o      $��txtAllBooksGenre��5p      $	��100��5q      $��45��5r      $��10,0,0,0q�5s      $
��Left=�5t      $��Center=�5u      $��Fonts/#Titillium Web)�5w      $��13(�5x      ���#495464��5v      �� *Info3+5y      �� 5z      $��txtAllBooksPublisher��5{      $	��100��5|      $��45��5}      $��10,0,0,0q�5~      $
��Left=�5      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#495464��5�      �� *Info4+5�      �� 5�      $��	btnBorrow��5�      -   5        $��50��5�      $��45��5�      
������ $��0q�5�      $��Borrow��5�      $��Fonts/#Titillium Web)�5�      $��12(�5�      ���#022E575�      5�      5�       5�      P� 5�       �@��
IsSelected . . �5�      �� $	 borderListItem��6   
 � �� �#D3E0EA6O   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $	 borderListItem��6   
 � �� �	#FFEAF1F66O   5�      5�      �� 5�   
   " ��65   .R�5�      �� $ borderListItem��5�      ���	#66768BA3$��	0,0.4,0,0q�5�      ._�5�      �� $��16,0,0,0q�6   $ 
Horizontal=�6/   .+�5�      �� $��txtBookNumber��5�      $��40��5�      $��45��5�      $��10,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#11698E��5�      �� *Info0+5�      �� 5�      $��txtBorrowedBooksName��5�      $	��100��5�      $��45��5�      $��10,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#495464��5�      �� *Info1+5�      �� 5�      $��txtBorrowedBooksWriter��5�      $	��100��5�      $��45��5�      $��10,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#495464��5�      �� *Info2+5�      �� 5�      $ ��txtBorrowedBooksBorrowDate��5�      $	��100��5�      $��45��5�      $��10,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#495464��5�      �� *Info3+5�      �� 5�      $ ��txtBorrowedBooksReturnDate��5�      $	��100��5�      $��45��5�      $��10,0,0,0q�5�      $
��Left=�5�      $��Center=�5�      $��Fonts/#Titillium Web)�5�      $��13(�5�      ���#495464��5�      �� *Info4+5�      �� 5�      $��	btnReturn��5�      -   5        $��50��5�      $��45��5�      
������ $��0q�5�      $��Return��5�      $��Fonts/#Titillium Web)�5�      $��12(�5�      ���#022E575�      5�      5�       5�      P� 5�       �@��
IsSelected . . �5�      �� $	 borderListItem��6   
 � �� �#D3E0EA6O   5�      P� 5�       �@J�IsMouseOver . . �5�      �� $	 borderListItem��6   
 � �� �	#FFEAF1F66O   5�      5�      �� 5�   
   " ��62   .R�5�      �� $��
6,-2.5,6,0q�5�      
������ ���	#7F4F5688$��0,0,0,0q�5�      ._�5�      �� $��0,0,0,0q�6   $ Vertical=�6.   .+�5�      �� $��16,6,0,5q�6!   $ 
Horizontal=�63   .+�5�      �� $��40��5�      $��10,0,0,0q�5�      $��#��5�      $��Fonts/#Titillium Web)�5�      $��14(�5�      ���#005A8D5�      �� 5�      $	��100��5�      $��10,0,0,0q�5�      $
��Name��5      $��Fonts/#Titillium Web)�5     $��14(�5     ���#005A8D5     �� 5     $	��100��5     $��10,0,0,0q�5     $��Writer��5     $��Fonts/#Titillium Web)�5     $��14(�5	     ���#005A8D5
     �� 5     $	��100��5     $��10,0,0,0q�5     $��Genre��5     $��Fonts/#Titillium Web)�5     $��14(�5     ���#005A8D5     �� 5     $	��100��5     $��10,0,0,0q�5     $��	Publisher��5     $��Fonts/#Titillium Web)�5     $��14(�5     ���#005A8D5     �� 5     5     �� 5     $ 
lsAllBooks��5     $	��318��5     $��0,0,0,0q�5     
������ $��0q�5      #��z��5!     $��Disabled=�5"     ��5#     �� 5$     " ��6$   .�5%  "   �� 
 � ��8   6=   5&     5(     5)     5*     5+     �� 5,  
   " ��64   .R�5-     �� $��
6,-2.5,6,0q�5.     
������ ���	#7F4F5688$��0,0,0,0q�51     ._�52     �� $��0,0,0,0q�6   $ Vertical=�6.   .+�53     �� $��16,6,0,5q�6!   $ 
Horizontal=�63   .+�54     �� $��40��55     $��10,0,0,0q�56     $��#��57     $��Fonts/#Titillium Web)�58     $��14(�59     ���#005A8D5:     �� 5;     $	��100��5<     $��10,0,0,0q�5=     $
��Name��5>     $��Fonts/#Titillium Web)�5?     $��14(�5@     ���#005A8D5A     �� 5B     $	��100��5C     $��10,0,0,0q�5D     $��Writer��5E     $��Fonts/#Titillium Web)�5F     $��14(�5G     ���#005A8D5H     �� 5I     $	��100��5J     $��10,0,0,0q�5K     $��Borrow Date��5L     $��Fonts/#Titillium Web)�5M     $��14(�5N     ���#005A8D5O     �� 5P     $	��100��5Q     $��10,0,0,0q�5R     $��Return Date��5S     $��Fonts/#Titillium Web)�5T     $��14(�5U     ���#005A8D5V     �� 5W     5X     �� 5Y     $ 	lsMyBooks��5Z     $	��318��5[     $��0,0,0,0q�5\     
������ $��0q�5^     #��z��5_     $��Disabled=�5`     ��5a     �� 5b     " ��6$   .�5c  "   �� 
 � ��8   6=   5d     5f     5g     5h     5i     �� 5j  
   " ��64   .R�5k     � #��z��6   #��z��63   .+�5l     �� $ txtBoxBorder��5m     #��z��5n     ���	#FFE4E3E5$	��0.4q�5p     $ 14��5q     �� 5r     $	 edt��5s     -   5        $��	12,6,12,6q�5t     $��Stretch=�5u     $��Stretch=�5v     $��Center=�5w     
������ $��0q�5y     # z 5z     #��z��5{     5|     5}      5~     P� 5      �@J�IsMouseOver . . �5�     �� $	 txtBoxBorder��6   
 � �� �	#FFEAF1F66M   5�     5�     �� 5�  
   " ��6<   .R�5�     �� $ txtBoxBorder��5�     ���#FFF5FD���	#4CCBCDEE$	��0.3q�5�     $ 14��5�     ._�5�     � $ pnlEditableRoundedTextBox��5�     #��z��5�     #��z��5�      5�     �� 5�     $
��4.5* �6+   �� 5�     $��1* �6+   .+�5�     �� $ edtEditableRoundedTextBox��5�     -   5        $��0��5�     $��12,6,0,6q�5�     $��Stretch=�5�     $��Center=�5�     
������ $��0q�5�     {�.  #��z��5�     5�     �� 5�     $ imgEdit��5�     $��1��5�     $��30��5�     $��30��5�     $��0,0,6,0q�5�     $��0q�5�     8��  5�     5�     5�      5�     ]� 5�      5�     �� 5�      �@J�IsMouseOver . 6;   �� 5�     $ edtEditableRoundedTextBox��6$    � {� . 6`   ./�5�     �� $	 txtBoxBorder��6   
 � �� �	#FFF3EFF76M   5�     :� 5�     $ Button.Click��6   $ imgEdit��6:   .[�5�     �� .��5�     �� .��5�     �� $ edtEditableRoundedTextBox��6=   $ (TextBox.IsEnabled)�6o   .p�5�  "   s� $ 00:00:00��6:     True6M   5�     5�     5�     5�     5�     �� 5�  
   " ��62   .R�5�     �� #��z��5�     #��z��5�     
���   �$��2q�5�     $ 90��5�     ._�5�     �� #��z��6   #��z��69   .+�5�     �� $! 
imgProfile��5�     $	��136��5�     $	��136��5�     $��Images/profile.png��5�     $
��Fill=�5�     " 5�     �� 5�     $# 90Q�5�  !   $$ 90Q�5�  !   $% 0,0,136,136�5�  !   5�     �� 5�     $ 	btnSetPic��5�     -   5        $& 23��5�     $' 53��5�     $��90��5�     $��35��5�     ���	#FFFFF5FD$��Change��5�     $��Fonts/#Titillium Web)�5�     $��10(�5�     
���   �$	( 0.8Q�5�     #��� 
 5�     $y�Hidden=�5�     5�     5�      5�     P� 5�      �@J�IsMouseOver . . �5�     �� $	 	btnSetPic��6   
 � y�$ Visible=�6J   �� 5�     $	 
imgProfile��6   
 �@J�Effect 5�       5�     5�     5�     5�     �� 5�  
   " ��6>   .R�5�     �� $ txtBoxBorder��5�     ���#FFF5FD���	#4CCBCDEE$	��0.3q�5�     $ 14��5�     ._�5�     � $! pnlSearchableRoundedTextBox��5�     #��z��5�     #��z��5�      5�     �� 5�     $��4* �6+   �� 5�     $��1* �6+   .+�5�     �� $! edtSearchableRoundedTextBox��5�     $��0��5�     $��12,6,0,6q�5�     $��Stretch=�5      $��Center=�5     
������ $��0q�5     #��z��5     �� 5     $ 	imgSearch��5     -   5        $��1��5     $��30��5     $��30��5	     $��0,0,6,0q�5
     $��0q�5     8��  5     5     5      5     P� 5      �@J�IsMouseOver . . �5     �� $	 txtBoxBorder��6   
 � �� �	#FFF3EFF76M   5     5     5     .��5     �  5  
   �� 5     $
��2.2* �6   �� 5     $��0.05* �6   �� 5     $��7* �6   .+�5  
   �� ���	#4C116790$��0q�6)   ��5     �� 5      ) �� 
StartPoint$	) 0,0&�6&   * �� EndPoint$	* 1,2&�67   .��5!     � + � Offset$	+ 0.5Q�6#   , � Color$, White��60   � 5"     $+ 1Q�6#   $, 	#FFF1F5FD��6.   5#     - J� Effect- 5%     3  -System.Windows.Media.Effects.DropShadowEffect  5&     .   
BlurRadius$. 12Q�5'     /   	Direction$	/ 310Q�5(     0   Opacity$0 20Q�5)     1   Color$1 	#4CECECF0��5*     ._�5,     � $��0��6   2 � RowDefinitions2 5-     �� 5.     $
��1.4* �6$   �� 5/     $
��0.5* �6$   �� 50     $
��0.5* �6$   �� 51     $
��0.5* �6$   �� 52     $
��0.5* �6$   �� 53     $
��0.5* �6$   �� 54     $��2* �6$   " 56     �� 57     $% 0,0,216,545�6(   .+�59     �� $��0��5:     $��	20,30,0,0q�5;     $
��Left=�5<     $	��Top=�5=     $��Members 
Panel��5>     $��Fonts/#Arvo)�5?     $��21(�5@     $
��Bold"�5A     ���#0537425B     	� 5C     -   5        3 	�Name$3 rbBooks��5D     $��1��5E     $��Books��5G     $��18(�5H     4 d� 	IsChecked$
4 TrueY�5I     #��[  5J     	� 5K     -	   5        $3 	rbMyBooks��5L     $��2��5M     $��My Books��5O     $��18(�5P     #��[  5Q     	� 5R     -
   5        $3 rbMembership��5S     $��3��5T     $��
Membership��5V     $��18(�5W     #��[  5X     	� 5Y     -   5        $3 rbWallet��5Z     $��4��5[     $��Wallet��5]     $��18(�5^     #��[  5_     	� 5`     -   5        $3 rbInfo��5a     $��5��5b     $
��Info��5d     $��18(�5e     #��[  5f     �� 5g     $��6��5h     $��61,116.2,-32.4,-36.2q�5i     ���#47597E5 J� RenderTransformOrigin$5 0.5,0.5&�5k     z�5l     V� 5m     .~�5n     �� �� 5o     �� 5p     6 �� Angle$	6 -20Q�6.   T� 5q     5r     5t     �� 5u     $��6��5v     $��-47,138.2,100.6,-20.2q�5w     ���#293B5F$5 0.5,0.5&�5y     z�5z     V� 5{     .~�5|     �� �� 5}     �� 5~     $6 20Q�6.   T� 5     5�     5�     5�     5�     �� 5�  
   $��1��5�     $��0��5�     $��	0,90,0,30q�5�     $
��Left=�5�     $��Stretch=�5�     
������ ���	#4C005A8D$��0q�5�     }�. $ 90��5�     ._�5�     �� $��	-11,0,0,0q�5�     
������ ���	#4C005A8D$��10,0,0,0q�5�     - 5�       5�     $. 9Q�6'   7   ShadowDepth$7 0Q�66   5�     5�     �� 5�  
   $��2��6   $ Vertical=�6%   .+�5�     ]� ��.  .+�5�     �� -   5        $ 	boxSearch��5�     $	��330��5�     $��50��5�     $��50,30,44,30q�5�     8 �� Padding$8 6,3,6,3q�5�     ���	#4C005A8D$	��0.2q�5�     $ 12��5�     $
��Left=�5�     ��5�     �� 5�     $	) 0,0&�6.   $	* 1,2&�6?   .��5�     � $	+ 0.9Q�6+   $, White��68   � 5�     $+ 1Q�6+   $, 	#FFF1F5FD��66   5�     - 5�       5�     $. 6Q�5�     $	/ 310Q�5�     $0 20Q�5�     $1 	#4CECECF0��5�     ._�5�     �� $��Center=�6!   $ 
Horizontal=�6<   .+�5�     �� -   5        $��	edtSearch��5�     $	��180��5�     $��40��5�     $��Stretch=�5�     $��Stretch=�5�     $��Center=�5�     $��Fonts/#Titillium Web)�5�     #���  5�     �� 5�     -   5        9 ��Name$9 
cbBookName��5�     $��10,0,0,0q�5�     $��Center=�5�     $
��Name��5�     ���#1453745�     �� 5�     -   5        $9 cbBookWriter��5�     $��10,0,0,0q�5�     $��Center=�5�     $��Writer��5�     ���#1453745�     5�     5�     �� 5�     $��50��5�     $	��220��5�     $��
0,30,44,30q�5�     $8 6,3,6,3q�5�     ���	#4C005A8D$	��0.2q�5�     $ 12��5�     $��Right=�5�     ��5�     �� 5�     $	) 0,0&�6.   $	* 1,2&�6?   .��5�     � $	+ 0.5Q�6+   $, White��68   � 5�     $+ 1Q�6+   $, 	#FFF1F5FD��66   5�     - 5�       5�     $. 6Q�5�     $	/ 310Q�5�     $0 20Q�5�     $1 	#4CECECF0��5�     ._�5�     �� $��Right=�5�     $��Center=�5�     $ 
Horizontal=�5�     .+�5�     �� -   5        $��lblMemberName��5�     $��Center=�5�     $��Marvin Robson��5�     $��Fonts/#Titillium Web)�5�     $��14(�5�     �� 5�     $��40��5�     $��40��5�     $��Images/profile_mini.png��5�     5�     5�     5�     �� 5�     -   5        $��
tabMembers��5�     $��10,-15,10,10q�5�     
������ $��0q�5�     .@�5�     �� -   5        : ��Name$: tabItemBooks��5�     $y�	Collapsed=�60   .��5�     �� $��40,20,30,30q�5�     $8 10q�5�     ���	#4C116790$	��0.2q�5�     $ 12��5      ��5     �� 5     $	) 0,0&�62   $	* 1,2&�6C   .��5  "   � $	+ 0.5Q�6/   $, White��6<   � 5  "   $+ 1Q�6/   $, 	#FFF1F5FD��6:   5     - 5       5     $. 12Q�5	  !   $	/ 310Q�5
  !   $0 20Q�5  !   $1 	#4CECECF0��5  !   ._�5     �� -   5        $��
lsAllBooks��5     $��
-5.9,0,0,0q�5     $��Stretch=�5     $��0q�5     #��[ 5     5     5     �� 5     -   5        $: tabItemMyBooks��5     $y�	Collapsed=�62   .��5     �� $��40,20,30,30q�5     $8 10q�5     ���	#4C116790$	��0.2q�5     $ 12��5     ��5     �� 5     $	) 0,0&�62   $	* 1,2&�6C   .��5  "   � $	+ 0.5Q�6/   $, White��6<   � 5   "   $+ 1Q�6/   $, 	#FFF1F5FD��6:   5!     - 5#       5$     $. 12Q�5%  !   $	/ 310Q�5&  !   $0 20Q�5'  !   $1 	#4CECECF0��5(  !   ._�5*     �� -   5        $��	lsMyBooks��5+     $��
-5.9,0,0,0q�5,     $��Stretch=�5-     $��0q�5.     #��[ 5/     50     51     �� 52     -   5        $: tabItemMembership��52     $y�	Collapsed=�65   .��53     �� .+�54     �� $	��200��55     $��40,20,30,20q�56     ���	#4C116790$	��0.2q�58     $ 12��59     ��5:     �� 5;  "   $	) 0,0&�66   $	* 1,2&�6G   .��5<  &   � $	+ 0.5Q�63   $, White��6@   � 5=  &   $+ 1Q�63   $, 	#FFF1F5FD��6>   5>  #   - 5@       5A  "   $. 12Q�5B  %   $	/ 310Q�5C  %   $0 20Q�5D  %   $1 	#4CECECF0��5E  %   ._�5G     �� $ Vertical=�6)   .+�5H  "   �� $��	40,40,0,0q�5I  %   $��Remaining Days :��5J  %   $��Fonts/#Titillium Web)�5K  %   $��24(�5L  %   $
��Bold"�5M  %   ���#11698E5N  %   �� 5O  "   -   5        $��lblMembershipDays��5P  %   $��40,0,0,0q�5Q  %   $��23��5R  %   $��Fonts/#Titillium Web)�5S  %   $��20(�5T  %   ���#11698E5U  %   �� 5V  "   $	��200��5W  %   $	��200��5X  %   $��400,-120,0,0q�5Y  %   $5 0.5,0.5&�5Z  %   $��Images/wallet.png��5[  %   z�5\  &   V� 5]  *   .~�5^  .   �� �� 5_  .   �� 5`  .   $	6 -20Q�6>   T� 5a  .   5b  +   5d  #   5e     5f     �� 5g     -   5        $��btnRenewMembership��5h     $	��180��5i     $��50��5j     $��
40,0,20,20q�5k     $
��Left=�5l     $��Stretch=�5m     
������ $��0q�5o     $��Renew Membership��5q     $��15(�5r     $
��Bold"�5s       tmpElevatedButton#���  5t     5u     5v     �� 5w     -   5        $: tabItemWallet��5w     $y�	Collapsed=�61   .��5x     �� .+�5y     �� $	��200��5z     $��40,20,30,20q�5{     ���	#4C116790$	��0.2q�5}     $ 12��5~     ��5     �� 5�  "   $	) 0,0&�66   $	* 1,2&�6G   .��5�  &   � $	+ 0.5Q�63   $, White��6@   � 5�  &   $+ 1Q�63   $, 	#FFF1F5FD��6>   5�  #   - 5�       5�  "   $. 12Q�5�  %   $	/ 310Q�5�  %   $0 20Q�5�  %   $1 	#4CECECF0��5�  %   ._�5�     �� $ Vertical=�6)   .+�5�  "   �� $��	40,40,0,0q�5�  %   $��Your Wallet Balance :��5�  %   $��Fonts/#Titillium Web)�5�  %   $��24(�5�  %   $
��Bold"�5�  %   ���#11698E5�  %   �� 5�  "   -   5        $��lblMemberBalance��5�  %   $��40,0,0,0q�5�  %   $��1560$��5�  %   $��Fonts/#Titillium Web)�5�  %   $��20(�5�  %   ���#11698E5�  %   �� 5�  "   $	��200��5�  %   $	��200��5�  %   $��400,-120,0,0q�5�  %   $5 0.5,0.5&�5�  %   $��Images/wallet.png��5�  %   z�5�  &   V� 5�  *   .~�5�  .   �� �� 5�  .   �� 5�  .   $	6 -20Q�6>   T� 5�  .   5�  +   5�  #   5�     5�     � 5�     $
��Left=�6    5�     �� 5�  "   $��1* �63   �� 5�  "   $��1* �63   .+�5�     �� $��0��5�  !   $	��200��5�  !   $��50��5�  !   $��40,10,10,30q�5�  !   $8 0,3,0,3q�5�  !   $��Center=�5�  !   ���	#4C005A8D$	��0.2q�5�  !   $ 12��5�  !   ��5�  "   �� 5�  &   $	) 0,0&�6:   $	* 1,2&�6K   .��5�  *   � $	+ 0.9Q�67   $, White��6D   � 5�  *   $+ 1Q�67   $, 	#FFF1F5FD��6B   5�  '   - 5�  "     5�  &   $. 6Q�5�  )   $	/ 310Q�5�  )   $0 20Q�5�  )   $1 	#4CECECF0��5�  )   ._�5�  "   �� -   5        $��edtIncreaseBalance��5�  %   $	��180��5�  %   $��40��5�  %   $��Stretch=�5�  %   $��Stretch=�5�  %   $��Center=�5�  %   ���#FFF5FD$��Fonts/#Titillium Web)�5�  %   #���  5�  %   5�     �� 5�     -   5        $��btnIncreaseBalance��5�  !   $��1��5�  !   $	��180��5�  !   $��50��5�  !   $��
10,-20,0,0q�5�  !   $
��Left=�5�  !   $��Center=�5�  !   
������ $��0q�5�  !   $��Increase Balance��5�  !   $��15(�5�  !   $
��Bold"�5�  !   #���  5�  !   5�     5�     5�     �� 5�     -   5        $: tabItemInfo��5�     $y�	Collapsed=�6/   .��5�     �� $ Vertical=�6!   .+�5�     �� $��40,20,30,20q�5�     $8 10q�5�     ���	#4C116790$	��0.2q�5�     $ 12��5�     ��5�     �� 5�  "   $	) 0,0&�66   $	* 1,2&�6G   .��5�  &   � $	+ 0.5Q�63   $, White��6@   � 5�  &   $+ 1Q�63   $, 	#FFF1F5FD��6>   5�  #   - 5�       5�  "   $. 12Q�5�  %   $	/ 310Q�5�  %   $0 20Q�5�  %   $1 	#4CECECF0��5�  %   ._�5�     � $��0,0,0,15q�6#   2 5�  "   �� 5�  &   $��2* �64   �� 5�  &   $��1* �64   .+�5�  "   � $��0��6'    5   &   �� 5  *   $
��0.9* �6;   �� 5  *   $��1* �6;   .+�5  &   �� -   5        $��
btnProfile��5  )   $��0��5  )   $	��140��5  )   $	��140��5  )   $��0,20,0,0q�5	  )   #��[	 5
  )   .��5  *   �� $��75��5  -   $	��100��5  -   $��Button��5  -   5  '   � 5  &   $��2��6+   2 5  *   �� 5  .   $
��0.3* �6<   �� 5  .   $��1* �6<   �� 5  .   $��1* �6<   .+�5  *   �� $��1��65   $ Vertical=�6B   .+�5  .   �� $��70,0,0,2q�5  1   $
��Left=�5  1   $��Center=�5  1   
������ $��Fonts/#Titillium Web)�5  1   $��12(�5  1   ���#145374$��User name :��5  1   �� 5   .   -    5        $��edtUserName��5!  1   $	��200��5"  1   $��40��5#  1   $��20,0,0,0q�5$  1   $��Stretch=�5%  1   $��Stretch=�5&  1   $��Center=�5'  1   ���#FFF5FD$��Fonts/#Titillium Web)�5)  1   {�.  #��[ 5+  1   $��Marvin Robson��5,  1   5-  +   �� 5.  *   $��2��65   $ Vertical=�6B   .+�5/  .   �� $��70,0,0,2q�50  1   $
��Left=�51  1   $��Center=�52  1   
������ $��Fonts/#Titillium Web)�54  1   $��12(�55  1   ���#145374$��Phone number :��57  1   �� 58  .   -!   5        $��edtPhoneNumber��59  1   $	��200��5:  1   $��40��5;  1   $��20,0,0,0q�5<  1   $��Stretch=�5=  1   $��Stretch=�5>  1   $��Center=�5?  1   $��Fonts/#Titillium Web)�5@  1   #��[ 5A  1   $��09911557553��5B  1   5C  +   5D  '   5E  #   � 5F  "   $��1��6'    5G  &   �� 5H  *   $
��0.9* �6;   �� 5I  *   $��1* �6;   .+�5K  &   �� $��0��5L  )   $��40,0,0,0q�5M  )   $ Vertical=�5N  )   .+�5O  *   �� $��0,0,0,2q�5P  -   $
��Left=�5Q  -   $��Center=�5R  -   
������ $��Fonts/#Titillium Web)�5T  -   $��12(�5U  -   ���#145374$��Email :��5W  -   �� 5X  *   -"   5        $��edtEmail��5Y  -   $	��240��5Z  -   $��40��5[  -   $��	-20,0,0,0q�5\  -   $��Stretch=�5]  -   $��Stretch=�5^  -   $��Center=�5_  -   $��Fonts/#Titillium Web)�5`  -   #��[ 5a  -   $��testemail@gmail.com��5b  -   5c  '   �� 5d  &   $��1��61   $ Vertical=�6A   .+�5e  *   �� $��70,0,0,2q�5f  -   $
��Left=�5g  -   $��Center=�5h  -   
������ $��Fonts/#Titillium Web)�5j  -   $��12(�5k  -   ���#145374$��
Password :��5m  -   G� 5n  *   -#   5        $��edtPassword��5o  -   $	��200��5p  -   $��40��5q  -   $��20,0,0,0q�5r  -   $��Stretch=�5s  -   $��Stretch=�5t  -   $��Center=�5u  -   ���	#FFEAE9EC$��Fonts/#Titillium Web)�5w  -     tmpRoundedPassBox#��[ 5x  -   5y  '   5z  #   5{     5|     �� 5}     -$   5        $��btnApplyChanges��5~     $	��150��5     $��50��5�     $��
40,0,20,20q�5�     $
��Left=�5�     $��Stretch=�5�     
������ $��0q�5�     $��Apply Changes��5�     $��15(�5�     $
��Bold"�5�     #���  5�     5�     5�     5�     5�     5�     5�     