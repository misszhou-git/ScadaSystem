   M S B A M L   `   `   `  ����L  HTulingScadaSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TulingScadaSystem.UcsTulingScadaSystem.Ucs  5      -    'TulingScadaSystem.Ucs.PaginationControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:TulingScadaSystem.Ucs     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �� $��5q�6   $��Center=�5	        �� Orientation$  
Horizontal=�5
      .+�5   
   �� $��30��6   $��0,0,5,0q�5      $��<<��5         TulingButtonStyle#���   5      ��5      �� *GoToFirstPageCommand+5      �� 5   
   $��30��6   $��0,0,5,0q�5      $��<��5      #���   5      ��5      �� *GoToPreviousPageCommand+5      �� 5   
   $��30��6   $��0,0,5,0q�5      $��Center=�5      $��Center=�5       �� TextAlignment$ Center=�5      ��5      �� *CurrentPage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��30��6   $��0,0,5,0q�5      $��>��5      #���   5      ��5      �� *GoToNextPageCommand+5      �� 5    
   $��30��6   $��0,0,5,0q�5!      $��>>��5#      #���   5$      ��5"      �� *GoToLastPageCommand+5$      �� 5%   
   $��20,0,5,0q�6   $��Center=�5&      $��
总页码:��5'      �� 5(   
   $��20,0,5,0q�6   $��Center=�5)      ��5*      �� *
TotalPages+5+      5,      