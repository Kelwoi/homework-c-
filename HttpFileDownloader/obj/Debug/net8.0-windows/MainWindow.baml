   M S B A M L   `   `   `  ����M  IHttpFileDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HttpFileDownloaderHttpFileDownloader  5   	   #    HttpFileDownloader.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:HttpFileDownloader     5   	     � Title$  HTTP File Downloader��5   	   $	��450��6&   $	��700��63   ���#FAFAFA � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5         AccentBrush �� Color �� 
TargetType �� Property �� Value4   .HttpFileDownloader.StatusToVisibilityConverter  StatusToVisibilityConverter��%�  &	        '�� !     7   '�� �    '��     &	 z    �� 5   
   $ #0078D7��6.   �� 5	   
   " ��6   .�5
      ��  � ��$ 5q�6'   �� 5       � ��$	 8,4q�6(   �� 5       � ��$ 14(�6)   �� 5       � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�SnapsToDevicePixels$
 True��64   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 14(�6)   �� 5       � ��$ 6q�6(   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 13(�6)   5        5   
   6,   5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $��* �6   .+�5'   
   �� $��Enter URL to download:��6   $��
10,10,10,0q�62   $��16(�6F   $
��Bold"�6T   �� 5)   
    �� Orientation$ 
Horizontal=�6   $��10q�6.   $��1��6:   .+�5*      �� -   5        	 ��Name$	 
UrlTextBox��5*      $	��400��6*   $��30��66   �� 5+      -   5        $��Download��5+      $	��100��6(   64   5,      �� 5.   
   -   5        
 ��Name$
 DownloadsList��5.      $��2��6*   $	��300��67    �� View 5/      �� 50      .P�51      �� $��	File Name��6%    �� Width$	 180��6b    �� DisplayMemberBinding 68   �� *
FileName+6b   �� 52      $
��Size��6%   $ 80��6Y    63   �� *Size+6Y   �� 53      $��Status��6%   $	 140��6]    65   �� *Status+6]   �� 54      $��Action��6%   $	 100��65    �� CellTemplate 55      �� 56      .R�57   "   �� -   5        $��Cancel��57   )   y�58   )   �� *Status+ �� 	Converter# [ 59      5;      5<      5>      5?      5@      