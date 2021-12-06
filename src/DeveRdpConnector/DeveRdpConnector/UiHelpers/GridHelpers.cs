//using Avalonia;
//using Avalonia.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DeveRdpConnector.UiHelpers
//{
//    public class GridHelpers
//    {
//        #region RowCount Property

//        /// <summary>
//        /// Adds the specified number of Rows to RowDefinitions. 
//        /// Default Height is Auto
//        /// </summary>
//        public static readonly AvaloniaProperty RowCountProperty =
//            AvaloniaProperty.RegisterAttached<GridHelpers, int>("RowCount", -1, false, Avalonia.Data.BindingMode.TwoWay);

//        // Get
//        public static int GetRowCount(AvaloniaObject obj)
//        {
//            return (int)obj.GetValue(RowCountProperty);
//        }

//        // Set
//        public static void SetRowCount(AvaloniaObject obj, int value)
//        {
//            obj.SetValue(RowCountProperty, value);
//        }

//        // Change Event - Adds the Rows
//        public static void RowCountChanged(
//            AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
//        {
//            if (!(obj is Grid) || (int)e.NewValue < 0)
//                return;

//            Grid grid = (Grid)obj;
//            grid.RowDefinitions.Clear();

//            for (int i = 0; i < (int)e.NewValue; i++)
//                grid.RowDefinitions.Add(
//                    new RowDefinition() { Height = GridLength.Auto });

//            SetStarRows(grid);
//        }

//        #endregion

//        #region ColumnCount Property

//        /// <summary>
//        /// Adds the specified number of Columns to ColumnDefinitions. 
//        /// Default Width is Auto
//        /// </summary>
//        public static readonly AvaloniaProperty ColumnCountProperty =
//            AvaloniaProperty.RegisterAttached(
//                "ColumnCount", typeof(int), typeof(GridHelpers),
//                new PropertyMetadata(-1, ColumnCountChanged));

//        // Get
//        public static int GetColumnCount(AvaloniaObject obj)
//        {
//            return (int)obj.GetValue(ColumnCountProperty);
//        }

//        // Set
//        public static void SetColumnCount(AvaloniaObject obj, int value)
//        {
//            obj.SetValue(ColumnCountProperty, value);
//        }

//        // Change Event - Add the Columns
//        public static void ColumnCountChanged(
//            AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
//        {
//            if (!(obj is Grid) || (int)e.NewValue < 0)
//                return;

//            Grid grid = (Grid)obj;
//            grid.ColumnDefinitions.Clear();

//            for (int i = 0; i < (int)e.NewValue; i++)
//                grid.ColumnDefinitions.Add(
//                    new ColumnDefinition() { Width = GridLength.Auto });

//            SetStarColumns(grid);
//        }

//        #endregion

//        #region StarRows Property

//        /// <summary>
//        /// Makes the specified Row's Height equal to Star. 
//        /// Can set on multiple Rows
//        /// </summary>
//        public static readonly AvaloniaProperty StarRowsProperty =
//            AvaloniaProperty.RegisterAttached(
//                "StarRows", typeof(string), typeof(GridHelpers),
//                new PropertyMetadata(string.Empty, StarRowsChanged));

//        // Get
//        public static string GetStarRows(AvaloniaObject obj)
//        {
//            return (string)obj.GetValue(StarRowsProperty);
//        }

//        // Set
//        public static void SetStarRows(AvaloniaObject obj, string value)
//        {
//            obj.SetValue(StarRowsProperty, value);
//        }

//        // Change Event - Makes specified Row's Height equal to Star
//        public static void StarRowsChanged(
//            AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
//        {
//            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
//                return;

//            SetStarRows((Grid)obj);
//        }

//        #endregion

//        #region StarColumns Property

//        /// <summary>
//        /// Makes the specified Column's Width equal to Star. 
//        /// Can set on multiple Columns
//        /// </summary>
//        public static readonly AvaloniaProperty StarColumnsProperty =
//            AvaloniaProperty.RegisterAttached(
//                "StarColumns", typeof(string), typeof(GridHelpers),
//                new PropertyMetadata(string.Empty, StarColumnsChanged));

//        // Get
//        public static string GetStarColumns(AvaloniaObject obj)
//        {
//            return (string)obj.GetValue(StarColumnsProperty);
//        }

//        // Set
//        public static void SetStarColumns(AvaloniaObject obj, string value)
//        {
//            obj.SetValue(StarColumnsProperty, value);
//        }

//        // Change Event - Makes specified Column's Width equal to Star
//        public static void StarColumnsChanged(
//            AvaloniaObject obj, AvaloniaPropertyChangedEventArgs e)
//        {
//            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
//                return;

//            SetStarColumns((Grid)obj);
//        }

//        #endregion

//        private static void SetStarColumns(Grid grid)
//        {
//            string[] starColumns =
//                GetStarColumns(grid).Split(',');

//            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
//            {
//                if (starColumns.Contains(i.ToString()))
//                    grid.ColumnDefinitions[i].Width =
//                        new GridLength(1, GridUnitType.Star);
//            }
//        }

//        private static void SetStarRows(Grid grid)
//        {
//            string[] starRows =
//                GetStarRows(grid).Split(',');

//            for (int i = 0; i < grid.RowDefinitions.Count; i++)
//            {
//                if (starRows.Contains(i.ToString()))
//                    grid.RowDefinitions[i].Height =
//                        new GridLength(1, GridUnitType.Star);
//            }
//        }
//    }
//}
