   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LOnBreak.Presentación, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnBreak.PresentaciónOnBreak.Presentación 5	   	   2   ,OnBreak.Presentación.VentanaListadoContrato   5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OnBreak.Presentación     5	   	     � Title$#  OnBreak - Listado de Clientes��5   	   $	��449��6/   $
��1330��6<    � Icon$ img/onbreak.ico��6I   .��5      � $��0,0,2,0q�6    � ColumnDefinitions 5   
   �� 5      $
��129* �6   �� 5      $
��823* �6   �� 5      $	��26* �6   �� 5      $
��127* �6   �� 5      $��3* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgListarContrato��5      $
��Left=�6.   $	��321��6I   $��	34,78,0,0q�6V   $	��Top=�6i   $	��785��6�   $��2��6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   �� 5   
   -   5         ��Name$ btnMostrarListContratos��5      $��Mostrar Contratos ��62   $��1��6O   $
��Left=�6_   $��
800,84,0,0q�6z   $	��Top=�6�   $	��228��6�   $��3��6�   6�   !   MahApps.Metro.Controls.Tile  5   
   -   5          Name$ 	btnVolver��5      $��10,10,70,363q�6+   $
��Auto��6A   $��49��6O      Title$ Volver��6Z   	   TitleFontSize$	 7Q�6i   .��5      �� $��img/volver.png��6   $��20��6,   $��20��67   6E   5      �� 5   
   $��1��6   $��Filtros��6#   $
��Left=�64   $	��260��6O   $��717,139,0,0q�6\   $	��Top=�6q   $	��355��6�   $��3��6�   .��5      � -   5        
 �Name$
 
gridFiltro��5      $
��Left=�6'   $	��228��6B   $	��Top=�6O   $	��345��6g   $��0,0,0,-3q�6s   .+�5      �� -   5         ��Name$ txtRutFiltro��5      $
��Left=�60   $��23��6K   $��	12,63,0,0q�6W    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��160��6�   *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$ Ingrese su Rut��5      �� 5      -   5         ��Name$ cmbTipoEventoFiltro��5      $
��Left=�68   $��
12,143,0,0q�6S   $	��Top=�6g   $	��160��6   6�   �� 5      -   5        $  cmbModalidadServicioFiltro��5      $
��Left=�6?   $��177,143,0,0q�6Z   $	��Top=�6o   $	��158��6�   �� 5       -   5         ��Name$ lblModalidadServicio��5       $��Modalidad Servicio��66   $
��Left=�6S   $��26��6n   $��192,107,0,0q�6z   $	��Top=�6�   $	��120��6�   �� 5!      -	   5        $ lblTipodeEvento��5!      $��Tipo de Evento��61   $
��Left=�6J   $��
37,107,0,0q�6e   $	��Top=�6y   $	��120��6�   �� 5"      -
   5        $ btnFiltrarList��5"      $��Filtrar��61   $
��Left=�6C   $��116,183,0,0q�6^   $	��Top=�6s   $	��117��6�   6�   �� 5#      -   5        $ 	txtNumero��5#      $
��Left=�6-   $��23��6H   $��
177,63,0,0q�6T   $
 Wrap=�6h   $	��Top=�6|   $	��160��6�    . $ Ingrese Número Contrato��5%      	� 5&      -   5         	�Name$ rbtRut��5&      $��Filtrar por RUT��6.   $
��Left=�6H   $��	35,38,0,0q�6c   $	��Top=�6v   	� 5'      -   5        $ 
rbtConNumb��5'      $��Filtrar por N°��62   $
��Left=�6K   $��
198,38,0,0q�6f   $	��Top=�6z   	� 5(      -   5        $ rbtNoFilter��5(      $"��No filtrar por RUT ni Numero��63   $
��Left=�6Z   $��	86,10,0,0q�6u   $	��Top=�6�   5)      5*      �� 5+   
   -   5        $ btnEditarContrato��5+      $��Editar Seleccionado��6,   $��1��6J   $
��Left=�6Z   $��
800,35,0,0q�6u   $	��Top=�6�   $	��228��6�   $��3��6�   6�   �� 5,   
   -   5         ��Name$ 	imgOBlogo��5,      $
��Left=�6#   $	��337��6>   $��129,84,0,-3q�6K   $	��Top=�6`   $	��337��6x   $)��#img/logo_transparent_background.png��6�    �� BitmapScalingMode$ NearestNeighbor=�5-       �� EdgeMode$ Aliased=�6B   $
��Fill=�6c    J� Opacity$
 0.45Q�6r   $��1��6�   5.      5/      