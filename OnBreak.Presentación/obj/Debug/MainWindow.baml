   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LOnBreak.Presentación, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnBreak.PresentaciónOnBreak.Presentación 5	   	   &    OnBreak.Presentación.MainWindow   5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro    5   	   NControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OnBreak.Presentación     5	   	   -   5          � Title$  OnBreak - Inicio��5   	   $��437.2��6"   $��898.763��61    � Icon$ img/onbreak.ico��5      .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��7* �6    � ColumnDefinitions 5   
   �� 5      $
��395* �6   �� 5      $
��123* �6   .+�5   
   �� -   5         ��Name$ 	imgOBlogo��5      $
��Left=�6#   $��545,39,0,30.2q�6>   $	��337��6U   $)��#img/logo_transparent_background.png��6a    �� BitmapScalingMode$ NearestNeighbor=�5       �� EdgeMode$ Aliased=�6B   $
��Fill=�6c   $��2��6r   $��2��6�   !   MahApps.Metro.Controls.Tile  5   
   -   5          Name$ 
tileAdmCli��5      $��21,65,425,214.2q�6,   $
��Auto��6E   $
��Auto��6R      Title$ Administración Clientes��6`   $��2��6�   ���	#FF1BA1E2.��5      .  (MahApps.Metro.IconPacks.PackIconMaterial  E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Account=�6)   $��61��68   $��81��6D   $��Right=�6O   $��Center=�6k   5        5   
   -   5        $ tileListCli��5      $��279,65,167,214.2q�6-   $
��Auto��6G   $
��Auto��6T   $ Listado Clientes��6b   $��2��6{   ���	#FF1BA1E2.��5        $	 FileAccount=�6)   $��63��6<   $��74��6H   $	��Top=�6S   5        5   
   -   5        $ 
tileAdmCon��5      $��21,71,425,60.2q�6,   $
��Auto��6D   $
��Auto��6Q   $ Administración Contrato��6_   ���	#FF1BA1E2$��1��6�   .��5        $	 FileDocument=�6)   $��63��6=   $��74��6I   $	��Top=�6T   5         5!   
   -   5        $ tileListCon��5!      $��279,71,167,60.2q�6-   $
��Auto��6F   $
��Auto��6S   $ Listado Contratos��6a   ���	#FF1BA1E2$��1��6�   .��5"        $	 FileMultiple=�6)   $��63��6=   $��74��6I   $	��Top=�6T   5#      5$      5%      