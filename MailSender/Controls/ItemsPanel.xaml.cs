using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.Controls
{
    public partial class ItemsPanel : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(ItemsPanel),
                new PropertyMetadata(default(string)));
        #region AddNewItemCommand: ICommand - добавление нового элемента
        private readonly DependencyProperty AddNewCommandProperty=
            DependencyProperty.Register(
                nameof(AddNewItemCommand),
                typeof(ICommand),
                typeof(ItemsPanel),
                new PropertyMetadata(default(ICommand)));

        public ICommand AddNewItemCommand
        {
            get => (ICommand)GetValue(AddNewCommandProperty);
            set => SetValue(AddNewCommandProperty, value);
        }
        #endregion
        #region EditItemCommand: ICommand - редактирование элемента
        private readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditItemCommand),
                typeof(ICommand),
                typeof(ItemsPanel),
                new PropertyMetadata(default(ICommand)));

        public ICommand EditItemCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }
        #endregion
        #region RemoveItemCommand:ICommand - удаление элемента
        private readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register(
                nameof(RemoveItemCommand),
                typeof(ICommand),
                typeof(ItemsPanel),
                new PropertyMetadata(default(ICommand)));

        public ICommand RemoveItemCommand
        {
            get => (ICommand)GetValue(RemoveCommandProperty);
            set => SetValue(RemoveCommandProperty, value);
        }
        #endregion
        #region ItemSource:IEnumerable - элементы панели
        private readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(ItemsPanel),
                new PropertyMetadata(default(IEnumerable)));

        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }
        #endregion
        #region ItemSource:object - выбранный элемент
        private readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemsPanel),
                new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        #endregion
        #region ItemTemplate:DataTemplate - шаблон элемента выпадающего списка
        private readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(ItemsPanel),
                new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }
        #endregion
        #region DisplayMemberPath:string - имя отображаемого свойства
        private readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(ItemsPanel),
                new PropertyMetadata(default(string)));

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }
        #endregion
        public string Title 
        { 
            get=>(string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value); 
        }

        public ItemsPanel() => InitializeComponent();
    }
}
