using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_var_6.DataBase
{
    class ProductObj
    {
        public static string Id { get; set; }
        public static string NameProduct { get; set; }
        public static string UnitOfMeasurement { get; set; }
        public static decimal ProductCost { get; set; }
        public static int SizeMaxDiscount { get; set; }
        public static string ProductManufacturer { get; set; }
        public static string Provider { get; set; }
        public static string Category { get; set; }
        public static int ProductDiscountAmount { get; set; }
        public static int ProductQuantityInStock { get; set; }
        public static string ProductDescription { get; set; }
        public static string Photo { get; set; }


    }
}
