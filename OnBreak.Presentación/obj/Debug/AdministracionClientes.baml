   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LOnBreak.Presentación, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnBreak.PresentaciónOnBreak.Presentación 5	   	   2   ,OnBreak.Presentación.AdministracionClientes   5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OnBreak.Presentación     5	   	     � Title$(  "OnBreak - Administración Clientes��5   	   $��437.2��63   $��754.6��6B    � Icon$ img/onbreak.ico��6P   .��5      � .+�5   
   �� -   5         ��Name$ 	imgOBlogo��5      $
��Left=�6#   $	��337��6>   $��
407,45,0,0q�6K   $	��Top=�6_   $	��337��6w   $)��#img/logo_transparent_background.png��6�    �� BitmapScalingMode$ NearestNeighbor=�5       �� EdgeMode$ Aliased=�6B   $
��Fill=�6c    J� Opacity$
 0.45Q�6r   �� 5   
   -   5         ��Name$ lblRutCliente��5      $��Rut Cliente: ��6'   $
��Left=�6?   $��	34,60,0,0q�6Z   $	��Top=�6m   $��32��6�   $	��127��6�   $��14(�6�   �� 5   
   $��Razón Social Cliente:��6   $
��Left=�60   $��	34,98,0,0q�6K   $	��Top=�6^   $	��158��6v   $��14(�6�   �� 5   
   -   5        $ lblDireccionCliente��5      $��Dirección Cliente:��6-   $
��Left=�6J   $��
34,137,0,0q�6e   $	��Top=�6y   $��14(�6�   $	��127��6�   �� 5   
   -   5        $ lblNombreCliente��5      $��Nombre Cliente:��6*   $
��Left=�6D   $��
34,176,0,0q�6_   $	��Top=�6s   $��14(�6�   $	��127��6�   �� 5   
   -   5        $ lblEmailCliente��5      $��Email Cliente:��6)   $
��Left=�6B   $��
34,217,0,0q�6]   $	��Top=�6q   $��14(�6�   $	��127��6�   �� 5   
   -   5        $ lblTelefonoCliente��5      $��Teléfono Cliente:��6,   $
��Left=�6H   $��
34,261,0,0q�6c   $	��Top=�6w   $	��127��6�   $��14(�6�   �� 5   
   -   5        $ lblActividadEmpresa��5      $��Actividad Empresa:��6-   $
��Left=�6J   $��
34,302,0,0q�6e   $	��Top=�6y   $��14(�6�   �� 5   
   -   5        $ lblTipoEmpresa��5      $��Tipo Empresa:��6(   $
��Left=�6@   $��
34,343,0,0q�6[   $	��Top=�6o   $��14(�6�   $	��127��6�   �� 5   
   -	   5         ��Name$ txtRutCliente��5      $
��Left=�6)   $��23��6D   $��
198,60,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��203��6�   �� 5   
   -
   5        $ txtRazonSocial��5      $
��Left=�6*   $��24��6E   $��198,101,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��203��6�   �� 5   
   -   5        $ txtDireccionCliente��5      $
��Left=�6/   $��23��6J   $��198,140,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $	��203��6�   �� 5   
   -   5        $ txtNombreCliente��5      $
��Left=�6,   $��23��6G   $��198,179,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��203��6�   �� 5   
   -   5        $ txtEmailCliente��5      $
��Left=�6+   $��23��6F   $��198,220,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��203��6�   �� 5   
   -   5        $ txtTelefonoCliente��5      $
��Left=�6.   $��23��6I   $��198,264,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��203��6�   �� 5   
   -   5        	 ��Name$	 cmbActividadEmpresa��5      $
��Left=�60   $��198,305,0,0q�6K   $	��Top=�6`   $	��203��6x   �� 5   
   -   5        $	 cmbTipoEmpresa��5      $
��Left=�6+   $��198,346,0,0q�6F   $	��Top=�6[   $	��203��6s   �� 5   
   -   5        
 ��Name$
 btnBuscarClienteRut��5      $��Buscar Cliente por Rut��6.   $
��Left=�6O   $��484,269,0,0q�6j   $	��Top=�6   $	��188��6�   $��32��6�   6�   �� 5    
   -   5        $
 btnClienteListado��5       $ ��Buscar Cliente por Listado��6,   $
��Left=�6Q   $��484,310,0,0q�6l   $	��Top=�6�   $	��188��6�   $��31��6�   6�   �� 5!   
   -   5        $
 btnAgregarCliente��5!      $��Agregar Cliente��6,   $
��Left=�6F   $��
484,52,0,0q�6a   $	��Top=�6u   $	��188��6�   $��31��6�   6�   �� 5"   
   -   5        $
 btnActualizarCliente��5"      $��Actualizar Cliente��6/   $
��Left=�6L   $��
484,95,0,0q�6g   $	��Top=�6{   $	��188��6�   6�   �� 5#   
   -   5        $
 btnEliminarCliente��5#      $��Eliminar Cliente��6-   $
��Left=�6H   $��484,136,0,0q�6c   $	��Top=�6x   $	��188��6�   6�   �� 5$   
   -   5        $
 btnLimpiarCliente��5$      $��Limpiar��6,   $
��Left=�6>   $��484,349,0,0q�6Y   $	��Top=�6n   $	��188��6�   $��31��6�   6�   !   MahApps.Metro.Controls.Tile  5%   
   -   5          Name$ 	btnVolver��5%      $��10,9,688,352q�6+   $
��Auto��6A   $
��Auto��6O      Title$ Volver��6\      TitleFontSize$ 7Q�6k   .��5&      �� $��img/volver.png��6   $��20��6,   $��20��67   6E   5'      5(      5)      