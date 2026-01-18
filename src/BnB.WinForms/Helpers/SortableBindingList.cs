using System.ComponentModel;

namespace BnB.WinForms.Helpers;

/// <summary>
/// A BindingList that supports sorting by clicking on column headers in a DataGridView.
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class SortableBindingList<T> : BindingList<T>
{
    private bool _isSorted;
    private PropertyDescriptor? _sortProperty;
    private ListSortDirection _sortDirection;

    public SortableBindingList() : base()
    {
    }

    public SortableBindingList(IList<T> list) : base(list)
    {
    }

    protected override bool SupportsSortingCore => true;

    protected override bool IsSortedCore => _isSorted;

    protected override PropertyDescriptor? SortPropertyCore => _sortProperty;

    protected override ListSortDirection SortDirectionCore => _sortDirection;

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        _sortProperty = prop;
        _sortDirection = direction;

        if (Items is List<T> list)
        {
            list.Sort((x, y) =>
            {
                var xValue = prop.GetValue(x);
                var yValue = prop.GetValue(y);

                int result;
                if (xValue == null && yValue == null)
                {
                    result = 0;
                }
                else if (xValue == null)
                {
                    result = -1;
                }
                else if (yValue == null)
                {
                    result = 1;
                }
                else if (xValue is IComparable comparable)
                {
                    result = comparable.CompareTo(yValue);
                }
                else
                {
                    result = string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.CurrentCulture);
                }

                return direction == ListSortDirection.Descending ? -result : result;
            });
        }

        _isSorted = true;
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore()
    {
        _isSorted = false;
        _sortProperty = null;
    }

    /// <summary>
    /// Creates a SortableBindingList from an existing collection.
    /// </summary>
    public static SortableBindingList<T> FromList(IEnumerable<T> source)
    {
        return new SortableBindingList<T>(source.ToList());
    }
}
