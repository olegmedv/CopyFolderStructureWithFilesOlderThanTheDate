   M S B A M L   `   `   `  ????g  cCopyFolderStructureWithFilesOlderThanTheDate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:CopyFolderStructureWithFilesOlderThanTheDate,CopyFolderStructureWithFilesOlderThanTheDate  5   	   =    7CopyFolderStructureWithFilesOlderThanTheDate.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:CopyFolderStructureWithFilesOlderThanTheDate     5   	   $	??250??5      $	??450??6     ? Title$2  ,CopyFolderStructureWithFilesOlderThanTheDate??5
   	   $	??450??6>   $	??800??6K    ? Icon$F @/copy-two-paper-sheets-interface-symbol_icon-icons.com_73283.png??6W   .??5      ? .+?5   
   ?? -   5         ??Name$ 
TxtBxInput??5      $??135,11,55,0q?6&    ?? TextWrapping$
 Wrap=?6;   $	??Top=?6O   $??25??6g   $??14(?6s   ?? 5   
   $??Input Path:??6   $
??Left=?6&   $??	10,10,0,0q?6A   $	??Top=?6T   $??83??6l   $??13(?6w   ?? 5   
   -   5        $ TxtBxOutput??5      $??135,42,55,0q?6'   $
 Wrap=?6<   $	??Top=?6P   $??25??6h   $??14(?6t   ?? 5   
   $??Output Path:??6   $
??Left=?6'   $??	10,41,0,0q?6B   $	??Top=?6U   $??83??6m   $??13(?6x   ?? 5   
   -   5         ??Name$ InputPathButton??5      $	??...??6*   $??Right=?68   $??	0,11,10,0q?6T   $	??Top=?6g   $??25??6   $??40??6?   ?? 5   
   -   5        $ OutputPathButton??5      $	??...??6+   $??Right=?69   $??	0,42,10,0q?6U   $	??Top=?6h   $??25??6?   $??40??6?   6?   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePickerOlderThan??5      $
??Left=?62   $??
135,75,0,0q?6M   $	??Top=?6a   $??14(?6y   $??29??6?   ?? 5   
   $??Copy older than:??6   $
??Left=?6+   $??	10,75,0,0q?6F   $	??Top=?6Y   $	??120??6q   $??14(?6}   ?? 5   
   -   5        $ 
CopyButton??5      $
??Copy??6%   $??Right=?64   $??	0,75,10,0q?6P   $	??Top=?6c   $	??115??6{   $??29??6?   6?   ?? 5   
   -   5         ??Name$ 
listBoxMsg??5      $??10,164,10,35q?6Q    ?? SelectionMode$ Multiple=?6h   ? 5   
   -   5         ?Name$ ProgressBar??5      $??16??6+   $??10,164,10,10q?67   $??Bottom=?6M   ???	#FF53C7686h   ?? 5   
   $??Center=?6[   $??Bottom=?6x   $??0,0,0,10q?6?   ??6   ?? *Value+	 ?? ElementName$	 ProgressBar??
 ?? StringFormat$
 {0:0}%??6?   5      5      