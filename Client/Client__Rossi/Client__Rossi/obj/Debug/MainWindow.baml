   M S B A M L   `   `   `  ����H  DClient__Rossi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Client__RossiClient__Rossi  5   	       Client__Rossi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Client__Rossi     5   	     � Title$  WebServiceBooks v0.1��5   	   $	��520��6&   $
��1000��63   ��5	      �� 5
   
    �� ImageSource$ WallpaperBookshelf.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ lstPrint��5      $
��Left=�6$   $	��469��6?   $��
584,10,0,0q�6L   $	��Top=�6`   $	��398��6x   �� 5   
   -   5         ��Name$ btn_ClearListBox��5      $��Pulisci Lista��6+   $
��Left=�6C   $��451,344,0,0q�6^   $	��Top=�6s   $	��117��6�   $��55��6�   6�   �� 5   
   -   5        $ btn_PrintPurchasedBooks��5      $��Stampa elenco��62   $
��Left=�6J   $��233,343,0,0q�6e   $	��Top=�6z   $	��117��6�   $��56��6�   6�   �� 5   
   -   5        $ btn_PrintDepartments��5      $��Stampa elenco��6/   $
��Left=�6G   $��264,166,0,0q�6b   $	��Top=�6w   $	��117��6�   $��57��6�   6�   �� 5   
   -   5        $ btn_PrintLastArrival��5      $��Stampa Quantità��6/   $
��Left=�6I   $��
10,166,0,0q�6d   $	��Top=�6x   $	��120��6�   $��56��6�   6�   �� 5   
   -   5        $ btn_PrintArchived��5      $��Stampa elenco��6,   $
��Left=�6D   $��	8,343,0,0q�6_   $	��Top=�6r   $	��117��6�   $��56��6�   6�   �� 5   
   $
��Left=�6   $��51��6-   $��
10,110,0,0q�69    �� TextWrapping$
 Wrap=�6M   $B��<Stampa quantità dei libri ultimi arrivi nel reparto fumetti��6a   $	��Top=�6�   $	��120��6�   �� 5   
   $
��Left=�6   $��51��6-   $��264,110,0,0q�69   $
 Wrap=�6N   $Z��Telenco dei libri scontati presenti in tutti i reparti in ordine crescente per sconto��6b   $	��Top=�6�   $	��160��6�   �� 5   
   -   5        $ btn_Catalog��5      $��Visualizza Catalogo��6&   $
��Left=�6D   $��0,18,0,0q�6_   $	��Top=�6q   $	��131��6�   $��32��6�   6�   �� 5   
   $
��Left=�6   $��41��6-   $��	8,260,0,0q�69   $
 Wrap=�6L   $	��Top=�6`   $	��220��6x   $M��Gelenco libri archiviati all'interno di un periodo definito da due date ��6�   �� 5   
   $
��Left=�6   $��41��6-   $��233,260,0,0q�69   $
 Wrap=�6N   $}��w elenco dei titoli dei libri acquistati con il rispettivo numero copie e username dell'utente associato a quel carrello��6b   $	��Top=�6�   $	��325��6�   �� 5   
   -   5         ��Name$ txt_ShoppingCartCode��5      $
��Left=�60   $��23��6K   $��233,306,0,0q�6W   $
 Wrap=�6l   $��Codice del carrello��6�   $	��Top=�6�   $	��171��6�   �� 5   
   -	   5        $ txt_FirstDate��5      $
��Left=�6)   $��23��6D   $��	8,306,0,0q�6P   $
 Wrap=�6c   $��
GG/MM/AAAA��6w   $	��Top=�6�   $	��110��6�   �� 5   
   -
   5        $ txt_SecondDAte��5      $
��Left=�6*   $��23��6E   $��123,306,0,0q�6Q   $
 Wrap=�6f   $��
GG/MM/AAAA��6z   $	��Top=�6�   $	��105��6�   5      5      