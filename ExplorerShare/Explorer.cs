using ExplorerCtrl.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ExplorerCtrl
{
    public class Explorer : Control
    {
        static Explorer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Explorer), new FrameworkPropertyMetadata(typeof(Explorer)));
        }

        private Point dragStartPoint;
        private bool isMouseDown = false;
        private ExplorerItem selectedItem;
        private ProgresshWindow dlg;


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TreeView treeView = GetTemplateChild("treeView") as TreeView;
            treeView.SelectedItemChanged += OnSelectedFolderChanged;

            DataGrid dataGrid = GetTemplateChild("dataGrid") as DataGrid;
            dataGrid.PreviewDragEnter += OnDrag;
            dataGrid.PreviewDragOver += OnDrag;
            dataGrid.PreviewDrop += OnDrop;
            dataGrid.PreviewMouseLeftButtonDown += OnMouseDown;
            dataGrid.PreviewMouseLeftButtonUp += OnMouseUp;
            dataGrid.PreviewMouseMove += OnMouseMove;
            dataGrid.MouseDoubleClick += OnMouseDoubleClick;
            dataGrid.SelectionChanged += OnSelectionChanged;
            dataGrid.Sorting += OnSorting;

            //ProgresshWindow dlg = new ProgresshWindow();
            //dlg.Show();
        }

        #region public Dependency Properties
        
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<IExplorerItem>), typeof(Explorer), new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

        public IEnumerable<IExplorerItem> ItemsSource
        {
            get { return (IEnumerable<IExplorerItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Explorer explorer = (Explorer)d;
            IEnumerable<IExplorerItem> newValue = (IEnumerable<IExplorerItem>)e.NewValue;
            IEnumerable<IExplorerItem> oldValue = (IEnumerable<IExplorerItem>)e.OldValue;
            explorer.OnItemsSourceChanged(newValue, oldValue);
        }

        private void OnItemsSourceChanged(IEnumerable<IExplorerItem> newValue, IEnumerable<IExplorerItem> oldValue)
        {
            if (oldValue != null)
            {
                INotifyCollectionChanged notify = oldValue as INotifyCollectionChanged;
                if (notify != null)
                {
                    notify.CollectionChanged -= OnItemsSourceNotifyCollectionChanged;
                }
            }
            if (newValue != null)
            {
                INotifyCollectionChanged notify = newValue as INotifyCollectionChanged;
                if (notify != null)
                {
                    notify.CollectionChanged += OnItemsSourceNotifyCollectionChanged;     
                }
                var list = newValue.Select(v => new ExplorerItem(v, null) { IsSelectedInTree = true, IsExpanded = true }).ToList();
                this.InternalItemsSource = new ObservableCollection<ExplorerItem>(list);
            }
            else
            {
                this.InternalItemsSource = null;
            }
        }
               
        private void OnItemsSourceNotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
            case NotifyCollectionChangedAction.Add:
                var list = e.NewItems.Cast<IExplorerItem>().Select(v => new ExplorerItem(v, null) { IsSelectedInTree = true, IsExpanded = true }).ToList();
                foreach (var i in list)
                {
                    this.InternalItemsSource.Add(i);
                }
                break;
            case NotifyCollectionChangedAction.Remove:
                break;
            case NotifyCollectionChangedAction.Replace:
                break;
            case NotifyCollectionChangedAction.Move:
                break;
            case NotifyCollectionChangedAction.Reset:
                this.InternalItemsSource.Clear();
                break;
            }
        }

        internal static readonly DependencyProperty InternalItemsSourceProperty =
            DependencyProperty.Register("InternalItemsSource", typeof(ObservableCollection<ExplorerItem>), typeof(Explorer), 
                new FrameworkPropertyMetadata(null));

        internal ObservableCollection<ExplorerItem> InternalItemsSource
        {
            get { return (ObservableCollection<ExplorerItem>)GetValue(InternalItemsSourceProperty); }
            set { SetValue(InternalItemsSourceProperty, value); }
        }



        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(ExplorerItem), typeof(Explorer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        internal ExplorerItem SelectedItem
        {
            get { return (ExplorerItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(IExplorerItem), typeof(Explorer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public IExplorerItem SelectedValue
        {
            get { return (IExplorerItem)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList), typeof(Explorer), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object SelectedItems
        {
            get { return GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty FolderContextMenuProperty =
            DependencyProperty.Register("FolderContextMenu", typeof(ContextMenu), typeof(Explorer), new FrameworkPropertyMetadata(null));

        public ContextMenu FolderContextMenu
        {
            get { return (ContextMenu)GetValue(FolderContextMenuProperty); }
            set { SetValue(FolderContextMenuProperty, value); }
        }

        public static readonly DependencyProperty FileContextMenuProperty =
            DependencyProperty.Register("FileContextMenu", typeof(ContextMenu), typeof(Explorer), new FrameworkPropertyMetadata(null));

        public ContextMenu FileContextMenu
        {
            get { return (ContextMenu)GetValue(FileContextMenuProperty); }
            set { SetValue(FileContextMenuProperty, value); }
        }

        public static readonly DependencyProperty ListContextMenuProperty =
           DependencyProperty.Register("ListContextMenu", typeof(ContextMenu), typeof(Explorer), new FrameworkPropertyMetadata(null));

        public ContextMenu ListContextMenu
        {
            get { return (ContextMenu)GetValue(ListContextMenuProperty); }
            set { SetValue(ListContextMenuProperty, value); }
        }

        #endregion

        #region internal Dependency Properties

        internal static readonly DependencyProperty ListItemsProperty =
            DependencyProperty.Register("ListItems", typeof(ICollectionView), typeof(Explorer), new FrameworkPropertyMetadata(null));

        internal ICollectionView ListItems
        {
            get { return (ICollectionView)GetValue(ListItemsProperty); }
            set { SetValue(ListItemsProperty, value); }
        }
        #endregion

        #region event handler

        private void OnSelectedFolderChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ExplorerItem item = e.NewValue as ExplorerItem;
            this.SelectedItem = item;
            this.selectedItem = item; // to use from working thread
            this.SelectedValue = item?.Content;
            this.ListItems = item?.Files;
        }

        private void OnClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                FrameworkElement sp = sender as FrameworkElement;
                ExplorerItem item = sp.DataContext as ExplorerItem;
                item.IsSelectedInTree = true;
            }
        }

        private void OnDrag(object sender, DragEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            bool isCorrect = true;
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] files = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string file in files)
                {
                    if (!File.Exists(file) && !Directory.Exists(file))
                    {
                        isCorrect = false;
                    }
                }
            }
            e.Effects = isCorrect ? DragDropEffects.All : DragDropEffects.None;
            e.Handled = true;
        }

        
        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                List<string> files = new List<string>();
                string[] fileDrops = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string file in fileDrops)
                {
                    files.Add(file);
                    // add directory content
                    if (Directory.Exists(file))
                    {
                        files.AddRange(Directory.EnumerateFileSystemEntries(file, "*", SearchOption.AllDirectories));
                    }
                }
                string rootPath = Path.GetDirectoryName(fileDrops[0]);

                ProgresshWindow dlg = new ProgresshWindow() { Owner = Window.GetWindow(this) }; 
                dlg.Show();

                Task.Run(() =>
                {
                    try
                    {
                        int num = files.Count;
                        int index = 0; 
                        foreach (string file in files)
                        {
                            if (dlg.IsCancelPendíng)
                            {
                                break;
                            }

                            Invoke(() => dlg.Update((double)(index++) / num, file));
                            // for updating progress windows
                            Thread.Sleep(1);

                            // do push
                            Invoke(() =>
                            {
                                string relPath = GetRelPath(file, rootPath);
                                if (File.Exists(file))
                                {
                                    using (FileStream stream = File.OpenRead(file))
                                    {
                                        this.SelectedItem.Content.Push(stream, relPath);
                                    }
                                }
                                else if (Directory.Exists(file))
                                {
                                    this.SelectedItem.Content.CreateFolder(relPath);
                                }
                            });
                            
                        }

                        Invoke(() =>
                        {
                            dlg.Update(1.0);
                            // let window stay for 2 sec to prevent flickering for small files
                            Thread.Sleep(2000);
                            dlg.Close();
                            this.selectedItem.Refresh(true);
                        });
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                });
            }
            e.Handled = true;
        }

        //bool isDrag = false;
        private DataGridRow downRow;
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 1)
            {
                return;
            }

            //DataGridRow row = FindVisualParent<DataGridRow>(e.OriginalSource);
            DataGridCell cell = FindVisualParent<DataGridCell>(e.OriginalSource);
            if (cell == null)
            {
                return;
            }

            DataGrid dataGrid = sender as DataGrid;

            // do not select during drag & drop
            DataGridRow row = FindVisualParent<DataGridRow>(e.OriginalSource);
            if (row is DataGridRow)
            {
                if (dataGrid.SelectedItems.Contains(row.Item))
                {
                    e.Handled = true;
                    downRow = row;
                }
            }
            
            this.dragStartPoint = e.GetPosition(dataGrid);
            this.isMouseDown = true;
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (Keyboard.Modifiers == ModifierKeys.None)
            {
                DataGridRow row = FindVisualParent<DataGridRow>(e.OriginalSource);
                if (row != null && dataGrid.SelectedItems.Count > 1)
                {
                    dataGrid.SelectedItems.Cast<ExplorerItem>().Where(i => !i.Equals(row.Item)).ToList().ForEach(i => i.IsSelectedInList = false);
                }
            }
            this.isMouseDown = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            Point p = e.GetPosition(dataGrid);
            if (this.isMouseDown && (this.dragStartPoint - p).Length > 10)
            {
                List<FileDescriptor> files = new List<FileDescriptor>();
                var items = dataGrid.SelectedItems.Cast<ExplorerItem>().ToList();
                FindRecursive(files, items);

                this.numOfFiles = files.Count;
                this.copyIndex = 0;

                var virtualFileDataObject = new VirtualFileDataObject(Start, Stop, Pull);
                virtualFileDataObject.SetData(files);

                this.dlg = new ProgresshWindow() { Owner = Window.GetWindow(this) };
                VirtualFileDataObject.DoDragDrop(dataGrid, virtualFileDataObject, DragDropEffects.Copy);
                
                this.isMouseDown = false;
            }
        }

        private int numOfFiles;
        private int copyIndex;

        private void Start(VirtualFileDataObject o)
        {
            MTAInvoke(() => this.dlg.Show());
        }

        private void Stop(VirtualFileDataObject o)
        {
            MTAInvoke(() => this.dlg.Hide());
        }

        private void Pull(Stream stream, FileDescriptor fileDescriptor)
        {
            try
            {
                Debug.WriteLine($"{fileDescriptor.DevName} -> {fileDescriptor.Name}");

                MTAInvoke(() => this.dlg.Update((double)(copyIndex++) / numOfFiles, fileDescriptor.DevName));

                //this.progressBar.Value = index++ / count;
                //this.currentFile.Text = (string)item.FullName;
                fileDescriptor.Item.Pull(fileDescriptor.DevName, stream);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void FindRecursive(List<FileDescriptor> files, IEnumerable<ExplorerItem> items, string root = null)
        {
            foreach (ExplorerItem item in items)
            {
                if (item.IsDirectory)
                {
                    item.Refresh(false);


                    // TODO don't know how to create empty folder

                    string devPath = item.FullName;
                    string path = GetRelPath(devPath, this.SelectedItem.FullName);
                    var file = new FileDescriptor
                    {
                        Name = path,
                        Length = 0,
                        ChangeTimeUtc = DateTime.Now,
                        Item = item.Content,
                        DevName = null,
                        IsDirectory = true
                    };
                    files.Add(file);

                    FindRecursive(files, item.Children, root);
                }
                else
                {
                    string devPath = item.FullName;
                    string path = GetRelPath(devPath, this.SelectedItem.FullName);

                    var file = new FileDescriptor
                    {
                        Name = path, // item.Name,
                        Length = item.Size,
                        ChangeTimeUtc = DateTime.Now,
                        Item = item.Content,
                        DevName = devPath

                        //StreamContents = Pull
                    };
                    files.Add(file);
                }
            }
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            if (fe != null)
            {
                ExplorerItem ei = fe.DataContext as ExplorerItem;
                if (ei != null)
                {
                    if (ei.Parent != null)
                    {
                        ei.Parent.IsExpanded = true;
                    }
                    ei.IsSelectedInTree = true;
                }
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            SelectedItems = dataGrid.SelectedItems;
        }

        #endregion

        private void OnSorting(object sender, DataGridSortingEventArgs e)
        {
            // do special sorting for Name column
            if ((string)e.Column.Header == "Name")
            {
                DataGrid dataGrid = sender as DataGrid;
                SortDescriptionCollection sort = dataGrid.Items.SortDescriptions;
                if (e.Column.SortDirection == ListSortDirection.Ascending)
                {
                    e.Column.SortDirection = ListSortDirection.Descending;
                    sort.Clear();
                    sort.Add(new SortDescription("IsDirectory", ListSortDirection.Descending));
                    sort.Add(new SortDescription("Name", ListSortDirection.Ascending));
                }
                else
                {
                    e.Column.SortDirection = ListSortDirection.Ascending;
                    sort.Clear();
                    sort.Add(new SortDescription("IsDirectory", ListSortDirection.Ascending));
                    sort.Add(new SortDescription("Name", ListSortDirection.Descending));
                }
                e.Handled = true;
            }
        }

        private static T FindVisualParent<T>(object obj) where T : DependencyObject
        {
            DependencyObject dep = (DependencyObject)obj;
            do
            {
                dep = VisualTreeHelper.GetParent(dep);
            } while (dep != null && dep.GetType() != typeof(T));
            return (T)dep;
        }

        protected static void InvokeIfNeeded(Action callback)
        {
            if (Application.Current == null || Application.Current.Dispatcher.CheckAccess())
            {
                callback();
            }
            else
            {
                Application.Current.Dispatcher.Invoke(callback);
            }
        }

        protected static void Invoke(Action callback)
        {
            Application.Current.Dispatcher.Invoke(callback);
        }

        protected static void MTAInvoke(Action callback)
        {
            Thread thread = new Thread(() =>
            {
                Application.Current.Dispatcher.Invoke(callback);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            //thread.Join();
        }


        public static string GetRelPath(string path, string rootPath)
        {
            if (!path.ToLower().StartsWith(rootPath.ToLower()))
            {
                throw new ApplicationException(string.Format("{0} not root path of {1}", rootPath, path));
            }
            return path.Substring(rootPath.Length + 1);
        }
    }
}
