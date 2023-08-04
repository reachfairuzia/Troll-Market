using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.Provider
{
    public class BaseProvider
    {
        protected const int totalDataPerPage = 10;

        protected static int TotalHalaman(int totalData)
        {
            int totalHalaman = (int)Math.Ceiling(totalData / (decimal)totalDataPerPage);
            return totalHalaman;
        }

        protected static int GetSkip(int page)
        {
            int skip = (page - 1) * totalDataPerPage;
            return skip;
        }

        protected static string FormatMoney(decimal uang)
        {
            return uang.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
        }

        protected static string FormatTanggal(DateTime tanggal)
        {
            return tanggal.ToString("dd MMMM yyyy");
        }

        protected static string GetAge(DateTime birthdate)
        {
            var totalHari = DateTime.Now.Year - birthdate.Year;
            return totalHari.ToString();
        }

        public static string FormatNullableDouble(double? value)
        {
            if (value.HasValue)
            {
                CultureInfo cultureInfo = new CultureInfo("id-ID");
                return value.Value.ToString("C", cultureInfo);
            }

            return "N/A";
        }

        public static string FormatNullableDatetime(DateTime? value)
        {
            if (value.HasValue)
            {
                CultureInfo cultureInfo = new CultureInfo("id-ID");
                return value.Value.ToString("dd/MM/yyyy", cultureInfo);
            }

            return "N/A";
        }
    }
}
