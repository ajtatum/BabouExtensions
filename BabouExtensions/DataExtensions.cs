using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BabouExtensions
{
    /// <summary>
    /// Data Extensions
    /// </summary>
    public static class DataExtensions
    {
        /// <summary>
        /// Checks if the DataSet is empty
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DataSet dataSet)
        {
            return dataSet == null ||
                   !(from DataTable t in dataSet.Tables where t.Rows.Count > 0 select t).Any();
        }

        /// <summary>
        /// Converts the passed in data table to a CSV-style string.
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <returns>Resulting CSV-style string</returns>
        public static string ToCSV(this DataTable table)
        {
            return ToCSV(table, ",", true);
        }

        /// <summary>
        /// Converts the passed in data table to a CSV-style string.
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <param name="includeHeader">true - include headers<br/>
        /// false - do not include header column</param>
        /// <returns>Resulting CSV-style string</returns>
        public static string ToCSV(this DataTable table, bool includeHeader)
        {
            return ToCSV(table, ",", includeHeader);
        }

        /// <summary>
        /// Converts the passed in data table to a CSV-style string.
        /// </summary>
        /// <param name="table">Table to convert</param>
        /// <param name="delimiter"> </param>
        /// <param name="includeHeader">true - include headers<br/>
        /// false - do not include header column</param>
        /// <returns>Resulting CSV-style string</returns>
        public static string ToCSV(this DataTable table, string delimiter, bool includeHeader)
        {
            var result = new StringBuilder();

            if (includeHeader)
            {
                foreach (DataColumn column in table.Columns)
                {
                    result.Append(column.ColumnName);
                    result.Append(delimiter);
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item is DBNull)
                    {
                        result.Append(delimiter);
                    }
                    else
                    {
                        var itemAsString = item.ToString();
                        // Double up all embedded double quotes
                        itemAsString = itemAsString.Replace("\"", "\"\"");

                        // To keep things simple, always delimit with double-quotes
                        // so we don't have to determine in which cases they're necessary
                        // and which cases they're not.
                        itemAsString = "\"" + itemAsString + "\"";

                        result.Append(itemAsString + delimiter);
                    }
                }

                result.Remove(--result.Length, 0);
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }

        #region DataTable to List Methods

        private static readonly Dictionary<Type, IList<PropertyInfo>> typeDictionary =
            new Dictionary<Type, IList<PropertyInfo>>();

        public static IList<PropertyInfo> GetPropertiesForType<T>()
        {
            var type = typeof(T);
            if (!typeDictionary.ContainsKey(typeof(T)))
            {
                typeDictionary.Add(type, type.GetProperties().ToList());
            }
            return typeDictionary[type];
        }

        /// <summary>
        /// Generates a List from a DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            var properties = GetPropertiesForType<T>();

            return (from object row in table.Rows select CreateItemFromRow<T>((DataRow) row, properties)).ToList();
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            var item = new T();
            foreach (var property in properties)
            {
                property.SetValue(item, row[property.Name], null);
            }
            return item;
        }

        #endregion DataTable to List Methods

        #region DataTable to Html Table Methods

        public class DataTableToHtmlOptions
        {
            public string TableStyle { get; set; }
            public string TableId { get; set; }
            public string TableEvenRowBgHex { get; set; }
            public string TableOddRowBgHex { get; set; }

            public List<string> HeaderStyles { get; set; }
            public List<string> ItemStyles { get; set; }
            public List<string> ItemFormats { get; set; }
            public bool TotalLastColumn { get; set; }
            public string TotalColumnName { get; set; }
        }

        public static string ToHtmlTable(this DataTable targetTable, DataTableToHtmlOptions options)
        {
            if (targetTable == null)
            {
                throw new ArgumentNullException(nameof(targetTable));
            }

            if (targetTable.Columns.Count != options.HeaderStyles.Count)
            {
                throw new Exception("Total number of columns don't match number of defined column widths");
            }

            if (targetTable.Columns.Count != options.ItemFormats.Count)
            {
                throw new Exception("Total number of columns don't match number of defined column formats");
            }

            var htmlBuilder = new StringBuilder();
            var tableStyle = string.IsNullOrEmpty(options.TableStyle)
                ? "style=\"width: 100%; border-collapse: collapse; border: 1px solid navy;text-align: left;\" cellpadding=\"10\""
                : options.TableStyle;
            //Create Top Portion of HTML Document
            htmlBuilder.AppendFormat("<table {0}>", tableStyle);

            //Create Header Row
            htmlBuilder.Append("<tr align='left' valign='top'>");

            for (var i = 0; i < targetTable.Columns.Count; i++)
            {
                htmlBuilder.Append($"<th style=\"{options.HeaderStyles[i]}\">");
                htmlBuilder.Append(targetTable.Columns[i].ColumnName.AddSpacesToSentence());
                htmlBuilder.Append("</th>");
            }

            htmlBuilder.Append("</tr>");

            //Create Data Rows
            for (var r = 0; r < targetTable.Rows.Count; r++)
            {
                htmlBuilder.Append(
                    $"<tr style=\"background-color: {(r % 2 == 0 ? options.TableEvenRowBgHex : options.TableOddRowBgHex)};\">");

                for (var c = 0; c < targetTable.Columns.Count; c++)
                {
                    htmlBuilder.Append($"<td style=\"{options.ItemStyles[c]}\">");
                    htmlBuilder.Append(string.Format(options.ItemFormats[c],
                        targetTable.Rows[r][targetTable.Columns[c].ColumnName]));
                    htmlBuilder.Append("</td>");
                }

                htmlBuilder.Append("</tr>");
            }

            if (options.TotalLastColumn && !String.IsNullOrEmpty(options.TotalColumnName))
            {
                var totalAmount = targetTable.Compute($"SUM({options.TotalColumnName})", string.Empty);

                htmlBuilder.Append("<tr>");
                htmlBuilder.Append(
                    $"<td style=\"border-top:2px double navy; font-weight:bold;\" colspan=\"{targetTable.Columns.Count - 1}\">Total:</td>");
                htmlBuilder.Append(
                    $"<td style=\"border-top:2px double navy; font-weight:bold; text-align:right;\">{totalAmount:C}</td>");
                htmlBuilder.Append("</tr>");
            }

            //Create Bottom Portion of HTML Document
            htmlBuilder.Append("</table>");

            //Create String to be Returned
            var htmlString = htmlBuilder.ToString();

            return htmlString;
        }

        #endregion DataTable to Html Table Methods
    }
}