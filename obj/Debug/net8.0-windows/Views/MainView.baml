   M S B A M L   `   `   `  ����L  HTulingScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TulingScadaSystem.ViewsTulingScadaSystem.Views  5      K*clr-namespace:TulingScadaSystem.ViewModelsTulingScadaSystem.ViewModels  5	      &     TulingScadaSystem.Views.MainView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      1local%clr-namespace:TulingScadaSystem.Views  5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      5vm*clr-namespace:TulingScadaSystem.ViewModels   5	       #  MaterialDesign.Brush.Background#���   5      $��Microsoft YaHei)�5      $��16(�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5      .��5      ]� .+�5   
   ]� ���#546e7a$
��Left=�6)   .+�5      �� $	��Top=�6   .+�5      ��   � Cursor$
  Hand��6   $��Disabled=�5       �� SelectedIndex$ 0��5      ��5      �� *MenuEntities+��5      �� 5      .R�5      �� $��80��6)   $��0,5,0,5q�5   )   
������ *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5    "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5!   &      	EventName$ PreviewMouseUp��65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5"   *   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6@   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType UserControl	 �� Path$#	 DataContext.NavigationCommand�
   CommandParameter
 6�   �� 5#   '   .+�5%   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��20��6:   $��20��5&   :   $��5q�5'   :   $��Center=�5(   :   $��Center=�5)   :   
������ 
�������   Kind 5,   :   �� *Icon+�� 5-   "   $��Center=�6,   $��Center=�5.   ,   $��15(�5/   ,   
������� % !MaterialDesignTitleSmallTextBlock#��[ 51   ,   ��52   ,   �� *
MenuName+53      54      56      57      �� 58      $��0,15,0,4q�6   $��Bottom=�59      $��Bottom=�5:       5;        5<      $ PreviewMouseUp��6%   . 5=         60   �� *ChangeUserCommand+5>      .+�5@        $��25��6*   $��25��5A   *   $��Center=�5B   *   $��Center=�5C   *   
������ 
�������$ ArrowLeftBoldCircle=�5F   *   �� 5G      $��Center=�6   $��Center=�5H      $��18(�5I      
�������$��切换用户��5K      5L      5M      ]� 5N   
   ]� 5O   
   .+�5P      �  � RowDefinitions 5Q      �� 5R      �� 5S      $
��auto �6$   .+�5V      �� -   5         ��Name$
 Page��5V   !   $��Stretch=�5W   !   $��Stretch=�5X   !   �� 5Y      $��1��6   ���#cfd8dc �� Orientation$ 
Horizontal=�5[      .+�5\      �� $��0,0,5,0q�6$   $"��[Spray Process SCADA System]��5]   $   
�������5^   $   �� 5_      $��0,0,5,0q�6$   $��当前用户��5`   $   
�������5a   $   �� 5b      $��0,0,5,0q�6$   
���������5c   $   �� *&$UserSessionProp.CurrentUser.UserName+5d   $   5e      5f      5g      5h      5i      