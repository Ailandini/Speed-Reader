   M S B A M L   `   `   `  ����G  CSpeed Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Speed_ReaderSpeed_Reader  5   	       Speed_Reader.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Speed_Reader     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � 
����  �.+�5   
   � -   5        $��Page1��5      $y�Visible=�6   .+�5      �� -   5        $��FileName��5   1   $
��Left=�6   $��23��6A   $��
10,221,0,0q�6M    �� TextWrapping$
 Wrap=�6a    �� 
IsReadOnly . $�� ��6�   $	��Top=�6�   $	��316��6�   �� 5      -   5        $��Instructions��5   3   $
��Left=�6   $��
10,189,0,0q�6G   $
��Wrap=�6[   $:��4Please select the file you would like to speed read:��6o   $	��Top=�6�   
�������$	��351��6�   $��27��6�   �� 5      -   5        $��Title��5   3   $
��Left=�6   $��	10,15,0,0q�6@   $
��Wrap=�6S   $��Speed Reader 1.2��6g   $	��Top=�6   $��87��6�   
����ح�$	��409��6�   $��48(�6�   �� 5      -   5        $��BrowseButton��5   &   $��Browse��6   $
��Left=�6:   $	��Top=�6U   $��75��6m   $��331,221,0,0q�6x   $��23��6�   6�   �� 5      -   5        $��SubmitButton��5   &   $��Submit��6   $
��Left=�6:   $��411,221,0,0q�6U   $	��Top=�6j   $��75��6�   $��23��6�   6�   5      � 5   
   -   5        $��Page2��5      $y�Hidden=�6   .+�5      �� -   5        $��WordPane��5   1   $
��Left=�6   $	��114��6A   $��	0,102,0,0q�6N   $
 Wrap=�6a    . $��TextBox��6�   $	��Top=�6�   $	��517��6�   
��� ���
���   �$��72(�6�    �� TextAlignment$ Center=�6�   
�������6
  �� 5      -	   5        $��ResetButton��5   (   $��<<��6   $
��Left=�6;   $��	10,54,0,0q�6V   $	��Top=�6i   $��33��6�   $��31��6�   6�   �� 5      -
   5        $��SPButton��5   0   $
��Left=�6   $��Start/Pause��6@   $��216,253,0,0q�6V   $	��Top=�6k   $��83��6�   $��34��6�   6�   �� 5      $
��Left=�6   $��
360,55,0,0q�63   $
��Wrap=�6G   
�������$
��WPM:��6n   $	��Top=�6z   $��25��6�   $��60��6�   $��20(�6�   �� 5      -   5        $��
BackButton��5   $   $
��Back��6   $
��Left=�66   $��	10,10,0,0q�6Q   $	��Top=�6d   $��75��6|   $��33��6�   6�   �� 5      -   5        $	��WPM��5   =   $
��Left=�6   $��31��61   $��
425,54,0,0q�6I   $
 Wrap=�6]   
���  ��
����  �
����  �$	��200��6�   $��62��6�   $��22(�6�   $	��Top=�6�   $ Center=�6�   $
��Bold"�6   �� 	MaxLength$ 3��6  �� 5      -   5        $��wordCountEnd��5   3   $
��Left=�6   $��
143,55,0,0q�6G   $
��Wrap=�6[   
�������$	��Top=�6�   $��81��6�   $��30��6�   $	��of ��6�   $��20(�6�   �� 5      -   5        $��wordCountStart��5   1   $
��Left=�6   $��31��6H   $��	71,54,0,0q�6T   $
 Wrap=�6g   $	��Top=�6{   $��67��6�   $ Right=�6�   $��1��6�   $��20(�6�    �� MaxLines$ 
2147483646��6�   $ 5��6
  �� 5      -   5        $��BackwordButton��5   ?   $��<��6   $
��Left=�6$   $��	48,54,0,0q�6U   $	��Top=�6h   $��18��6�   $��31��6�   6�   5      5      5      