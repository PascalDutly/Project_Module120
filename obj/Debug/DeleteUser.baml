   M S B A M L   `   `   `  ����F  BProjekt_120, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Projekt_120Projekt_120  5          Projekt_120.DeleteUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Projekt_120     5      .��5	      �   � RowDefinitions  5   
   �� 5      $	��296 �6   6+   �� 5      $��* �6   6)   .+�5   
   �� -   5        $��Title��5   �   
�������$��Bewohner löschen��6&   $
��Left=�6A   $	��Top=�6\   $��30(�6t    � ToolTip$ Gemeindeverwaltung��6�   $
��2000��6�   $��	0,246,0,0q�6�   �� 5   
   
�������$��1��6(   .+�5      ]� -   5        $��SwitchContainer��5   9   $��1��6   $��0,0,0,0q�6(   ��. 6P   �� 5      $��
BewohnerID��6    �� Left$ 83��6)   
 �� Top$	 101��6:   $��12(�6K   �� 5      $
��Name��6   $	 113��6#   $	 132��65   $��12(�6F    J� RenderTransformOrigin$ -0.037,0.658&�6T   �� 5      $��vorname��6   $	 101��6&   $	 159��68   $��12(�6I   �� 5      -   5        $��	CitizenID��5      $��23��6'   $	 161��63    �� TextWrapping$
 Wrap=�6E   $	 101��6Y   $	��129��6j   �� 5      -   5        $
��Name��5      $��23��6"   $	 161��6.   $
 Wrap=�6@   $	 132��6T   $	��129��6e   ���	#FFAAAAAA �� 
IsReadOnly . 6�   �� 5      -   5        $��	FirstName��5      $��23��6'   $	 161��63   $
 Wrap=�6E   $	 163��6Y   $	��129��6j   ���	#FFAAAAAA . 6�   �� 5      -   5         ��Name$ button��5      
�������$
��Left=�68   $	��Top=�6S   $��50��6k   $��50��6v   $	 161��6�   $	 200��6�   .��5      �� $e��_C:\Users\vmadmin\Documents\Visual Studio 2017\Projects\Projekt_120\Projekt_120\Icons\Delete.png��6    � Cursor$
 Hand��6�   5      �� 5      -   5        $��Warning��5      $ 92��6'   $
��Wrap=�68   $	 268��6L   $��40��6]   $	��171��6i   
���   �	 J� Opacity$	 0Q�6�   �� 6�   $@�:Sind Sie sicher, dass Sie diesen Benutzer löschen wollen?��6�   6�   �� 5       -   5        $��Warning1��5       $��Ja��6%   $ 92��62   $	 308��6C   $��75��6T   $	 0Q�6_   $
 Hand��6�   �� 5!      -	   5        $��Warning2��5!      $
��Nein��6%   $	 188��64   $	 308��6F   $��75��6W   $	 0Q�6b   $
 Hand��6�   �� 5"      -
   5        $��number��5"      $,��&Bitte geben Sie eine gültige Zahl ein��6"   $	 295��6R   $	 101��6d   ���	#FFDB0C0C$	 0Q�6�   5%      5&      5'      