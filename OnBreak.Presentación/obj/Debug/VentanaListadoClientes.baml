   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   P LOnBreak.Presentación, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnBreak.PresentaciónOnBreak.Presentación 5	   	   2   ,OnBreak.Presentación.VentanaListadoClientes   5      R NMahApps.Metro.IconPacks, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OnBreak.Presentación     5	   	     � Title$#  OnBreak - Listado de Clientes��5   	   $	��449��6/   $
��1117��6<    � Icon$ img/onbreak.ico��6I   .��5      � $��0,0,2,0q�6    � ColumnDefinitions 5   
   �� 5      $	��23* �6   �� 5      $
��175* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgListadoClientes��5      $
��Left=�6/   $	��321��6J   $��	34,78,0,0q�6W   $	��Top=�6j   $	��785��6�   $��2��6�      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�   �� 5   
   -   5         ��Name$ btnMostrarListClientes��5      $��Mostrar Clientes��61   $��1��6L   $
��Left=�6\   $��
717,78,0,0q�6w   $	��Top=�6�   $	��228��6�   6�   !   MahApps.Metro.Controls.Tile  5   
   -   5          Name$ 	btnVolver��5      $��10,10,70,363q�6+   $
��Auto��6A   $��49��6O      Title$ Volver��6Z   	   TitleFontSize$	 7Q�6i   .��5      �� $��img/volver.png��6   $��20��6,   $��20��67   6E   5      �� 5   
   $��1��6   $��Filtros��6#   $
��Left=�64   $	��260��6O   $��717,139,0,0q�6\   $	��Top=�6q   $	��228��6�   .��5      � -   5        
 �Name$
 
gridFiltro��5      $
��Left=�6'   $	��228��6B   $	��Top=�6O   $	��218��6g   $��0,0,0,-3q�6s   .+�5      �� -   5         ��Name$ txtRutFiltro��5      $
��Left=�60   $��23��6K   $��	30,10,0,0q�6W    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��160��6�   *   $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$ Ingrese su Rut��5      �� 5      -   5         ��Name$ cmbTipoEmpresaFiltro��5      $
��Left=�69   $��	52,80,0,0q�6T   $	��Top=�6g   $	��120��6   �� 5      -   5        $ cmbActividadEmpresaFiltro��5      $
��Left=�6>   $��
52,143,0,0q�6Y   $	��Top=�6m   $	��120��6�   �� 5      -   5         ��Name$ lblActividadEmpresaFiltro��5      $��Actividad Empresa��6;   $
��Left=�6W   $��26��6r   $��
52,111,0,0q�6~   $	��Top=�6�   $	��120��6�   �� 5      -	   5        $ lblTipoEmpresaFiltro��5      $��Tipo Empresa��66   $
��Left=�6M   $��	52,49,0,0q�6h   $	��Top=�6{   $	��120��6�   �� 5      -
   5        $ btnFiltrarList��5      $��Filtrar��61   $
��Left=�6C   $��
52,189,0,0q�6^   $	��Top=�6r   $	��117��6�   6�   5       5!      �� 5"   
   -   5        $ 	btnEditar��5"      $��Editar Seleccionado��6$   $��1��6B   $
��Left=�6R   $��
717,35,0,0q�6m   $	��Top=�6�   $	��228��6�   6�   �� 5#   
   -   5         ��Name$ 	imgOBlogo��5#      $
��Left=�6#   $	��337��6>   $��129,84,0,-3q�6K   $	��Top=�6`   $	��337��6x   $)��#img/logo_transparent_background.png��6�    �� BitmapScalingMode$ NearestNeighbor=�5$       �� EdgeMode$ Aliased=�6B   $
��Fill=�6c    J� Opacity$
 0.45Q�6r   $��1��6�   5%      5&      