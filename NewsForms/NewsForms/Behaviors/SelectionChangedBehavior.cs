using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsForms.Behaviors
{
	public class SelectionChangedBehavior : Behavior<CollectionView>
    {
        public static readonly BindableProperty SelectionChangedCommandProperty =
            BindableProperty.Create(nameof(SelectionChangedCommand), typeof(ICommand), typeof(SelectionChangedBehavior));

        public ICommand SelectionChangedCommand
        {
            get => (ICommand)GetValue(SelectionChangedCommandProperty);
            set => SetValue(SelectionChangedCommandProperty, value);
        }

        protected override void OnAttachedTo(CollectionView collectionView)
        {
            base.OnAttachedTo(collectionView);

            collectionView.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetachingFrom(CollectionView collectionView)
        {
            base.OnDetachingFrom(collectionView);

            collectionView.SelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectionChangedCommand != null && e.CurrentSelection.Count > 0)
            {
                var selectedItem = e.CurrentSelection[0];
                SelectionChangedCommand.Execute(selectedItem);
            }
        }
    }

}


